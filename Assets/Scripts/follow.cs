using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class follow : MonoBehaviour
{
    public GameObject tankk;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tankk.GetComponent<SplineFollower>().enabled)
        {
            GetComponent<SplineFollower>().enabled = false;
        }
        else
        {
            GetComponent<SplineFollower>().enabled = true;
        }

        GetComponent<SplineFollower>().followSpeed = tankk.GetComponent<SplineFollower>().followSpeed; 
    }
}
