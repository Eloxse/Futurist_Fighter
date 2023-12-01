using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    #region Variables
    public static bool gameIsPaused = false;

    [SerializeField] private float _timeBeforeLoad = 0.3f;

    [SerializeField] private AudioSource _btnSound;
    [SerializeField] private GameObject _resumeUI;
    #endregion
    
    #region Custom Methods
    private void GameIsPaused(){
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void LoadMapSelection(){
        StartCoroutine(DelayLoadMapSelection());
        GameIsPaused();
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
        GameIsPaused();
    }

    private IEnumerator DelayLoadMapSewers(){
        _btnSound.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Sewers", LoadSceneMode.Single);
    }

    public void LoadMapCity(){
        StartCoroutine(DelayLoadMapCity());
        GameIsPaused();
    }

    private IEnumerator DelayLoadMapCity(){
        _btnSound.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("City", LoadSceneMode.Single);
    }

    public void LoadMenu(){
        StartCoroutine(DelayLoadMenu());
        GameIsPaused();
    }

    private IEnumerator DelayLoadMenu(){
        _btnSound.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_timeBeforeLoad);
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    public void Resume(){
        _resumeUI.SetActive(false);
        GameIsPaused();
    }
    #endregion
}
