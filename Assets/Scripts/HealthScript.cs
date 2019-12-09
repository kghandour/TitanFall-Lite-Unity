using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class HealthScript : MonoBehaviour
{
    private float maxHealth;
    public float currentHealth;
    public Image healthBar;


    private void Start()
    {
        if(gameObject.tag == "enemyTitan")
        {
            maxHealth = 400;
        }
        else if(gameObject.tag == "enemyPilot")
        {
            maxHealth = 100;
        }

        currentHealth = maxHealth;

    }

    private void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    currentHealth -= 10;
        //    print(healthBar.fillAmount);
        //}
    }
    //[SerializeField]
    //public int maxHealth;

    //public int currentHealth;


    //public event Action<float> OnHealthPctChanged = delegate
    //{

    //};

    //private void OnEnable()
    //{
    //    currentHealth = maxHealth;
    //}

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //public void ModifyHealth(int amount)
    //{
    //    currentHealth += amount;

    //    float currentHealthPct = (float)currentHealth / (float)maxHealth;
    //    OnHealthPctChanged(currentHealthPct);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
