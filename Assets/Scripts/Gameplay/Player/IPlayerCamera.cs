using UnityEngine;

using Cinemachine;

public interface ICharacterCamera
{
    CinemachineFreeLook Freelook { get; set; }

    Camera Camera { get; set; }

    Transform TargetTransform { get; set; }

    Collider[] IgnoredColliders { get; set; }

    void SetFollowTransform(Transform targetTransform);

    void AddIgnoredCollider(Collider ignoredCollider);

    void RemoveIgnoredCollider(Collider ignoredCollider);

    void SetIgnoredColliders(Collider[] ignoredColliders);
}
