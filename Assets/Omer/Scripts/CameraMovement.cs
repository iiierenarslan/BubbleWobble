using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float rotationSpeed = 5f; 
    public float smoothSpeed = 10f; 
    public float maxYOffset = 3f; 

    public float minX;
    public float maxX;

    public float scale;

    private float yaw; 
    private float pitch; 


    private void Start()
    {
        offset = player.position - transform.position;
    }


    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, minX, maxX); 

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 scaledOffset = offset * player.localScale.x;

        Vector3 targetPosition = player.position + rotation * scaledOffset;


        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(player.position + Vector3.up * 1.5f); 

    }

}
