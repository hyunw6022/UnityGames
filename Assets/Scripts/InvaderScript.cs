using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderScript : MonoBehaviour
{
    public Rigidbody2D invaderRB;
    public GameObject invaderParent, invaderBullet;
    public float speed;
    public int direction = 1;
    public int dice;

    void Start()
    {
        dice = 0;
        invaderRB.velocity = new Vector3(speed, 0, 0);
    }

    void Update()
    {
        dice = Random.Range(1, 2001);
        if (dice==1)
        {
            Instantiate(invaderBullet, transform.position, transform.rotation);
            dice = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Left Wall")
        {
            invaderParent.BroadcastMessage("MoveRight");
        }

        if(other.gameObject.tag == "Right Wall")
        {
            invaderParent.BroadcastMessage("MoveLeft");
        }

        if(other.gameObject.tag == "Speed Up")
        {
            Destroy(other.gameObject);
            invaderParent.BroadcastMessage("UpdateSpeed");
        }
    }

    void MoveRight()
    {
        direction = 1;
        invaderRB.velocity = new Vector3(speed * direction, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, 0);
    }

    void MoveLeft()
    {
        direction = -1;
        invaderRB.velocity = new Vector3(speed * direction, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, 0);
    }

    void UpdateSpeed()
    {
        speed *= 1.1f;
        invaderRB.velocity = new Vector3(speed * direction, 0, 0);
    }
}
