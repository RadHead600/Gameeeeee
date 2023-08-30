using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Skin : MonoBehaviour
{
    [SerializeField] private RagdollController _ragdollController;

    public Animator Animator { get; private set; }
    public RagdollController RagdollController => _ragdollController;

    private void Awake()
    {
        if (Animator == null)
            Animator = GetComponent<Animator>();
    }
}
