using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementContext : MonoBehaviour
{
    //variable
    [SerializeField] private CharacterController _characterController; // ref to player character controller.
    [SerializeField] private float _playerMovementSpeed; 
    [SerializeField] private float _runMultiplier = 1.5f;
    private bool _isSprinting;

    private Vector2 _movementInputVector;// 2-d vector to take input from joystick
    private Vector3 _playerMovementVector;// converted the 2-d input intoa 3-d vector for player movement
    private Vector3 _isoPlayerMovementVector;// corrected Player movement to isometric view 

    //refs
    private PlayerControlls _playerControls; // ref to generated C# class by input system

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerControls = new PlayerControlls();
    }
    // Start is called before the first frame update
    void Start()
    {

        _playerControls.PlayerMovement.Move.performed += ctx => _movementInputVector = ctx.ReadValue<Vector2>(); //subsribing to player controls while input is performed
        _playerControls.PlayerMovement.Move.canceled += ctx => _movementInputVector = Vector2.zero; // unsubscribing if input is cancelled

        _playerControls.PlayerMovement.Sprint.performed += ctx => _isSprinting = true;
        _playerControls.PlayerMovement.Sprint.canceled += ctx => _isSprinting = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        _playerMovementVector = new Vector3(_movementInputVector.x, 0, _movementInputVector.y);

        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));// matrix used for converting player movement to isometric


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

    //for new input system it is mandatory to enable and disable manually.
    private void OnEnable()
    {
        _playerControls.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        _playerControls.PlayerMovement.Disable();
    }
}
