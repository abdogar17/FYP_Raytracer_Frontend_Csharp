using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectcontrol : MonoBehaviour
{
    public float speed = 100f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal * speed - Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        
    }

}
