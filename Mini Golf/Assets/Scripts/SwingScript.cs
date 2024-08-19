using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
    private Rigidbody rb;
    public float swingForce;
    private LineRenderer line;
    public Vector3 mousePosition, swingDirection;
    public bool swingActive;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();
        line.widthMultiplier = 0.02f;
        line.enabled = false;
        swingActive = false;
    }

    void Update()
    {
        if (rb.velocity.magnitude < 0.25f)
        {
            rb.velocity = Vector3.zero;
        }
    }

    void OnMouseDrag()
    {
        DrawLine();
        swingActive = true;
    }

    void OnMouseUp()
    {
        rb.AddForce(swingDirection* swingForce, ForceMode.Impulse);
        gameController.currSwing++;
        line.enabled = false;
        swingActive = false;
    }

    void DrawLine()
    {
        line.enabled = true;
        float distance;

        Plane plane = new Plane(Vector3.up, -transform.position.y);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (plane.Raycast(ray, out distance))
        {
            mousePosition = ray.GetPoint(distance);
            Debug.DrawRay(transform.position, mousePosition - transform.position, Color.green);
        }
        swingDirection = transform.position - mousePosition;
        swingDirection = new Vector3(swingDirection.x , 0, swingDirection.z);

        line.SetPosition(0, transform.position);
        line.SetPosition(1, mousePosition);
    }
}
