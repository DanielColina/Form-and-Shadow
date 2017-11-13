using UnityEngine;
using System.Collections;

namespace Climbing
{
    public class ClimbBehavior : MonoBehaviour
    {
        public static bool playerCanClimb;
        public bool climbing;
        bool waitToStartClimb;
        bool initClimb;

        Animator anim;
        ClimbIK ik;

        ClimbManager currentManager;
        Point targetPoint;
        Point currentPoint;
        Point previousPoint;
        Neighbor neighbor;
        ConnectionType currentConnection;

        ClimbStates currentState;
        ClimbStates targetState;

        public enum ClimbStates
        {
            onPoint, betweenPoints, inTransit
        }

        #region Curves
        //Variables for Curve Movement
        CurvesHolder curvesHolder;
        BezierCurve directCurveHorizontal;
        BezierCurve directCurveVertical;
        BezierCurve dismountCurve;
        BezierCurve mountCurve;
        BezierCurve currentCurve;
        #endregion

        //Interpolation variables
        Vector3 startPos;
        Vector3 endPos;
        float distance;
        float timer;
        bool initTransit;
        bool rootReached;
        bool ikLandSideReached;
        bool ikFollowSideReached;

        //Input variables
        bool lockInput;
        Vector3 inputDirection;
        Vector3 targetPosition;

        //Tweakable variables
        public Vector3 rootOffset = new Vector3(0, -0.55f, 0);
        public float speedLinear = 1.3f;
        public float speedDirect = 2f;

        public AnimationCurve animJumpingCurve;
        public AnimationCurve animMountCurve;
        public bool enableRootMovement;
        float rootMovementMax = 0.25f;
        float rootMovementTimer;

        void SetCurveReferences()
        {
            GameObject curveHolderPrefab = Resources.Load("CurvesHolder") as GameObject;
            GameObject curveHolderGameObj = Instantiate(curveHolderPrefab) as GameObject;

            curvesHolder = curveHolderGameObj.GetComponent<CurvesHolder>();

            directCurveHorizontal = curvesHolder.ReturnCurve(CurveType.horizontal);
            directCurveVertical = curvesHolder.ReturnCurve(CurveType.vertical);
            dismountCurve = curvesHolder.ReturnCurve(CurveType.dismount);
            mountCurve = curvesHolder.ReturnCurve(CurveType.mount);
        }

        void Start()
        {
            anim = GetComponentInChildren<Animator>();
            ik = GetComponentInChildren<ClimbIK>();
            SetCurveReferences();
        }

        void Update()
        {
            if(climbing)
            {
                if(!waitToStartClimb)
                {
                    HandleClimbing();
                    InitiateFallOff();
                }
                else
                {
                    InitiateClimbing();
                    HandleMount();
                }
            }
            else
            {
                if(initClimb)
                {
                    transform.parent = null;
                    initClimb = false;
                }
                if (Input.GetKeyDown(KeyCode.Space) && PlayerController.m_Instance.m_IsGrounded)
                {
                    LookForClimbSpot();
                }
            }
        }

        void LookForClimbSpot()
        {
            Ray ray = new Ray(transform.position + Vector3.up, transform.forward);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 1.5f, 1 << 9, QueryTriggerInteraction.Collide))
            {
                if (hit.transform.GetComponentInParent<ClimbManager>())
                {
                    ClimbManager temp = hit.transform.GetComponentInParent<ClimbManager>();

                    Point closestPoint = temp.ReturnClosest(transform.position);

                    //See if the angle between the player and the closest point is greater than 40 degrees
                    float angle = Vector3.Angle(transform.forward, closestPoint.transform.forward);

                    if(angle > 40)
                    {
                        closestPoint = null;
                        return;
                    }

                    float distanceToPoint = Vector3.Distance(transform.position, closestPoint.transform.parent.position);

                    if (distanceToPoint < 5)
                    {
                        ToggleClimbingState(true);
                        anim.SetBool("Climbing", true);
                        currentManager = temp;
                        targetPoint = closestPoint;
                        targetPosition = closestPoint.transform.position;
                        currentPoint = closestPoint;
                        climbing = true;
                        lockInput = true;
                        targetState = ClimbStates.onPoint;
                        waitToStartClimb = true;
                    }
                }
            }
        }

        void InitiateClimbing()
        {
            if(!initClimb)
            {
                initClimb = true;

                if (ik != null)
                {
                    ik.UpdateAllPointsOnOne(targetPoint);
                    ik.UpdateAllTargetPositions(targetPoint);
                    ik.ImmediatePlaceHelpers();
                }

                currentConnection = ConnectionType.Direct;
                targetState = ClimbStates.onPoint;
            }
        }

        void HandleMount()
        {
            if(!initTransit)
            {
                initTransit = true;
                ikFollowSideReached = false;
                ikLandSideReached = false;
                timer = 0;
                startPos = transform.position;
                endPos = targetPosition + rootOffset;

                currentCurve = mountCurve;
                currentCurve.transform.rotation = targetPoint.transform.rotation;
                BezierPoint[] points = currentCurve.GetAnchorPoints();
                points[0].transform.position = startPos;
                points[points.Length - 1].transform.position = endPos;
            }

            if (enableRootMovement)
                timer += Time.deltaTime * 2;

            if(timer >= 0.99f)
            {
                timer = 1;
                waitToStartClimb = false;
                lockInput = false;
                enableRootMovement = false;
                initTransit = false;
                ikLandSideReached = false;
                currentState = targetState;
            }

            Vector3 targetPos = currentCurve.GetPointAt(timer);
            transform.position = targetPos;

            HandleWeightAll(timer, animMountCurve);

            HandleRotation();
        }

        void InitiateFallOff()
        {
            if(currentState == ClimbStates.onPoint)
            {
                if(Input.GetKeyDown(KeyCode.X))
                {
                    anim.SetBool("Climbing", false);
                    climbing = false;
                    initTransit = false;
                    ik.AddWeightInfluenceAll(0);
                    ToggleClimbingState(false);
                }
            }
        }

        void HandleClimbing()
        {
            if(!lockInput)
            {
                inputDirection = Vector3.zero;

                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                inputDirection = ConvertToInputDirection(h, v);

                if(inputDirection != Vector3.zero)
                {
                    switch (currentState)
                    {
                        case ClimbStates.onPoint:
                            OnPoint(inputDirection);
                            break;
                        case ClimbStates.betweenPoints:
                            BetweenPoints(inputDirection);
                            break;
                    }
                }

                transform.parent = currentPoint.transform.parent;

                if (currentState == ClimbStates.onPoint)
                {
                    ik.UpdateAllTargetPositions(currentPoint);
                    ik.ImmediatePlaceHelpers();
                }
            }
            else
            {
                InTransit(inputDirection);
            }
        }

        Vector3 ConvertToInputDirection(float horizontal, float vertical)
        {
            int h = (horizontal != 0) ? (horizontal < 0) ? -1 : 1 : 0;
            int v = (vertical != 0) ? (vertical < 0) ? -1 : 1 : 0;

            int z = v + h;

            z = (z != 0) ? (z < 0) ? -1 : 1 : 0;

            Vector3 convertedInputDirection = Vector3.zero;
            convertedInputDirection.x = h;
            convertedInputDirection.y = v;

            return convertedInputDirection;
        }

        void OnPoint(Vector3 inputDirection)
        {
            neighbor = null;
            neighbor = currentManager.ReturnNeighbor(inputDirection, currentPoint);

            if(neighbor != null)
            {
                targetPoint = neighbor.target;
                previousPoint = currentPoint;
                currentState = ClimbStates.inTransit;
                UpdateConnectionTransitionByType(neighbor, inputDirection);
                lockInput = true;
            }
        }

        void BetweenPoints(Vector3 inputDirecton)
        {
            Neighbor neighbor = targetPoint.ReturnNeighbor(previousPoint);

            if (neighbor != null)
            {
                if (inputDirection == neighbor.direction)
                    targetPoint = previousPoint;
            }
            else
            {
                targetPoint = currentPoint;
            }

            targetPosition = targetPoint.transform.position;
            currentState = ClimbStates.inTransit;
            targetState = ClimbStates.onPoint;
            previousPoint = currentPoint;
            lockInput = true;
            anim.SetBool("Move", false);
        }

        void InTransit(Vector3 inputDirection)
        {
            switch (currentConnection)
            {
                case ConnectionType.Inbetween:
                    UpdateLinearVariables();
                    LinearRootMovement();
                    LerpIKLandingSideLinear();
                    WrapUp();
                    break;
                case ConnectionType.Direct:
                    UpdateDirectVariables(inputDirection);
                    DirectRootMovement();
                    DirectHandleIK();
                    WrapUp(true);
                    break;
                case ConnectionType.Dismount:
                    HandleDismountVariables();
                    DismountRootMovement();
                    HandleDismountIK();
                    DismountWrapUp();
                    break;
            }
        }

        void UpdateConnectionTransitionByType(Neighbor neighbor, Vector3 inputDirection)
        {
            Vector3 desiredPos = Vector3.zero;
            currentConnection = neighbor.connectionType;

            Vector3 direction = targetPoint.transform.position - currentPoint.transform.position;
            direction.Normalize();

            switch (neighbor.connectionType)
            {
                // Connection is a 2 step (in-between)
                case ConnectionType.Inbetween:
                    float distance = Vector3.Distance(currentPoint.transform.position, targetPoint.transform.position);
                    // then our target position is in the middle of two points
                    desiredPos = currentPoint.transform.position + (direction * (distance / 4));
                    targetState = ClimbStates.betweenPoints;
                    TransitionDirection transitDir = ReturnTransitionDirection(inputDirection, false);
                    PlayAnim(transitDir);
                    break;
                case ConnectionType.Direct:
                    desiredPos = targetPoint.transform.position;
                    targetState = ClimbStates.onPoint;
                    TransitionDirection transitDir2 = ReturnTransitionDirection(direction, true);
                    PlayAnim(transitDir2, true);
                    break;
                case ConnectionType.Dismount:
                    desiredPos = targetPoint.transform.position;
                    anim.SetInteger("ClimbJumpType", 20);
                    anim.SetBool("Move", true);
                    break;
            }
            targetPosition = desiredPos;
        }

        #region Linear (2 Step)
        void UpdateLinearVariables()
        {
            if(!initTransit)
            {
                initTransit = true;
                enableRootMovement = true;
                rootReached = false;
                ikFollowSideReached = false;
                ikLandSideReached = false;
                timer = 0;
                startPos = transform.position;
                endPos = targetPosition + rootOffset;
                Vector3 directionToPoint = (endPos - startPos).normalized;

                bool twoStep = (targetState == ClimbStates.betweenPoints);
                Vector3 back = -transform.forward * .05f;
                if (twoStep)
                    endPos += back;

                distance = Vector3.Distance(endPos, startPos);
                InitIK(directionToPoint, !twoStep);
            }
        }

        void LinearRootMovement()
        {
            float speed = speedLinear * Time.deltaTime;
            float lerpSpeed = speed / distance;
            timer += lerpSpeed;

            if(timer > 1)
            {
                timer = 1;
                rootReached = true;
            }

            Vector3 currentPosition = Vector3.LerpUnclamped(startPos, endPos, timer);
            transform.position = currentPosition;

            HandleRotation();
        }

        void LerpIKLandingSideLinear()
        {
            float speed = speedLinear * Time.deltaTime;
            float lerpSpeed = speed / distance;

            landingIKTimer += lerpSpeed * 2;

            if(landingIKTimer > 1)
            {
                landingIKTimer = 1;
                ikLandSideReached = true;
            }

            Vector3 ikPosition = Vector3.LerpUnclamped(ikStartPos[0], ikEndPos[0], landingIKTimer);
            ik.UpdateTargetPosition(ikLandingSide, ikPosition);

            followingIKTimer += lerpSpeed * 2;
            if(followingIKTimer > 1)
            {
                followingIKTimer = 1;
                ikFollowSideReached = true;
            }
            Vector3 followSideIKPosition = Vector3.LerpUnclamped(ikStartPos[1], ikEndPos[1], followingIKTimer);
            ik.UpdateTargetPosition(ikFollowingSide, followSideIKPosition);
        }
        #endregion

        #region Direct (1 Step)
        void UpdateDirectVariables(Vector3 inputDirection)
        {
            if(!initTransit)
            {
                initTransit = true;
                enableRootMovement = false;
                rootReached = false;
                ikFollowSideReached = false;
                ikLandSideReached = false;
                timer = 0;
                rootMovementTimer = 0;
                endPos = targetPosition + rootOffset;
                startPos = transform.position;

                bool vertical = (Mathf.Abs(inputDirection.y) > 0.1f);
                currentCurve = (vertical) ? directCurveVertical : directCurveHorizontal;
                currentCurve.transform.rotation = currentPoint.transform.rotation;

                if(!vertical)
                {
                    if(!(inputDirection.x > 0))
                    {
                        Vector3 eulers = currentCurve.transform.eulerAngles;
                        eulers.y = -180;
                        currentCurve.transform.eulerAngles = eulers;
                    }
                }
                else
                {
                    if(!(inputDirection.y > 0))
                    {
                        Vector3 eulers = currentCurve.transform.eulerAngles;
                        eulers.x = 180;
                        eulers.y = 180;
                        currentCurve.transform.eulerAngles = eulers;
                    }
                }

                //Set the starting and ending points of the bezier curve
                BezierPoint[] points = currentCurve.GetAnchorPoints();
                points[0].transform.position = startPos;
                points[points.Length - 1].transform.position = endPos;

                InitIKDirect(inputDirection);
            }
        }

        void DirectRootMovement()
        {
            if(enableRootMovement)
            {
                timer += Time.deltaTime * speedDirect;
            }
            else
            {
                if (rootMovementTimer < rootMovementMax)
                    rootMovementTimer += Time.deltaTime;
                else
                    enableRootMovement = true;
            }

            if(timer > 0.95f)
            {
                timer = 1;
                rootReached = true;
            }

            HandleWeightAll(timer, animJumpingCurve);

            Vector3 targetPos = currentCurve.GetPointAt(timer);
            transform.position = targetPos;

            HandleRotation();
        }

        void DirectHandleIK()
        {
            if(inputDirection.y != 0)
            {
                LerpIKHandsDirect();
                LerpIKFeetDirect();
            }
            else
            {
                LerpIKLandingSideDirect();
                LerpIKFollowSideDirect();
            }
        }

        void LerpIKHandsDirect()
        {
            if (enableRootMovement)
                landingIKTimer += Time.deltaTime * 5;

            if(landingIKTimer > 1)
            {
                landingIKTimer = 1;
                ikLandSideReached = true;
            }

            Vector3 leftHandPosition = Vector3.LerpUnclamped(ikStartPos[0], ikEndPos[0], landingIKTimer);
            ik.UpdateTargetPosition(AvatarIKGoal.LeftHand, leftHandPosition);

            Vector3 rightHandPosition = Vector3.LerpUnclamped(ikStartPos[2], ikEndPos[2], landingIKTimer);
            ik.UpdateTargetPosition(AvatarIKGoal.RightHand, rightHandPosition);
        }

        void LerpIKFeetDirect()
        {
            if (enableRootMovement)
                followingIKTimer += Time.deltaTime * 5;
            if(followingIKTimer > 1)
            {
                followingIKTimer = 1;
                ikFollowSideReached = true;
            }

            Vector3 leftFootPosition = Vector3.LerpUnclamped(ikStartPos[1], ikEndPos[1], followingIKTimer);
            ik.UpdateTargetPosition(AvatarIKGoal.LeftFoot, leftFootPosition);

            Vector3 rightFootPosition = Vector3.LerpUnclamped(ikStartPos[3], ikEndPos[3], followingIKTimer);
            ik.UpdateTargetPosition(AvatarIKGoal.RightFoot, rightFootPosition);
        }

        void LerpIKLandingSideDirect()
        {
            if(enableRootMovement)
                landingIKTimer += Time.deltaTime * 2.6f;

            if(landingIKTimer > 1)
            {
                landingIKTimer = 1;
                ikLandSideReached = true;
            }

            Vector3 landPosition = Vector3.LerpUnclamped(ikStartPos[0], ikEndPos[0], landingIKTimer);
            ik.UpdateTargetPosition(ikLandingSide, landPosition);

            Vector3 followPosition = Vector3.LerpUnclamped(ikStartPos[1], ikEndPos[1], landingIKTimer);
            ik.UpdateTargetPosition(ikFollowingSide, followPosition);
        }
        
        void LerpIKFollowSideDirect()
        {
            if (enableRootMovement)
                followingIKTimer += Time.deltaTime * 1.8f;

            if(followingIKTimer > 1)
            {
                followingIKTimer = 1;
                ikFollowSideReached = true;
            }

            Vector3 landPosition = Vector3.LerpUnclamped(ikStartPos[2], ikEndPos[2], followingIKTimer);
            ik.UpdateTargetPosition(ik.ReturnOppositeIK(ikLandingSide), landPosition);

            Vector3 followPosition = Vector3.LerpUnclamped(ikStartPos[3], ikEndPos[3], followingIKTimer);
            ik.UpdateTargetPosition(ik.ReturnOppositeIK(ikFollowingSide), followPosition);
        }
        #endregion

        #region Dismount
        void HandleDismountVariables()
        {
            if(!initTransit)
            {
                initTransit = true;
                rootReached = false;
                ikLandSideReached = false;
                ikFollowSideReached = false;
                timer = 0;
                startPos = transform.position;
                endPos = targetPosition;

                currentCurve = dismountCurve;
                BezierPoint[] points = currentCurve.GetAnchorPoints();
                currentCurve.transform.rotation = transform.rotation;
                points[0].transform.position = startPos;
                points[points.Length - 1].transform.position = endPos;

                landingIKTimer = 0;
                followingIKTimer = 0;
            }
        }

        void DismountRootMovement()
        {
            if (enableRootMovement)
                timer += Time.deltaTime / 0.5f;

            if(timer >= 0.99f)
            {
                timer = 1;
                rootReached = true;
            }

            Vector3 targetPos = currentCurve.GetPointAt(timer);
            transform.position = targetPos;
        }

        void HandleDismountIK()
        {
            if (enableRootMovement)
                landingIKTimer += Time.deltaTime;

            followingIKTimer += Time.deltaTime;

            HandleIKWeightDismount(landingIKTimer, followingIKTimer, 1, 0);
        }

        void HandleIKWeightDismount(float handTimer, float footTimer, float from, float to)
        {
            float t1 = handTimer * 6;

            if(t1 > 1)
            {
                t1 = 1;
                ikLandSideReached = true;
            }

            float handsWeight = Mathf.Lerp(from, to, t1);
            ik.InfluenceWeight(AvatarIKGoal.LeftHand, handsWeight);
            ik.InfluenceWeight(AvatarIKGoal.RightHand, handsWeight);

            float t2 = footTimer * 6;

            if(t2 > 1)
            {
                t2 = 1;
                ikFollowSideReached = true;
            }

            float feetWeight = Mathf.Lerp(from, to, t2);
            ik.InfluenceWeight(AvatarIKGoal.LeftFoot, feetWeight);
            ik.InfluenceWeight(AvatarIKGoal.RightFoot, feetWeight);
        }

        void DismountWrapUp()
        {
            if(rootReached)
            {
                anim.SetInteger("ClimbJumpType", 0);
                anim.SetBool("Move", false);
                climbing = false;
                initTransit = false;
                enableRootMovement = false;
                anim.SetBool("Climbing", false);
                ToggleClimbingState(false);
            }
        }
        #endregion

        #region Universal
        bool waitforWrapUp;

        void WrapUp(bool direct = false)
        {
            if(rootReached)
            {
                if (!anim.GetBool("Jump"))
                {
                    if (!waitforWrapUp)
                    {
                        StartCoroutine(WrapUpTransition(0.05f));

                        waitforWrapUp = true;
                    }
                }
            }
        }

        IEnumerator WrapUpTransition(float t)
        {
            yield return new WaitForSeconds(t);
            currentState = targetState;

            if (currentState == ClimbStates.onPoint)
                currentPoint = targetPoint;

            initTransit = false;
            lockInput = false;
            enableRootMovement = false;
            inputDirection = Vector3.zero;
            waitforWrapUp = false;

        }

        void HandleRotation()
        {
            Vector3 targetDir = targetPoint.transform.forward;
            if (targetDir == Vector3.zero)
                targetDir = transform.forward;

            Quaternion targetRot = Quaternion.LookRotation(targetDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 5);
        }

        TransitionDirection ReturnTransitionDirection(Vector3 inputDirection, bool jump)
        {
            TransitionDirection transitionDirection = default(TransitionDirection);

            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;

            if (!jump)
            {
                if (Mathf.Abs(inputDirection.y) > 0)
                {
                    transitionDirection = TransitionDirection.move_vertical;
                }
                else
                {
                    transitionDirection = TransitionDirection.move_horizontal;
                }
            }
            else
            {
                if (targetAngle < 22.5f && targetAngle > -22.5f)
                    transitionDirection = TransitionDirection.jump_up;
                else if (targetAngle < 180 + 22.5f && targetAngle > 180 - 22.5f)
                    transitionDirection = TransitionDirection.jump_down;
                else if (targetAngle < 90 + 22.5f && targetAngle > 90 - 22.5f)
                    transitionDirection = TransitionDirection.jump_right;
                else if (targetAngle < -90 + 22.5f && targetAngle > 90 - 22.5f)
                    transitionDirection = TransitionDirection.jump_left;

                if (Mathf.Abs(inputDirection.y) > Mathf.Abs(inputDirection.x))
                {
                    if (inputDirection.y < 0)
                        transitionDirection = TransitionDirection.jump_down;
                    else
                        transitionDirection = TransitionDirection.jump_up;
                }
            }

            return transitionDirection;
        }

        enum TransitionDirection
        {
            move_horizontal, move_vertical, jump_up, jump_down, jump_left, jump_right
        }
        #endregion

        #region IK Methods/Handling
        AvatarIKGoal ikLandingSide;
        AvatarIKGoal ikFollowingSide;
        float landingIKTimer;
        float followingIKTimer;

        Vector3[] ikStartPos = new Vector3[4];
        Vector3[] ikEndPos = new Vector3[4];

        void InitIK(Vector3 directionToPoint, bool opposite)
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(directionToPoint);

            if(Mathf.Abs(relativeDirection.y) > 0.1f)
            {
                float targetAnim = 0;

                if(targetState == ClimbStates.onPoint)
                {
                    ikLandingSide = ik.ReturnOppositeIK(ikLandingSide);
                }
                else
                {
                    if(Mathf.Abs(relativeDirection.x) > 0)
                    {
                        if (relativeDirection.x < 0)
                            ikLandingSide = AvatarIKGoal.LeftHand;
                        else
                            ikLandingSide = AvatarIKGoal.RightHand;
                    }

                    targetAnim = (ikLandingSide == AvatarIKGoal.RightHand) ? 1 : 0;
                    if (relativeDirection.y < 0)
                        targetAnim = (ikLandingSide == AvatarIKGoal.RightHand) ? 0 : 1;

                    anim.SetFloat("Movement", targetAnim);
                }
            }
            else
            {
                ikLandingSide = (relativeDirection.x < 0) ? AvatarIKGoal.LeftHand : AvatarIKGoal.RightHand;

                if (opposite)
                    ikLandingSide = ik.ReturnOppositeIK(ikLandingSide);
            }

            landingIKTimer = 0;
            UpdateIKTarget(0, ikLandingSide, targetPoint);

            ikFollowingSide = ik.ReturnOppositeLimb(ikLandingSide);
            followingIKTimer = 0;
            UpdateIKTarget(1, ikFollowingSide, targetPoint);
        }


        void InitIKDirect(Vector3 directionToPoint)
        {
            if(directionToPoint.y != 0)
            {
                followingIKTimer = 0;
                landingIKTimer = 0;

                UpdateIKTarget(0, AvatarIKGoal.LeftHand, targetPoint);
                UpdateIKTarget(1, AvatarIKGoal.LeftFoot, targetPoint);
                UpdateIKTarget(2, AvatarIKGoal.RightHand, targetPoint);
                UpdateIKTarget(3, AvatarIKGoal.RightFoot, targetPoint);
            }
            else
            {
                InitIK(directionToPoint, false);
                InitIKOpposite();
            }
        }

        void InitIKOpposite()
        {
            UpdateIKTarget(2, ik.ReturnOppositeIK(ikLandingSide), targetPoint);
            UpdateIKTarget(3, ik.ReturnOppositeIK(ikFollowingSide), targetPoint);
        }

        void UpdateIKTarget(int posIndex, AvatarIKGoal ikGoal, Point targetPoint)
        {
            ikStartPos[posIndex] = ik.ReturnCurrentPointPosition(ikGoal);
            ikEndPos[posIndex] = targetPoint.ReturnIK(ikGoal).target.transform.position;
            ik.UpdatePoint(ikGoal, targetPoint);
        }

        void HandleWeightAll(float t, AnimationCurve aCurve)
        {
            float inf = aCurve.Evaluate(t);
            ik.AddWeightInfluenceAll(1 - inf);
        }
        #endregion

        #region Animations
        void PlayAnim(TransitionDirection dir, bool jump = false)
        {
            int target = 0;

            switch (dir)
            {
                case TransitionDirection.move_horizontal:
                    target = 5;
                    break;
                case TransitionDirection.move_vertical:
                    target = 6;
                    break;
                case TransitionDirection.jump_up:
                    target = 0;
                    break;
                case TransitionDirection.jump_down:
                    target = 1;
                    break;
                case TransitionDirection.jump_left:
                    target = 3;
                    break;
                case TransitionDirection.jump_right:
                    target = 2;
                    break;
            }

            anim.SetInteger("ClimbJumpType", target);
            if (!jump)
                anim.SetBool("Move", true);
            else
                anim.SetBool("Jump", true);
        }
        #endregion

        void ToggleClimbingState(bool on)
        {
            GetComponentInChildren<CapsuleCollider>().enabled = !on;
            GetComponent<Rigidbody>().detectCollisions = !on;
            GetComponent<Rigidbody>().useGravity = !on;
            GetComponentInChildren<PlayerSquishCheck>().enabled = !on;
            GetComponent<PlayerAnimator>().enabled = !on;
            GetComponent<PlayerController>().enabled = !on;
            GetComponent<PlayerMotor>().enabled = !on;
            if (on)
            {
                //PlayerShadowInteraction.m_CurrentPlayerState = PlayerShadowInteraction.PlayerState.Climbing;
                GetComponent<Rigidbody>().Sleep();
            }
            else
            {
                PlayerShadowInteraction.m_CurrentPlayerState = PlayerShadowInteraction.PlayerState.Form;
                GetComponent<Rigidbody>().WakeUp();
            }
        }
    }
}
