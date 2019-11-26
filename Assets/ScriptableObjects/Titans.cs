using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Titan", menuName = "Titan/New Titan", order = 0)]


public class Titans : ScriptableObject
{
    public string titanName;
    public GameObject model;
    public PrimaryWeapons primaryWeapon;
    public string defensiveAbility;
    public string coreAbility;
}
