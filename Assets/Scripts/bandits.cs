using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class bandits : MonoBehaviour
{
    public static int deadbandits;
    public int maxdead;
    public static bool kazan;
    public GameObject camgunn;
    public GameObject banditfollow;
    public static bool kaybet;
    public GameObject banditdummy;
void Start()
    {
        kaybet = false;
        kazan = false;
        deadbandits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (deadbandits == maxdead)
        {
            kazan = true;
        //    GetComponent<SplineFollower>().enabled = false;
            
                camgunn.GetComponent<SplineFollower>().enabled = false;
            banditfollow.GetComponent<SplineFollower>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bandit")
        {
            kaybet = true;
            camgunn.GetComponent<SplineFollower>().enabled = false;
            banditdummy.GetComponent<bndtdmmy>().enabled = true;
            
        }
    }
}
