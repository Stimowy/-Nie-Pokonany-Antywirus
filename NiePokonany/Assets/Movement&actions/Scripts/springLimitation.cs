using System;
using UnityEngine;

public class springLimitation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, 0.01031f, 0.015088f), transform.localPosition.x);
    }
}
