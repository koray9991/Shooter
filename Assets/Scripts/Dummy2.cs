using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy2 : MonoBehaviour
{
    public GameObject ps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.tankyokedildi || bandits.kazan)
        {
            ps.SetActive(true);
        }
    }
}
