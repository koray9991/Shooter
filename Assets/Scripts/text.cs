using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
    bool buyu;
    public float maxscale, minscale, hiz;
    private void Start()
        
    {
        buyu = true;
    }
    void FixedUpdate()
    {
        if (transform.localScale.x >= maxscale)
        {
            buyu = false;
        }
        if (transform.localScale.x <= minscale)
        {
            buyu = true;
        }

        if (buyu)
        {
            transform.localScale = new Vector3(transform.localScale.x + hiz, transform.localScale.y + hiz, 1);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x - hiz, transform.localScale.y - hiz, 1);
        }
    }
}