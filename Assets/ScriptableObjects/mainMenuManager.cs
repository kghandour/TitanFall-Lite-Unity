using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuManager : MonoBehaviour
{

    private void Start()
    {
        Screen.lockCursor = false;
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("CombatLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   
}
