using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static bool gameIsPaused = false;

    [SerializeField] private GameObject resumeUI;
    #endregion

    #region Build Methods
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Resume();
        }
    }
    #endregion
    
    #region Custom Methods
    public void Resume(){
        resumeUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    #endregion
}
