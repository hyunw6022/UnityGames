using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float delayTime;
    float timeSinceLastFire;

    void FixedUpdate()
    {
        timeSinceLastFire += Time.deltaTime;

        if (Input.GetKey("left")&& transform.position.x > -3.25)
        {
            transform.Translate(-speed, 0, 0);
        }

        if(Input.GetKey("right")&& transform.position.x < 3.25)
        {
            transform.Translate(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space)&& timeSinceLastFire > delayTime)
        {
            timeSinceLastFire = 0;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
