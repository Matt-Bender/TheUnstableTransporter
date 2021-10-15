using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform cam;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            //lerp smooths: current position, desired position, speed to reach
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            Vector3 camPos = transform.position;
            camPos.y = 0;
            cam.transform.position = camPos;
        }
    }
}
