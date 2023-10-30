using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementContext : MonoBehaviour
{
    //variable
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _playerMovementSpeed;
    [SerializeField] private float _runMultiplier = 1.5f;
    private Vector2 _movementInputVector;
    private bool _isSprinting;
    private Vector3 _playerMovementVector;
    private Vector3 _isoPlayerMovementVector;

    //refs
    private PlayerControlls _playerControls;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerControls = new PlayerControlls();
    }
    // Start is called before the first frame update
    void Start()
    {

        _playerControls.PlayerMovement.Move.performed += ctx => _movementInputVector = ctx.ReadValue<Vector2>();
        _playerControls.PlayerMovement.Move.canceled += ctx => _movementInputVector = Vector2.zero;
        _playerControls.PlayerMovement.Sprint.performed += ctx => _isSprinting = true;
        _playerControls.PlayerMovement.Sprint.canceled += ctx => _isSprinting = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        _playerMovementVector = new Vector3(_movementInputVector.x, 0, _movementInputVector.y);

        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        

        if (_isSprinting)
        {
            _isoPlayerMovementVector = matrix.MultiplyPoint3x4(_playerMovementVector) * _runMultiplier;
        }
        else
        {
            _isoPlayerMovementVector = matrix.MultiplyPoint3x4(_playerMovementVector);
        }

        _characterController.Move(_isoPlayerMovementVector * _playerMovementSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _playerControls.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        _playerControls.PlayerMovement.Disable();
    }
}
