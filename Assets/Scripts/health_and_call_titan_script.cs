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
    public GameObject Titan2;
    public GameObject Pilot;
    public GameObject TitanPlayer;
    public GameObject TitanPlayer2;
    public Text titanFallAvailable;
    public Text embarkAvailable;
    public float rangeToEmbark;
    public GameObject secondaryCamera; //used as an effect for dimming the screen at embark time

    public Slider healthBar;
    public Slider titanFallMeterBar;


    // Start is called before the first frame update
    void Start()
    {
        titanfallMeter = 0;
        titanDeployed = false;
        Titan.SetActive(false);
        if(health ==0 ) health = 100;
        titanFallAvailable.gameObject.SetActive(false);
        embarkAvailable.gameObject.SetActive(false);
        secondaryCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.value = health;
        titanFallMeterBar.value = titanfallMeter;

        
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
        else if (isTitanClose() && Titan2.gameObject.activeInHierarchy)
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
        if(ChosenTitan.selectedTitan==0){
            Titan.SetActive(true); //show titan
        //change titan position to vertically above pilot
            Titan.transform.eulerAngles = new Vector3(0, 0, 0);
            Vector3 newObjectLocation = new Vector3(Pilot.transform.position.x + 1.5f, Pilot.transform.position.y + 10, Pilot.transform.position.z);
            Titan.transform.position = newObjectLocation;
        }else if(ChosenTitan.selectedTitan==1){
            Titan2.SetActive(true); //show titan
        //change titan position to vertically above pilot
            Titan2.transform.eulerAngles = new Vector3(0, 0, 0);
            Vector3 newObjectLocation = new Vector3(Pilot.transform.position.x + 1.5f, Pilot.transform.position.y + 10, Pilot.transform.position.z);
            Titan2.transform.position = newObjectLocation;
        }
        
    }

    public bool isTitanClose()
    {
        float dist = 1000;
        if(ChosenTitan.selectedTitan==0)
            dist = Vector3.Distance(Titan.transform.position, transform.position);
        else if(ChosenTitan.selectedTitan==1)
            dist = Vector3.Distance(Titan2.transform.position, transform.position);
        return dist < rangeToEmbark;  
    }

    IEnumerator Embark()
    {
        secondaryCamera.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        secondaryCamera.SetActive(false);
        Vector3 positionAfterEmbark = new Vector3(0,0,0);
        if(ChosenTitan.selectedTitan==0){
            positionAfterEmbark = Titan.transform.position;
            TitanPlayer.transform.position = positionAfterEmbark;
        }else if(ChosenTitan.selectedTitan==1){
            positionAfterEmbark = Titan2.transform.position;
            TitanPlayer2.transform.position = positionAfterEmbark;
        }
        Pilot.transform.position = positionAfterEmbark;
        Titan.SetActive(false);
        Titan2.SetActive(false);
        Pilot.SetActive(false);
        if(ChosenTitan.selectedTitan==0){
            TitanPlayer.SetActive(true);
            Titan.transform.parent = Pilot.transform;
        }else if(ChosenTitan.selectedTitan==1){
            TitanPlayer2.SetActive(true);
            Titan2.transform.parent = Pilot.transform;
        }
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
