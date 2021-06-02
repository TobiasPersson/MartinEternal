using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedH = 10.0f;
    public float moveSpeed;
    AudioSource audio;
    public AudioClip[] martinSounds;
    Rigidbody rb;
    public GameObject meleeHitbox;
    private float yaw = 0.0f;
    public float xValue;
    public float yValue;
    public Vector3 velocityValue;
    public bool isMelee;
    public bool coolDown;
    

    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
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

        Vector3 velocity = rb.velocity = transform.forward * y * moveSpeed + transform.right * x * moveSpeed;
        velocityValue = velocity;
        xValue = x;
        yValue = y;




        if (FindObjectOfType<PlayerMovement>().isMelee == false)
        {
            if (Input.GetKey(KeyCode.Mouse0) && coolDown == false)
            {
                StartCoroutine(burnout());
                RaycastHit hit;
                Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit);
                Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * hit.distance, Color.green, 3);
                var takeDamage = hit.collider.GetComponent<ITakeDamage>();
                audio.clip = martinSounds[1];
                audio.Play();
                if (takeDamage != null)
                {
                    takeDamage.TakeDamage(3);
                    audio.clip = martinSounds[0];
                    audio.Play();
                }
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

    
    
    IEnumerator Slash()
    {
        meleeHitbox.SetActive(true);
        audio.clip = martinSounds[3];
        audio.Play();
        yield return new WaitForSeconds(0.3f);
        meleeHitbox.SetActive(false);
    }

    IEnumerator burnout()
    {
        //coolDown blir true, vilket hindrar fler skott från att avfyras.
        coolDown = true;
        //denna waitforseconds bestämmer hur länge coolDown är true, vilket i sin tur leder till en kontrollerad skottfrekvens.
        yield return new WaitForSeconds(0.1f);
        coolDown = false;
    }
}
