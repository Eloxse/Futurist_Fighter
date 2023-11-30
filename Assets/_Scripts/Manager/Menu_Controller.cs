using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    [SerializeField] private float _timeBeforeLoad = 0.3f;

    [SerializeField] private AudioSource _btnSound;

    //Play button
    public void LoadMapSelection(){
        StartCoroutine(DelayLoadMapSelection());
    }

    private IEnumerator DelayLoadMapSelection(){
        _btnSound.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Map_Selection", LoadSceneMode.Single);
    }

    //Exit button
    public void ExitGame(){
        StartCoroutine(DelayExitGame());
    }

    private IEnumerator DelayExitGame(){
        _btnSound.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_timeBeforeLoad);
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
