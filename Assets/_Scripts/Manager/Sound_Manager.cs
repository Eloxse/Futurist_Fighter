using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    [SerializeField] private AudioSource _ambiantSound;

    private void Start(){
        if(_ambiantSound){
            _ambiantSound.Play();
        }
    }
}
