﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private GameObject currentWeaponObject;
    public GameObject weaponPlaceHolder;
    public static PrimaryWeapons currentPrimary;
    public PrimaryWeapons AssaultRifle;
    public PrimaryWeapons Shotgun;
    public PrimaryWeapons Sniper;

    public static HeavyWeapons currentHeavy;
    public HeavyWeapons GrenadeLauncher;
    public HeavyWeapons RocketLauncher;


    public static bool primaryEquipped = true;
    private bool prevPrimaryEquipped = true;


    public static string weaponName;
    public static int damageAmount;
    public static bool automatic;
    public static int firingRate;
    public static int ammoCount;
    public static int range;
    private GameObject primaryObject;
    private GameObject heavyObject;

    public static int heavyRange;
    public static int heavyDamage;
    public static string heavyWeaponName;

    private void Awake()
    {
        if (currentPrimary == null)
        {
            currentPrimary = Shotgun;
        }
        if (currentHeavy == null)
        {
            currentHeavy = RocketLauncher;
        }
        UpdateWeapon();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(prevPrimaryEquipped != primaryEquipped)
        {
            prevPrimaryEquipped = primaryEquipped;
            UpdateWeapon();
        }
    }

    void UpdateWeapon()
    {
        damageAmount = currentPrimary.damageAmount;
        automatic = currentPrimary.automatic;
        firingRate = currentPrimary.firingRate;
        ammoCount = currentPrimary.ammoCount;
        range = currentPrimary.range;
        primaryObject = currentPrimary.modelPrefab;
        heavyObject = currentHeavy.modelPrefab;
        weaponName = currentPrimary.name;

        heavyRange = currentHeavy.range;
        heavyDamage = currentHeavy.damage;
        heavyWeaponName = currentHeavy.name;


        if (primaryEquipped)
        {
            if (currentWeaponObject != null)
            {
                Destroy(currentWeaponObject);
            }
            currentWeaponObject = Instantiate(primaryObject, this.weaponPlaceHolder.transform);
        }
        else
        {
            if (currentWeaponObject != null)
            {
                Destroy(currentWeaponObject);
            }
            currentWeaponObject = Instantiate(heavyObject, this.weaponPlaceHolder.transform);
        }
    }

    public void SetPrimary(string Primary)
    {
        if(Primary == "Assault")
        {
            currentPrimary = AssaultRifle;
        }else if(Primary == "Shotgun")
        {
            currentPrimary = Shotgun;
        }else if(Primary == "Sniper")
        {
            currentPrimary = Sniper;
        }
    }

    public void SetHeavy(string Heavy)
    {
        if(Heavy == "RPG")
        {
            currentHeavy = RocketLauncher;
        }else if(Heavy == "Grenade Launcher")
        {
            currentHeavy = GrenadeLauncher;
        }
    }
}
