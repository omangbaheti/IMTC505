using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private Transform startPoint, endPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovePlatform());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            LeanTween.move(gameObject, endPoint, 4f);
            yield return new WaitForSeconds(6f);
            LeanTween.move(gameObject, startPoint, 4f);
            yield return new WaitForSeconds(6f);
        }

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            other.transform.parent = transform;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            other.transform.parent = null;
    }
    
}
