using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrpw : MonoBehaviour
{
    public Rigidbody rb;
    bool MoveUp;
    public float rotation;
    public float movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotation);
        if (MoveUp)
        {
            rb.velocity = new Vector3(0, movement, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, -movement, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "up")
        {
            MoveUp = false;
        }
        if (other.tag == "down")
        {
            MoveUp = true;
        }
    }
}
