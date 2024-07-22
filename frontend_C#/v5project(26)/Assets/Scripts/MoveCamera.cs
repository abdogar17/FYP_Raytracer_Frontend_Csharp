using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // public float speedH = 2.0f;
    // public float speedV = 2.0f;
    // public float yaw = 0.0f;
    // public float pitch = 0.0f;

    public float Yaxis;
    public float Xaxis;
    public float senstivity = 8f;

    public Transform target;


    // Update is called once per frame
    void Update()
    {
        // if(!Input.GetMouseButton(0)){
        //     yaw += speedH * Input.GetAxis("Mouse X");
        //     pitch -= speedV * Input.GetAxis("Mouse Y");

        //     transform.eulerAngles = new Vector3(pitch, yaw , 0.0f);
        // }
        if(Input.GetMouseButton(1)){
            Yaxis += Input.GetAxis("Mouse X") * senstivity;
            Xaxis -= Input.GetAxis("Mouse Y") * senstivity;

            Vector3 targetRotation = new Vector3(Xaxis , Yaxis);
            transform.eulerAngles = targetRotation;

            transform.position = target.position - transform.forward * 5f;
        }
    }
}
