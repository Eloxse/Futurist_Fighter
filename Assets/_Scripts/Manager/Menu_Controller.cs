using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _timeBeforeLoad = 0.3f;

    [SerializeField] private AudioSource _btnSound;
    #endregion
    
    #region Custom Methods
    public void LoadMapSelection(){
        StartCoroutine(DelayLoadMapSelection());
    }

    private IEnumerator DelayLoadMapSelection(){
        _btnSound.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Map_Selection", LoadSceneMode.Single);
    }

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

    public void LoadMapSewers(){
        StartCoroutine(DelayLoadMapSewers());
    }

    private IEnumerator DelayLoadMapSewers(){
        _btnSound.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Sewers", LoadSceneMode.Single);
    }

    public void LoadMapCity(){
        StartCoroutine(DelayLoadMapCity());
    }

    private IEnumerator DelayLoadMapCity(){
        _btnSound.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("City", LoadSceneMode.Single);
    }
    #endregion
}
