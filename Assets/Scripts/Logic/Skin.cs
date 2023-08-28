using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Skin : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
        if (gameObject.GetComponentInParent<PlayerMovement>() != null)
        {
            PlayerMovement.Instance.Animator = _animator;
            return;
        }
    }
}
