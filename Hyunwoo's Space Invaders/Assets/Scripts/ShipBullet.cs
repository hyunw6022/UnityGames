using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Reset")
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Invader")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameController.instance.UpdateScore();
        }
    }
}
