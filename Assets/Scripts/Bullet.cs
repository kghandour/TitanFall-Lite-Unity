using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform startPos;
    public Rigidbody rigidBody;
    public GameObject bullet;
    public Bullet(Transform pos, Rigidbody rigid, GameObject bullet)
    {
        this.startPos = pos;
        this.rigidBody = rigid;
        this.bullet = bullet;
    }
}
