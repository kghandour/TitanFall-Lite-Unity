using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public Material green;
    private int numberOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("enemyPilot").Length + GameObject.FindGameObjectsWithTag("enemyTitan").Length;
        if(numberOfEnemies == 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = green;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(numberOfEnemies == 0)
        {
            Debug.Log("Finished Combat level");
            SceneManager.LoadScene("ParkourLevel");
        }
    }
}
