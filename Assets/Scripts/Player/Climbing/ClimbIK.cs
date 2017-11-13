using UnityEngine;
using System.Collections;

namespace Climbing
{
    public class ClimbIK : MonoBehaviour
    {
        Animator anim;

        Point leftHandPoint;
        Point rightHandPoint;
        Point leftFootPoint;
        Point rightFootPoint;

        public float leftHandWeight = 1;
        public float rightHandWeight = 1;
        public float leftFootWeight = 1;
        public float rightFootWeight = 1;

        Transform leftHandHelper;
        Transform rightHandHelper;
        Transform leftFootHelper;
        Transform rightFootHelper;

        Vector3 leftHandTargetPosition;
        Vector3 rightHandTargetPosition;
        Vector3 leftFootTargetPosition;
        Vector3 rightFootTargetPosition;

        public float helperSpeed = 15;

        Transform hips;

        public bool forceFeetHeight;

        void Start()
        {
            anim = GetComponentInChildren<Animator>();
            hips = anim.GetBoneTransform(HumanBodyBones.Hips);

            leftHandHelper = new GameObject().transform;
            leftHandHelper.name = "Left_Hand_Helper_IK";
            rightHandHelper = new GameObject().transform;
            rightHandHelper.name = "Right_Hand_Helper_IK";
            leftFootHelper = new GameObject().transform;
            leftFootHelper.name = "Left_Foot_Helper_IK";
            rightFootHelper = new GameObject().transform;
            rightFootHelper.name = "Right_Foot_Helper_IK";
        }

        public void UpdateAllPointsOnOne(Point targetPoint)
        {
            leftHandPoint = targetPoint;
            rightHandPoint = targetPoint;
            leftFootPoint = targetPoint;
            rightFootPoint = targetPoint;
        }

        public void UpdatePoint(AvatarIKGoal ik, Point targetPoint)
        {
            switch (ik)
            {
                case AvatarIKGoal.LeftFoot:
                    leftFootPoint = targetPoint;
                    break;
                case AvatarIKGoal.RightFoot:
                    rightFootPoint = targetPoint;
                    break;
                case AvatarIKGoal.LeftHand:
                    leftHandPoint = targetPoint;
                    break;
                case AvatarIKGoal.RightHand:
                    rightHandPoint = targetPoint;
                    break;
            }
        }

        public void UpdateAllTargetPositions(Point targetPoint)
        {
            IKPositions leftHandHolder = targetPoint.ReturnIK(AvatarIKGoal.LeftHand);
            if (leftHandHolder.target)
                leftHandTargetPosition = leftHandHolder.target.position;

            IKPositions rightHandHolder = targetPoint.ReturnIK(AvatarIKGoal.RightHand);
            if (rightHandHolder.target)
                rightHandTargetPosition = rightHandHolder.target.position;

            IKPositions leftFootHolder = targetPoint.ReturnIK(AvatarIKGoal.LeftFoot);
            if (leftFootHolder.target)
                leftFootTargetPosition = leftFootHolder.target.position;

            IKPositions rightFootHolder = targetPoint.ReturnIK(AvatarIKGoal.RightFoot);
            if (rightFootHolder.target)
                rightFootTargetPosition = rightFootHolder.target.position;
        }

        public void UpdateTargetPosition(AvatarIKGoal ik, Vector3 targetPosition)
        {
            switch (ik)
            {
                case AvatarIKGoal.LeftFoot:
                    leftFootTargetPosition = targetPosition;
                    break;
                case AvatarIKGoal.RightFoot:
                    rightFootTargetPosition = targetPosition;
                    break;
                case AvatarIKGoal.LeftHand:
                    leftHandTargetPosition = targetPosition;
                    break;
                case AvatarIKGoal.RightHand:
                    rightHandTargetPosition = targetPosition;
                    break;
            }
        }

        public Vector3 ReturnCurrentPointPosition(AvatarIKGoal ik)
        {
            Vector3 currentPointPosition = default(Vector3);

            switch (ik)
            {
                case AvatarIKGoal.LeftFoot:
                    IKPositions leftFootHolder = leftFootPoint.ReturnIK(AvatarIKGoal.LeftFoot);
                    currentPointPosition = leftFootHolder.target.transform.position;
                    break;
                case AvatarIKGoal.RightFoot:
                    IKPositions rightFootHolder = rightFootPoint.ReturnIK(AvatarIKGoal.RightFoot);
                    currentPointPosition = rightFootHolder.target.transform.position;
                    break;
                case AvatarIKGoal.LeftHand:
                    IKPositions leftHandHolder = leftHandPoint.ReturnIK(AvatarIKGoal.LeftHand);
                    currentPointPosition = leftHandHolder.target.transform.position;
                    break;
                case AvatarIKGoal.RightHand:
                    IKPositions rightHandHolder = rightHandPoint.ReturnIK(AvatarIKGoal.RightHand);
                    currentPointPosition = rightHandHolder.target.transform.position;
                    break;
            }
            return currentPointPosition;
        }

        public Point ReturnPointForIK(AvatarIKGoal ik)
        {
            Point pointForIK = null;

            switch (ik)
            {
                case AvatarIKGoal.LeftFoot:
                    pointForIK = leftFootPoint;
                    break;
                case AvatarIKGoal.RightFoot:
                    pointForIK = rightFootPoint;
                    break;
                case AvatarIKGoal.LeftHand:
                    pointForIK = leftHandPoint;
                    break;
                case AvatarIKGoal.RightHand:
                    pointForIK = rightHandPoint;
                    break;
            }
            return pointForIK;
        }

        public AvatarIKGoal ReturnOppositeIK(AvatarIKGoal ik)
        {
            AvatarIKGoal oppositeIK = default(AvatarIKGoal);

            switch (ik)
            {
                case AvatarIKGoal.LeftFoot:
                    oppositeIK = AvatarIKGoal.RightFoot;
                    break;
                case AvatarIKGoal.RightFoot:
                    oppositeIK = AvatarIKGoal.LeftFoot;
                    break;
                case AvatarIKGoal.LeftHand:
                    oppositeIK = AvatarIKGoal.RightHand;
                    break;
                case AvatarIKGoal.RightHand:
                    oppositeIK = AvatarIKGoal.LeftHand;
                    break;
            }
            return oppositeIK;
        }

        public AvatarIKGoal ReturnOppositeLimb(AvatarIKGoal ik)
        {
            AvatarIKGoal oppositeLimb = default(AvatarIKGoal);

            switch (ik)
            {
                case AvatarIKGoal.LeftFoot:
                    oppositeLimb = AvatarIKGoal.LeftHand;
                    break;
                case AvatarIKGoal.RightFoot:
                    oppositeLimb = AvatarIKGoal.RightHand;
                    break;
                case AvatarIKGoal.LeftHand:
                    oppositeLimb = AvatarIKGoal.LeftFoot;
                    break;
                case AvatarIKGoal.RightHand:
                    oppositeLimb = AvatarIKGoal.RightFoot;
                    break;
            }
            return oppositeLimb;
        }

        public void AddWeightInfluenceAll(float weight)
        {
            leftHandWeight = weight;
            rightHandWeight = weight;
            leftFootWeight = weight;
            rightFootWeight = weight;
        }

        public void ImmediatePlaceHelpers()
        {
            if (leftHandPoint != null)
                leftHandHelper.position = leftHandTargetPosition;
            if (rightHandPoint != null)
                rightHandHelper.position = rightHandTargetPosition;
            if (leftFootPoint != null)
                leftFootHelper.position = leftFootTargetPosition;
            if (rightFootPoint != null)
                rightFootHelper.position = rightFootTargetPosition;
        }

        void OnAnimatorIK()
        {
            if(leftHandPoint)
            {
                IKPositions leftHandHolder = leftHandPoint.ReturnIK(AvatarIKGoal.LeftHand);

                if (leftHandHolder.target)
                    leftHandHelper.transform.position = Vector3.Lerp(leftHandHelper.transform.position, leftHandTargetPosition, Time.deltaTime * helperSpeed);
                UpdateIK(AvatarIKGoal.LeftHand, leftHandHolder, leftHandHelper, leftHandWeight, AvatarIKHint.LeftElbow);
            }

            if(rightHandPoint)
            {
                IKPositions rightHandHolder = rightHandPoint.ReturnIK(AvatarIKGoal.RightHand);

                if (rightHandHolder.target)
                    rightHandHelper.transform.position = Vector3.Lerp(rightHandHelper.transform.position, rightHandTargetPosition, Time.deltaTime * helperSpeed);

                UpdateIK(AvatarIKGoal.RightHand, rightHandHolder, rightHandHelper, rightHandWeight, AvatarIKHint.RightElbow);
            }

            if (hips == null)
                hips = anim.GetBoneTransform(HumanBodyBones.Hips);

            if(leftFootPoint)
            {
                IKPositions leftFootHolder = leftFootPoint.ReturnIK(AvatarIKGoal.LeftFoot);

                if(leftFootHolder.target)
                {
                    Vector3 targetPosition = leftFootTargetPosition;

                    //Places foot lower than the hips
                    if(forceFeetHeight)
                    {
                        if(targetPosition.y > hips.transform.position.y)
                        {
                            targetPosition.y = targetPosition.y - 0.2f;
                        }
                    }

                    leftFootHelper.transform.position = Vector3.Lerp(leftFootHelper.transform.position, targetPosition, Time.deltaTime * helperSpeed);
                }
                UpdateIK(AvatarIKGoal.LeftFoot, leftFootHolder, leftFootHelper, leftFootWeight, AvatarIKHint.LeftKnee);
            }

            if (rightFootPoint)
            {
                IKPositions rightFootHolder = rightFootPoint.ReturnIK(AvatarIKGoal.RightFoot);

                if (rightFootHolder.target)
                {
                    Vector3 targetPosition = rightFootTargetPosition;

                    //Places foot lower than the hips
                    if (forceFeetHeight)
                    {
                        if (targetPosition.y > hips.transform.position.y)
                        {
                            targetPosition.y = targetPosition.y - 0.2f;
                        }
                    }

                    rightFootHelper.transform.position = Vector3.Lerp(rightFootHelper.transform.position, targetPosition, Time.deltaTime * helperSpeed);
                }
                UpdateIK(AvatarIKGoal.RightFoot, rightFootHolder, rightFootHelper, rightFootWeight, AvatarIKHint.RightKnee);
            }
        }

        void UpdateIK(AvatarIKGoal ik, IKPositions holder, Transform helper, float weight, AvatarIKHint hint)
        {
            if(holder != null)
            {
                anim.SetIKPositionWeight(ik, weight);
                anim.SetIKRotationWeight(ik, weight);
                anim.SetIKPosition(ik, helper.position);
                anim.SetIKRotation(ik, helper.rotation);

                if(ik == AvatarIKGoal.LeftHand || ik == AvatarIKGoal.RightHand)
                {
                    Transform shoulder = (ik == AvatarIKGoal.LeftHand) ?
                        anim.GetBoneTransform(HumanBodyBones.LeftShoulder) :
                        anim.GetBoneTransform(HumanBodyBones.RightShoulder);

                    Vector3 targetRotationDir = shoulder.transform.position - helper.transform.position;
                    Quaternion targetRot = Quaternion.LookRotation(-targetRotationDir);
                    helper.rotation = targetRot;
                }
                else
                {
                    helper.rotation = holder.target.transform.rotation;
                }

                if(holder.hint != null)
                {
                    anim.SetIKHintPositionWeight(hint, weight);
                    anim.SetIKHintPosition(hint, holder.hint.position);
                }
            }
        }

        public void InfluenceWeight(AvatarIKGoal ik, float weight)
        {
            switch (ik)
            {
                case AvatarIKGoal.LeftFoot:
                    leftFootWeight = weight;
                    break;
                case AvatarIKGoal.RightFoot:
                    rightFootWeight = weight;
                    break;
                case AvatarIKGoal.LeftHand:
                    leftHandWeight = weight;
                    break;
                case AvatarIKGoal.RightHand:
                    rightHandWeight = weight;
                    break;
            }
        }
    }
}


