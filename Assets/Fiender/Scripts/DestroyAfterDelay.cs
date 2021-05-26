using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    [SerializeField]
    private float destroyDelay = 1;

    [SerializeField]
    private bool pooledObject = false;

    private float timer = 0;

    private GameObject poolParent;

    void Start()
    {
        if (!pooledObject)
        {
            Destroy(gameObject, destroyDelay);
        }
        else
        {
            poolParent = GameObject.Find(string.Format("Pool - {0}", gameObject.name.Remove(gameObject.name.Length - 9)));
        }
    }

    private void Update()
    {
        if (pooledObject)
        {
            timer += Time.deltaTime;

            if (timer >= destroyDelay)
            {
                timer = 0;
                transform.SetParent(poolParent.transform);
                gameObject.SetActive(false);
            }
        }
    }
}
