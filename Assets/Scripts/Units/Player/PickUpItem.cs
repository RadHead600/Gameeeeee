using DG.Tweening;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private LayerMask _itemLayers;
    [SerializeField] private float _timeToPlayer;
    [SerializeField] private float _magniteRange;
    [SerializeField] private float _upItemRange;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _magniteRange, _itemLayers);
        foreach (var collider in colliders)
        {
            Item item = collider.gameObject.GetComponent<Item>();
            item.gameObject.layer = 0;
            item.Active();
            item.Tween.SetAutoKill(false);
            item.Tween = item.transform.DOMove(transform.position, _timeToPlayer)
                .OnUpdate(() =>
                {
                    if ((item.transform.position - transform.position).sqrMagnitude <= _upItemRange)
                    {
                        Destroy(item.gameObject);
                        return;
                    }
                    item.Tween.ChangeEndValue(transform.position, true);
                });
        }
    }
}
