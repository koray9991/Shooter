using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class barrel : MonoBehaviour
{
    public TextMeshPro kactakac;
    public bool buyukucul;
    public bool buyume;
    public float timer;
    public float bx, by, bz;
  public  int say;
    public int maxsay;
    public Rigidbody rb;
    public ParticleSystem ps;
    public GameObject pss;
    public GameObject barrelexp;
    public float barrelexptimer;
    public GameObject cylinder1, cylinder2;
    public Transform cam;
    void Start()
    {
        kactakac.text = say + " / " + maxsay;
    }
    private void Update()
    {
        if (say == maxsay && GetComponent<BoxCollider>().enabled)
        {
            GetComponent<BoxCollider>().enabled = false;
           // GetComponent<MeshRenderer>().enabled = false;
            kactakac.enabled = false;
            rb.useGravity = true;
            GetComponent<SphereCollider>().enabled = true;
            cylinder1.GetComponent<Rigidbody>().useGravity = true;
            cylinder1.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100, 100), Random.Range(0, 100), Random.Range(-100, 100)));
            cylinder2.GetComponent<Rigidbody>().useGravity = true;
            cylinder2.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100, 100), Random.Range(0, 100), Random.Range(-100, 100)));

        }
        if (barrelexp.activeSelf)
        {
            barrelexptimer += Time.deltaTime;
            if (barrelexptimer > 0.1f)
            {
                barrelexp.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        kactakac.transform.LookAt(cam);
        if (!buyukucul)
        {
            transform.localScale = new Vector3(bx, by, bz);
        }
        if (buyukucul)
        {
            buyume = true;
            timer += Time.deltaTime;
            if (timer > 0.03f)
            {
                buyume = false;
            }
            if (timer > 0.06f)
            {
                buyukucul = false;
                timer = 0;
            }
            if (buyume == true)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.04f, transform.localScale.y + 0.04f, transform.localScale.z + 0.04f);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.04f, transform.localScale.y - 0.04f, transform.localScale.z - 0.04f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ball")
        {
            say++;
            kactakac.text = say + " / " + maxsay;
            buyukucul = true;
            // transform.DOPunchScale(new Vector3(bx, by, bz), bir, iki, uc);
        }
        if (other.tag == "ground")
        {
            GetComponent<MeshRenderer>().enabled = false;
            pss.SetActive(true);
            ps.Play();
            barrelexp.SetActive(true);
        }

    }
}
