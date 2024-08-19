using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float panMultiplier;
    public Slider slider;

    void LateUpdate()
    {
        Camera.main.orthographicSize = 1.0f / slider.value;
        Camera.main.transform.position += transform.right * Input.GetAxis("Horizontal") * panMultiplier;
        Camera.main.transform.position += Vector3.up * Input.GetAxis("Vertical")* panMultiplier;
    }
}
