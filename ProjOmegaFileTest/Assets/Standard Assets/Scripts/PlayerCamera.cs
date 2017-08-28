﻿using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    //target will be the player position
    public Transform target;

    //distance from player
    public float distance;

    public int rayDistance = 50;

    Transform mockCamera;
    Transform mockCamera1;
    bool mockCameraRepositioned = false;
    bool foundNewPosition = false;
    //hi there babjyyyy
    //hji thereerere
    private const float Y_ANGLE_MIN = 5.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    private const float minCameraDistance = 18.0f;
    private const float maxCameraDistance = 40.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    public float zoomSpeed;
    public float rotateSpeed;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    //hljkjahahahahadasddsdasdsdsdsadsdsds
    /**
        Update is called at the beginning of every frame at run time.
        This means that all runnable code is ran at one point or another from here.
        Similar to main or runnable with frame by frame implementation.
        Update will change the camera's position to reflect the player's position
            WITHOUT reflecting the player's rotation and MAINTAINING a constant z offset.
    */


    void Update()
    {
        currentX += (Input.GetAxis("Horizontal") * rotateSpeed);
        currentY += Input.GetAxis("Vertical");
        distance += (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        distance = Mathf.Clamp(distance, minCameraDistance, maxCameraDistance);
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, -currentX, 0.0f);

        Vector3 pos = (rotation * new Vector3(0.0f,1.0f,-distance)) + (lookAt.transform.position);
        camTransform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f);
        camTransform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 2f);
    }
    int i = 0;
    //cauzdfe i like to dancee
    void findNewCameraPosition()
    {
        Debug.Log("PLAYA OUTA SIGHT!!");
        //bool foundPosition = false;
        if(!mockCameraRepositioned)
        {
            mockCameraRepositioned = true;
            mockCamera = this.gameObject.transform;
            mockCamera1 = this.gameObject.transform;
        }
        while(!foundNewPosition)
        {
            mockCamera.transform.LookAt(target);
            mockCamera1.transform.LookAt(target);
            mockCamera.transform.position = new Vector3(target.position.x, target.position.y + distance, target.position.z - (distance * 1.5f));
        }

        //transform.LookAt(target);
    }

    void moveToNewPosition()
    {
        transform.LookAt(target);
    }
}
