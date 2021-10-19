using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRandomiser : MonoBehaviour
{
    [SerializeField]
    SpriteCollection spriteCollection;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteCollection.Sprites[Random.Range(0, spriteCollection.Sprites.Length)];
    }
}
