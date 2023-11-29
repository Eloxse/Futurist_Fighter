using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _turnSmoothSpeed = 1f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _gravity = 6f;
    [SerializeField] private float _distanceMaxLanding = 10f;

    private bool _canMove = true;
    private bool _isBigLanding = false;
    private float _distanceToGround;
    private float _verticalSpeed;
    private float _currentVelocity;

    private Vector3 _movement = Vector3.zero;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _moveDirection = Vector3.zero;

    private CharacterController _characterController;
    private Camera _camera;
    private Player_Inputs _inputs;
    private Animator _animator;
    #endregion

    #region Properties
    #endregion

    #region Builtin Methods
    void Start()
    {
        _inputs = Player_Inputs.Instance;

        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        Locomotion();
        CalculateVerticalMovement();
        UpdateAnimations();
    }
    #endregion

    #region Custom Methods
    private void Locomotion()
    {
        if (!_inputs) return;

        if (_canMove)
        {
            _direction.Set(_inputs.Movement.x, 0, _inputs.Movement.y);

            if (_direction.normalized.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _turnSmoothSpeed);

                transform.rotation = Quaternion.Euler(0, angle, 0);

                _moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            }
            else
            {
                _moveDirection = Vector3.zero;
            }
        }

        _movement = _moveDirection.normalized * _moveSpeed * Time.deltaTime;
    }
    //Mouvements du personnage

    private void CalculateVerticalMovement()
    {
        if (_characterController.isGrounded)
        {
            _verticalSpeed = -_gravity * 0.3f;

            if (_inputs.Jump && _canMove)
            {
                _verticalSpeed = _jumpForce;
            }

            _distanceToGround = 0;
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, 1 << 6))
            {
                if (_distanceToGround < hit.distance)
                {
                    _distanceToGround = hit.distance;
                }
            }

            if (_distanceToGround > _distanceMaxLanding)
            {
                _isBigLanding = true;
            }
            else
            {
                _isBigLanding = false;
            }

            _verticalSpeed -= _gravity * Time.deltaTime;
        }

        _movement += _verticalSpeed * Vector3.up;
        _characterController.Move(_movement);
    }
    //Fluidité des déplacements

    private void CanMove(bool canMove)
    {
        if (canMove)
        {
            _canMove = true;
        }
        else
        {
            _canMove = false;
            _moveDirection = Vector3.zero;
        }
    }
    #endregion
}