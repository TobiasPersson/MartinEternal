using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedH = 10.0f;
    Rigidbody rb;
    public GameObject meleeHitbox;
    private float yaw = 0.0f;
    public float xValue;
    public float yValue;
    public Vector3 velocityValue;
    public bool isMelee;
    

    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        //fpsCam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && isMelee == false)
        {
            isMelee = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && isMelee == true)
        {
            isMelee = false;
        }
        yaw += speedH * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0, yaw, 0);

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        xValue = x;
        yValue = y;

        Vector3 velocity = rb.velocity = transform.forward * y * 5 + transform.right * x * 5;
        velocityValue = velocity;


        

        if (FindObjectOfType<PlayerMovement>().isMelee == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        else if (FindObjectOfType<PlayerMovement>().isMelee == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(Slash());
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit);
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * hit.distance, Color.green, 3);
        var takeDamage = hit.collider.GetComponent<ITakeDamage>();
        if(takeDamage != null)
        {
            takeDamage.TakeDamage(3);
        }
    }
    
    IEnumerator Slash()
    {
        meleeHitbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        meleeHitbox.SetActive(false);

    }
}
