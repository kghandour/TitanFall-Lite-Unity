using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenuBtnScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(loadMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
