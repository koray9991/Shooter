using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabelaTimer : MonoBehaviour
{
    public float timer;
    public float maxTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
