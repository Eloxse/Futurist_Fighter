using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _moveSpeed = 1f;

	private Vector3 _movement = Vector3.zero;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _direction = Vector3.zero;

	public Player_Inputs _inputs;
    #endregion

    #region Properties
    #endregion

    #region Builtin Methods
    private void Start()
    {
        _inputs = GetComponent<Player_Inputs>();
    }

    private void FixedUpdate()
    {
        Locomotion();
    }
    #endregion

    #region Custom Methods
    private void Locomotion()
    {
        _direction.Set(_inputs.Movement.x, 0, 0);
        _movement = _moveDirection.normalized * _moveSpeed * Time.deltaTime;
    }
    #endregion
}
