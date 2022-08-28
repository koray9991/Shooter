using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    public Transform target;
    public Transform tank;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                transform.position = new Vector3(tank.position.x, tank.position.y-0.2f, tank.position.z);
        transform.LookAt(target);
    }
}
