using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class LookAt : MonoBehaviour
{
    [SerializeField] private Attack _unitAttack;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private UnitParameters _unitParameters;
    [SerializeField] private float minTriggerDistance;

    private SphereCollider _sphereCollider;
    public static bool IsLookedAt { get; private set; }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = minTriggerDistance;
        _sphereCollider.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Unit>() == null)
            return;
        if ((1 << other.gameObject.layer) != _layerMask.value)
            return;
        Vector3 LookPos = new Vector3(other.gameObject.transform.position.x, gameObject.transform.position.y, other.gameObject.transform.position.z);

        transform.DOLookAt(LookPos, _unitParameters.DirectionTime);
        _unitAttack.Shoot();
        IsLookedAt = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsLookedAt = false;
    }
}
