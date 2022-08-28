using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.tankyokedildi)
        {
            anim = GetComponent<Animator>();
            anim.SetInteger("hareket", 1);
        }
        if (bandits.kazan)
        {
            anim = GetComponent<Animator>();
            anim.SetInteger("hareket", 1);
        }
    }
}
