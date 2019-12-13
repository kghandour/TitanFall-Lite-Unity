using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameScript : MonoBehaviour
{
    public GameObject endScreeen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        endScreeen.SetActive(true);
    }
}
