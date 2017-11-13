#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Climbing
{
    [CustomEditor(typeof(DrawWireSphere))]
    public class DrawWireSphereEditor : Editor
    {
        void OnSceneGUI()
        {
            DrawWireSphere selectedObject = target as DrawWireSphere;

            if (selectedObject == null)
                return;

            if(selectedObject.ikPos.Count == 0)
            {
                selectedObject.ikPos = selectedObject.transform.GetComponent<Point>().iks;
            }

            foreach(IKPositions ikPosition in selectedObject.ikPos)
            {
                if(ikPosition.target != null)
                {
                    Color targetColor = Color.red;

                    switch (ikPosition.ik)
                    {
                        case AvatarIKGoal.LeftFoot:
                            targetColor = Color.magenta;
                            break;
                        case AvatarIKGoal.RightFoot:
                            targetColor = Color.cyan;
                            break;
                        case AvatarIKGoal.LeftHand:
                            targetColor = Color.green;
                            break;
                        case AvatarIKGoal.RightHand:
                            targetColor = Color.yellow;
                            break;
                        default:
                            break;
                    }

                    Handles.color = targetColor;

                    Handles.CubeHandleCap(0, ikPosition.target.position, ikPosition.target.rotation, 0.1f, EventType.Repaint);

                    if (ikPosition.hint != null)
                    {
                        Handles.CubeHandleCap(0, ikPosition.hint.position, ikPosition.hint.rotation, 0.1f, EventType.Repaint);
                    }
                }
                else
                {
                    selectedObject.ikPos = selectedObject.transform.GetComponent<Point>().iks;
                }
            }
        }
    }

    [CustomEditor(typeof(DrawLineIndividual))]
    public class DrawLineIndividualEditor : Editor
    {
        void OnSceneGUI()
        {
            DrawLineIndividual selectedObject = target as DrawLineIndividual;

            if (selectedObject == null)
                return;

            if (selectedObject.connectedPoints.Count == 0)
            {
                selectedObject.connectedPoints.AddRange(selectedObject.transform.GetComponent<Point>().neighbors);
            }

            foreach (Neighbor connectedPoint in selectedObject.connectedPoints)
            {
                if (connectedPoint.target == null)
                    continue;

                Vector3 pos1 = selectedObject.transform.position;
                Vector3 pos2 = connectedPoint.target.transform.position;

                switch (connectedPoint.connectionType)
                {
                    case ConnectionType.Inbetween:
                        Handles.color = Color.cyan;
                        break;
                    case ConnectionType.Direct:
                        Handles.color = Color.yellow;
                        break;
                }

                Handles.DrawLine(pos1, pos2);
                selectedObject.refresh = false;
            }
        }
    }

    [CustomEditor(typeof(DrawLine))]
    public class DrawConnectionsEditor : Editor
    {
        void OnSceneGUI()
        {
            DrawLine selectedObject = target as DrawLine;

            if (selectedObject == null)
                return;

            if (selectedObject.connectedPoints.Count == 0)
            {
                selectedObject.connectedPoints.AddRange(selectedObject.GetComponent<HandlePointsConnections>().GetAllConnections());
            }

            foreach (Connection currentConnection in selectedObject.connectedPoints)
            {
                Vector3 pos1 = currentConnection.target1.transform.position;
                Vector3 pos2 = currentConnection.target2.transform.position;

                switch (currentConnection.connectionType)
                {
                    case ConnectionType.Inbetween:
                        Handles.color = Color.cyan;
                        break;
                    case ConnectionType.Direct:
                        Handles.color = Color.yellow;
                        break;
                }

                Handles.DrawLine(pos1, pos2);

                selectedObject.refresh = false;
            }
        }
    }
}
#endif
