using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class bndtdmmy : MonoBehaviour
{
    public List<GameObject> dummysss = new List<GameObject>();
    public List<GameObject> banditss = new List<GameObject>();

    public GameObject banditler;
    float timer;
    public static bool dummykalmadi;
    void Start()
    {
        WithForeachLoop();
        dummykalmadi = false;
        banditler.GetComponent<SplineFollower>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 0.1f)
        {

            if (dummysss.Count >= banditss.Count)
            {
                for (int i = 0; i < banditss.Count; i++)
                {
                    if (!dummysss[i].GetComponent<addforce2>().enabled)
                    {
                        banditss[i].transform.position = Vector3.MoveTowards(banditss[i].transform.position, dummysss[i].transform.position, 0.02f);
                        banditss[i].GetComponent<Transform>().LookAt(dummysss[i].gameObject.transform);
                        if (Vector3.Distance(banditss[i].transform.position, dummysss[i].transform.position) <= 0.1f)
                        {
                            dummysss[i].GetComponent<addforce2>().enabled = true;
                            dummysss.Remove(dummysss[i].gameObject);
                            
                            //    banditss[i].GetComponent<Animator>().SetInteger("hareket", 2);
                            break;
                           
                        }

                    }

                }
            }
            if (dummysss.Count < banditss.Count)
            {
                for (int i = 0; i < dummysss.Count; i++)
                {
                    if (!dummysss[i].GetComponent<addforce2>().enabled)
                    {
                        banditss[i].transform.position = Vector3.MoveTowards(banditss[i].transform.position, dummysss[i].transform.position, 0.02f);
                        banditss[i].GetComponent<Transform>().LookAt(dummysss[i].gameObject.transform);
                        if (Vector3.Distance(banditss[i].transform.position, dummysss[i].transform.position) <= 0.1f)
                        {
                            dummysss[i].GetComponent<addforce2>().enabled = true;
                            dummysss.Remove(dummysss[i].gameObject);
                           // banditss.Remove(dummysss[i].gameObject);
                            break;

                        }

                    }
                }
                {

                }
            }
            if (dummysss.Count == 0)
            {
                for (int i = 0; i < banditss.Count; i++)
                {
               
                    dummykalmadi = true;
                    banditss[i].GetComponent<Animator>().SetInteger("hareket", 0);
                }
            }



                /*if (!dummysss[0].GetComponent<addforce2>().enabled)
                {
                    banditss[0].transform.position = Vector3.MoveTowards(banditss[0].transform.position, dummysss[0].transform.position, 0.04f);
                    if (Vector3.Distance(banditss[0].transform.position, dummysss[0].transform.position) <= 0.1f)
                    {
                        dummysss[0].GetComponent<addforce2>().enabled = true;
                    }
                }*/








        }

    }
   

    void WithForeachLoop()
    {
        foreach (Transform child in banditler.transform)
        {
            banditss.Add(child.gameObject);
        }
        //    print("Foreach loop: " + child);
    }
}
