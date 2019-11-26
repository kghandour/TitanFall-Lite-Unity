using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Primary Weapon", menuName = "Weapons/Primary", order = 0)]


public class PrimaryWeapons : ScriptableObject
{
    public GameObject modelPrefab;
    public string weaponName;
    public int damageAmount;
    [Tooltip("true: Automatic, false: Single shot")]
    public bool automatic;
    public int firingRate;
    public int ammoCount;
    public int range;
}
