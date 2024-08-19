using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;

    void Start()
    {
        rigidbody.velocity = new Vector3(0, speed, 0);
    }
}
