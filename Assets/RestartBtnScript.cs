using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartBtnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button restartBtn;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(loadCombatLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void loadCombatLevel()
    {
        SceneManager.LoadScene("CombatLevel");
    }
}
