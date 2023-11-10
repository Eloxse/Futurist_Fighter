using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inputs : MonoBehaviour
{
    #region Variables
    private Vector3 _movement = Vector3.zero;

    public Player_Inputs _instance;
    #endregion

    #region Properties
    public Vector3 Movement => _movement;
    #endregion

    #region Builtin Methods
    private void Awake()
    {

    }
    private void Update()
    {
        _movement.Set(Input.GetAxis("Horizontal"), 0, 0);
    }
	#endregion
}