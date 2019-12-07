using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_and_call_titan_script : MonoBehaviour
{
    public static int titanfallMeter;
    private int MAX_TITANFALLMETER = 100;
    public bool titanDeployed;
    public int health;
    public GameObject Titan;
    public GameObject Pilot;
    public GameObject TitanPlayer;
    public Text titanFallAvailable;
    public Text embarkAvailable;
    public float rangeToEmbark;
    public GameObject secondaryCamera; //used as an effect for dimming the screen at embark time

    // Start is called before the first frame update
    void Start()
    {
        titanfallMeter = 100;
        titanDeployed = false;
        Titan.SetActive(false);
        health = 100;
        titanFallAvailable.gameObject.SetActive(false);
        embarkAvailable.gameObject.SetActive(false);
        secondaryCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!titanDeployed && titanfallMeter == MAX_TITANFALLMETER ) //Ready for titanfall
        {
            titanFallAvailable.gameObject.SetActive(true); //set text to indicate a player can perform a titanfall
            if (Input.GetKeyDown("t"))
                performTitanFall();
        }

        if (isTitanClose() && Titan.gameObject.activeInHierarchy)
        {
            
            embarkAvailable.gameObject.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                StartCoroutine(Embark());
            }
        }
        else
            embarkAvailable.gameObject.SetActive(false);
    }

    public void performTitanFall()
    {
        titanFallAvailable.gameObject.SetActive(false); //deactivate text
        titanfallMeter = 0;
        Titan.SetActive(true); //show titan
        //change titan position to vertically above pilot
        Titan.transform.eulerAngles = new Vector3(0, 0, 0);
        Vector3 newObjectLocation = new Vector3(Pilot.transform.position.x + 1.5f, Pilot.transform.position.y + 10, Pilot.transform.position.z);
        Titan.transform.position = newObjectLocation;
    }

    public bool isTitanClose()
    {
        float dist = Vector3.Distance(Titan.transform.position, transform.position);
        return dist < rangeToEmbark;  
    }

    IEnumerator Embark()
    {
        secondaryCamera.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        secondaryCamera.SetActive(false);
        Vector3 positionAfterEmbark = Titan.transform.position;
        TitanPlayer.transform.position = positionAfterEmbark;
        Pilot.transform.position = positionAfterEmbark;
        Titan.SetActive(false);
        Pilot.SetActive(false);
        TitanPlayer.SetActive(true);
        Titan.transform.parent = Pilot.transform;
        titanDeployed = true;
        embarkAvailable.gameObject.SetActive(false);
    }

    IEnumerator addHealth()
    {
        while (true)
        { // loops forever...
            if (health < 100)
            { // if health < 100...
                health += 5; // increase health and wait the specified time
                yield return new WaitForSeconds(1);
            }
            else
            { // if health >= 100, just yield 
                yield return null;
            }
        }
    }


}
