using System.Collections;
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

    public static int damageAmount;
    public static bool automatic;
    public static int firingRate;
    public static int ammoCount;
    public static int range;
    private GameObject primaryObject;
    private GameObject heavyObject;

    public static int heavyRange;
    public static int heavyDamage;

    // Start is called before the first frame update
    void Start()
    {
        if(currentPrimary == null)
        {
            currentPrimary = Shotgun;
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

        heavyRange = currentHeavy.range;
        heavyDamage = currentHeavy.damage;
        
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
}
