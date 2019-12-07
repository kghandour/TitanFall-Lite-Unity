using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject heavyBulletObject;
    Rigidbody projectile;
    int ammoLeft;
    int bulletsFired;

    List<Bullet> bulletsList;
    int bulletSpeed = 40;

    float cooldown;

    Bullet heavyBullet;

    // Start is called before the first frame update
    void Start()
    {
        projectile = bulletObject.gameObject.GetComponent<Rigidbody>();
        bulletsList = new List<Bullet>();
        ammoLeft = WeaponManager.ammoCount;
    }

    bool firing;
    // Update is called once per frame
    void Update()
    {
        if (WeaponManager.primaryEquipped)
        {
            if (WeaponManager.automatic)
            {
                if (Input.GetMouseButton(0))
                {
                    firing = true;
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    firing = true;
                }
            }
            cooldown += Time.deltaTime;
            if (cooldown < 1)
            {
                if (bulletsFired >= WeaponManager.firingRate)
                {
                    firing = false;
                }
            }
            else
            {
                cooldown = 0;
                bulletsFired = 0;
            }
            if (firing)
            {
                if (bulletsList.Count < WeaponManager.ammoCount)
                {
                    GameObject cloneObject;
                    bulletObject.SetActive(true);
                    Rigidbody cloneRigidBody;

                    cloneObject = Instantiate(bulletObject, this.transform.position, bulletObject.transform.rotation);
                    cloneObject.tag = "Primary";
                    cloneRigidBody = cloneObject.gameObject.GetComponent<Rigidbody>();
                    Bullet b = new Bullet(this.transform, cloneRigidBody, cloneObject);
                    bulletsList.Add(b);

                    b.rigidBody.velocity = this.transform.TransformDirection(Vector3.forward * bulletSpeed);
                    ammoLeft -= 1;
                    bulletsFired += 1;
                }
                else
                {
                    if (ammoLeft > 0)
                    {
                        foreach (Bullet bullet in bulletsList)
                        {
                            if (bullet.bullet.activeSelf == false)
                            {
                                bullet.startPos = this.transform;
                                bullet.rigidBody.velocity = this.transform.TransformDirection(Vector3.forward * bulletSpeed);
                                bullet.bullet.transform.position = this.transform.position;
                                bullet.bullet.transform.rotation = this.transform.rotation;
                                bullet.bullet.SetActive(true);
                                ammoLeft -= 1;
                                bulletsFired += 1;

                                break;
                            }
                        }
                    }
                }
            }
            firing = false;

            if (Input.GetKeyDown(KeyCode.R))
            {
                ammoLeft = WeaponManager.ammoCount;
            }
        }
        else // Logic for HEAVY Weapons
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (heavyBullet == null)
                {
                    print(WeaponManager.currentHeavy.weaponName);
                    GameObject cloneObject;
                    Rigidbody cloneRigidBody;

                    cloneObject = Instantiate(heavyBulletObject, this.transform.position, heavyBulletObject.transform.rotation);
                    cloneObject.tag = "Heavy";
                    cloneRigidBody = cloneObject.gameObject.GetComponent<Rigidbody>();
                    if (WeaponManager.currentHeavy.weaponName == "Grenade")
                    {
                        cloneRigidBody.mass = 30;
                        cloneRigidBody.useGravity = true;
                    }
                    heavyBullet = new Bullet(this.transform, cloneRigidBody, cloneObject);
                    heavyBullet.rigidBody.velocity = this.transform.TransformDirection(Vector3.forward * 20);
                }else if(heavyBullet.bullet.activeSelf == false)
                {
                    heavyBullet.startPos = this.transform;
                    heavyBullet.rigidBody.velocity = this.transform.TransformDirection(Vector3.forward * 20);
                    heavyBullet.bullet.transform.position = this.transform.position;
                    heavyBullet.bullet.transform.rotation = this.transform.rotation;
                    heavyBullet.bullet.SetActive(true);
                }
            }
        }
        foreach (Bullet bullet in bulletsList)
        {
            if (bullet.bullet.activeSelf == true)
            {
                if (bullet.bullet.gameObject.transform.position.z - bullet.startPos.position.z > WeaponManager.range)
                {
                    bullet.bullet.SetActive(false);
                }
            }
        }

        if(heavyBullet!=null && heavyBullet.bullet.activeSelf == true)
        {
            if (heavyBullet.bullet.gameObject.transform.position.z - heavyBullet.startPos.position.z > WeaponManager.range)
            {
                heavyBullet.bullet.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            WeaponManager.primaryEquipped = !WeaponManager.primaryEquipped;
            
        }
    }

    
}
