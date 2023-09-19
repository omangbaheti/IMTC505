using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private bool isCapsule1;
    [SerializeField] private float rotationAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCapsule1)
        {
            transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
            transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.up, rotationAngle * Time.deltaTime);
        }
    }
}
