using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce2 : MonoBehaviour
{
    Rigidbody rb;
    public float x, y, z;
     
    void Start()
    {
       
        x = Random.Range(-1, 1);
        y = Random.Range(-1, 1);
        z = Random.Range(-1, 1);
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(new Vector3(Random.Range(-100, 100), Random.Range(125, 175), Random.Range(-100, 100)));
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z);
    }
}
