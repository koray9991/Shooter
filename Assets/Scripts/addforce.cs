using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour
{

 
    void Start()
    {
       
        
    
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.tankatesint == 1)
        {
            GetComponent<addforce2>().enabled = true;
        }

      
    }
    private void OnTriggerEnter(Collider other)
    {
       /* if (other.tag == "bandit")
        {
            GetComponent<addforce2>().enabled = true;
        }*/
    }
}
