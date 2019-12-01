using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static PrimaryWeapons currentPrimary;
    public PrimaryWeapons AssaultRifle;
    public PrimaryWeapons Shotgun;
    public PrimaryWeapons Sniper;

    public static HeavyWeapons currentHeavy;
    public HeavyWeapons GrenadeLauncher;
    public HeavyWeapons RocketLauncher;


    public static bool primaryEquipped = true;

    public static int damageAmount;
    public static bool automatic;
    public static int firingRate;
    public static int ammoCount;
    public static int range;

    public static int heavyRange;
    public static int heavyDamage;

    // Start is called before the first frame update
    void Start()
    {
        if(currentPrimary == null)
        {
            currentPrimary = Sniper;
        }
        if(currentHeavy == null)
        {
            currentHeavy = RocketLauncher;
        }
        UpdateWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateWeapon()
    {
        damageAmount = currentPrimary.damageAmount;
        automatic = currentPrimary.automatic;
        firingRate = currentPrimary.firingRate;
        ammoCount = currentPrimary.ammoCount;
        range = currentPrimary.range;

        heavyRange = currentHeavy.range;
        heavyDamage = currentHeavy.damage;
    }
}
