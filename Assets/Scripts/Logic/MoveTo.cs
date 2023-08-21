using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    
    void Update()
    {
        transform.position += _direction;
    }
}
