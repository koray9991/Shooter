using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camgun : MonoBehaviour
{
    public Transform tank;
    public Transform BackwardSpline;


    void Start()
    {
      
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!GunController.Instance.Intro)
         {
      
             transform.LookAt(tank);
         }
         else
         {
        
             transform.LookAt(BackwardSpline);
         }

        
    }
}
