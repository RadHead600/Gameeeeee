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

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = minTriggerDistance;
        _sphereCollider.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if ((1 << other.gameObject.layer) != _layerMask.value)
            return;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit);
        Debug.DrawLine(ray.origin, hit.point, Color.red);
        Vector3 lookAt = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        transform.DOLookAt(lookAt, _unitParameters.DirectionTime);
        if (_unitAttack.enabled)
            _unitAttack.Shoot();
    }
}
