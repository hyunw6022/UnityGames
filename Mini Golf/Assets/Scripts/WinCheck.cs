using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    public GameObject flag;
    Rigidbody rb;
    GameController gameController;
    public float delta;
    public float threshold;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        flag = GameObject.Find("Flag");
    }

    void Update()
    {
        delta = Vector3.Distance(transform.position, flag.transform.position);
        if(delta < threshold && rb.velocity.magnitude == 0)
        {
            gameController.LevelComplete();
        }
    }
}
