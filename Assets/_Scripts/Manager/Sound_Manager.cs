using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    #region Variables
    [SerializeField] private AudioSource _ambiantSound;
    #endregion

    #region Builtin Methods
    private void Start(){
        if(_ambiantSound){
            _ambiantSound.Play();
        }
    }
    #endregion
}
