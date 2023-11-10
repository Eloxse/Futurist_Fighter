using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inputs : MonoBehaviour
{
    #region Varibles
    private static Player_Inputs _instance;

    private Vector3 _movement = Vector3.zero;
    #endregion

    #region Properties
    public static Player_Inputs Instance => _instance;
    public Vector3 Movement => _movement;
    #endregion

    #region Builtin Methods
    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    void Update()
    {
        _movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }
    #endregion
}