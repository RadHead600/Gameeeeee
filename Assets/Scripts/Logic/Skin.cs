using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Skin : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
        if (gameObject.GetComponentInParent<PlayerMovement>() != null)
            gameObject.GetComponentInParent<PlayerMovement>().Animator = _animator;
    }
}
