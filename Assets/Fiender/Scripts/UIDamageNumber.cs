using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDamageNumber : PooledMonoBehaviour
{
    [HideInInspector]
    public Vector3 positionToHold = Vector3.zero;

    private new Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        (transform as RectTransform).position = camera.WorldToScreenPoint(positionToHold);
    }

    protected override void OnDisable()
    {
        (transform as RectTransform).offsetMax = Vector2.zero;
        (transform as RectTransform).offsetMin = Vector2.zero;

        base.OnDisable();
    }
}
