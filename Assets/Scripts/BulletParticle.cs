using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    
    void Start()
    {
        
        GetComponent<ParticleSystem>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
