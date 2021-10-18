using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    Vector3 time = Vector3.zero;
    bool shouldShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FindObjectOfType<PlayerMovement>().xValue !=0 || FindObjectOfType<PlayerMovement>().yValue != 0)
        {
            transform.position = FindObjectOfType<PlayerMovement>().transform.position + new Vector3(0, Mathf.Sin(Time.time * frequency) * amplitude, 0);
            transform.rotation = FindObjectOfType<PlayerMovement>().transform.rotation;
        }
        else
        {
            transform.position = FindObjectOfType<PlayerMovement>().transform.position;
            transform.rotation = FindObjectOfType<PlayerMovement>().transform.rotation;
        }
    }
}
