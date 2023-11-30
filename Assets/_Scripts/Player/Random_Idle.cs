using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Idle : StateMachineBehaviour
{
    #region Variables
    [SerializeField] private float _minRandomTime = 1f;
    [SerializeField] private float _maxRandomTime = 2;
    [SerializeField] private int _idleNumber = 3;

    private float _randomTime = 0f;
    private int _randomIdle = Animator.StringToHash("RandomIdle");
    #endregion
	
	#region Properties
    #endregion
	
	#region Builtin Methods
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger(_randomIdle, -1);
        _randomTime = Random.Range(_minRandomTime, _maxRandomTime);
    }
    //Temps aléatoire

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger(_randomIdle, Random.Range(0, _idleNumber));
    }
    //Choisir aléatoirement un idle
	#endregion
}