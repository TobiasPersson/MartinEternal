using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScroll : MonoBehaviour
{

    public Rigidbody2D rb;
    public float scrollSpeed = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (new Vector2(0, -0.05f*scrollSpeed));
    }
}
