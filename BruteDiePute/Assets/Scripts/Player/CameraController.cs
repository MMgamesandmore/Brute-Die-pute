using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15;

    public float pitch = 2;

    public float yawSpeed = 100f;

    private float currntZoom = 10f;
    private float currentYaw = 0f;

    float Axis = 0;


    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;

        //Debug.Log(Input.GetAxis("Mouse X"));
        //Debug.Log(Input.GetAxis("Horizontal"));
        if (mousePos.x > Screen.currentResolution.width - 50 || Input.GetAxis("Horizontal") < 0)
        {
            Axis = 1;
        }
        else if (mousePos.x < 50 || Input.GetAxis("Horizontal") > 0)
        {
            Axis = -1;
        }
        else
        {
            Axis = 0;
        }

        currntZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currntZoom = Mathf.Clamp(currntZoom, minZoom, maxZoom);


        currentYaw -= Axis * yawSpeed * Time.deltaTime;
        //currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currntZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
