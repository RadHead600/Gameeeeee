using DG.Tweening;
using UnityEngine;

public class PlayerMovement : PlayerController, IMove
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private UnitParameters _unitParameters;
    [SerializeField] Joystick _moveJoystick;

    private Vector3 _moveVector;
    private Vector3 _fwd, _right;

    public Vector3 MoveVector => _moveVector;

    private void Start()
    {
        RecalculateCamera(Camera.main);
    }

    private void Update()
    {
        Debug.Log(HealthPoints);
        Move();
        JoystickMove();
    }

    public void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * Speed;
        _moveVector.y = _characterController.isGrounded ? 0 : -1;
        _moveVector.z = Input.GetAxis("Vertical") * Speed;

        _characterController.Move(_moveVector * Time.deltaTime);

        if (!LookAt.IsLookedAt)
        {
            Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movementDirection.Normalize();
            Direction(movementDirection);
        }
    }

    void RecalculateCamera(Camera _cam)
    {
        Camera cam = _cam;
        _fwd = cam.transform.forward;
        _fwd.y = 0;
        _fwd = Vector3.Normalize(_fwd);
        _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _fwd;
    }
    void JoystickMove()
    {
        Vector3 rightMovement = _right * Speed * Time.deltaTime * _moveJoystick.Direction.x;
        Vector3 upMovement = _fwd * Speed * Time.deltaTime * _moveJoystick.Direction.y;
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        _characterController.Move(heading * Speed * Time.deltaTime);
        if (!LookAt.IsLookedAt)
            Direction(heading);
    }

    private void Direction(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
            transform.DOLookAt(movementDirection + transform.position, _unitParameters.DirectionTime);
    }
}
