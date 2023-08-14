using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask blocks;

    public float Speed { get; set; }
    public int Damage { get; set; }
    public LayerMask enemyMask { get; set; }

    private void Start()
    {
        Destroy(gameObject, 4);
    }

    void Update()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isEncountered = Physics.OverlapSphere(transform.position, 0.2f, blocks).Length > 0.8F;
        if (other.GetComponent<Unit>() != null && isEncountered)
        {
            other.GetComponent<Unit>().ReceiveDamage(Damage);
            Destroy(gameObject);
        }

        if (isEncountered)
            Destroy(gameObject);
    }
}