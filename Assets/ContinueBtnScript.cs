using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueBtnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button continueBtn;
    public Canvas pauseCanvas;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(continueGame);
    }

    // Update is called once per frame
    void Update()
    {
        Screen.lockCursor = false;
    }

    void continueGame()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
