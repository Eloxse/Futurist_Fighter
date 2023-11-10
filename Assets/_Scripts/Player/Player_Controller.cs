using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Variables
    public float _moveSpeed = 1f;
    public float _turnSmoothSpeed = 1f;
    public float _gravity = 6f;
    public float distanceMaxLanding = 10f;
    public GameObject staff;
    public GameObject pistol;

    private bool _canMove = true;
    private float _verticalSpeed;
    private float _currentVelocity;
    private Vector3 _movement = Vector3.zero;

    private Vector3 _direction = Vector2.zero;
    private Vector3 _moveDirection = Vector3.zero;

    private CharacterController _characterController;

    private Camera _camera;

    private Player_Inputs _inputs;
    #endregion

    #region Properties
    #endregion

    #region Builtin Methods
    // Start is called before the first frame update
    void Start()
    {

        _inputs = Player_Inputs.Instance;

        _characterController = GetComponent<CharacterController>();

        _camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Locomotion();
        CalculateVerticalMovement();
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

    private void CalculateVerticalMovement()
    {
        if (_characterController.isGrounded)
        {
            _verticalSpeed = -_gravity * 0.3f;
        }
        else
        {
            _verticalSpeed -= _gravity * Time.deltaTime;
        }

        _characterController.Move(_movement);
    }
    #endregion
}