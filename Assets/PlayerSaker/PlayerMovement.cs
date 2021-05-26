using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedH = 4.0f;
    Rigidbody rb;
    private float yaw = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0, yaw, 0);

        rb.velocity = transform.forward * Input.GetAxis("Vertical") * 5 + transform.right * Input.GetAxis("Horizontal") * 5;
    }
}
