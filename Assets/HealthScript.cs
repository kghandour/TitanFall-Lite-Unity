using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HealthScript : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;

    private int currentHealth;


    public event Action<float> OnHealthPctChanged = delegate
    {

    };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
