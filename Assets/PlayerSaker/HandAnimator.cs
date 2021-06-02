using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandAnimator : MonoBehaviour
{
    public Sprite[] handSprites;
    public float amplitude;
    public float frequency;
    UnityEngine.UI.Image handImage;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        handImage = GetComponent<UnityEngine.UI.Image>();
        anim = GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PlayerMovement>().isMelee == false)
        {
            if (FindObjectOfType<PlayerMovement>().coolDown == false) 
            {
                handImage.sprite = handSprites[1];
            }
            else if(FindObjectOfType<PlayerMovement>().coolDown == true)
            {
                handImage.sprite = handSprites[0];
            }
        }
        else if(FindObjectOfType<PlayerMovement>().isMelee == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                handImage.sprite = handSprites[2];
            }
            else
            {
                handImage.sprite = handSprites[3];
            }
        }

        if (FindObjectOfType<PlayerMovement>().xValue != 0 || FindObjectOfType<PlayerMovement>().yValue != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

    }
}
