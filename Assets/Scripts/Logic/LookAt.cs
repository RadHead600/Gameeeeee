using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class LookAt : MonoBehaviour
{
    [SerializeField] private Attack _unitAttack;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private UnitParameters _unitParameters;
    [SerializeField] private float _minTriggerDistance;
    [SerializeField] private SphereCollider _sphereCollider;

    private GameObject _triggerObject;
    private Tween _tween;
    private Vector3 _lookAt;

    private void Awake()
    {
        _lookAt = Vector3.zero;
        _tween.SetAutoKill(false);
        _sphereCollider.radius = _minTriggerDistance;
        _sphereCollider.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if ((1 << other.gameObject.layer) != _layerMask.value)
            return;
        if (_lookAt == Vector3.zero)
            _lookAt = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        if (_triggerObject != null && _tween != null && _tween.active)
        {
            _lookAt = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            return;
        }
        _tween = transform.DODynamicLookAt(_lookAt, _unitParameters.DirectionTime);
        Debug.DrawLine(transform.position, _lookAt, Color.red);

        _triggerObject = other.gameObject;
        if (_unitAttack.enabled)
            _unitAttack.Shoot();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_triggerObject != null && _triggerObject.Equals(other.gameObject))
            _triggerObject = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _minTriggerDistance);
    }
}
