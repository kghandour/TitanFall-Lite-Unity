using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Heavy Weapon", menuName = "Weapons/Heavy", order = 1)]

public class HeavyWeapons : ScriptableObject
{
    public GameObject modelPrefab;
    public string weaponName;
    public int range;
    public int damage;
}
