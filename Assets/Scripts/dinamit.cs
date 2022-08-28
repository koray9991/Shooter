using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
public class dinamit : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject dinamitcol;
    public float bx, by, bz;
    public TextMeshPro kactakac;
    public int say;
    public GameObject ps;
    public bool buyukucul;
    public bool buyume;
   public float timer;
    public int maxsay;
    public ParticleSystem pss;
    public float timer2;
    public Transform cam;
    public static dinamit instance;
    public GameObject Arrow;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        kactakac.text = say + " / " + maxsay;
    }

    // Update is called once per frame
    void Update()
    {
        if (say == maxsay && GetComponent<BoxCollider>().enabled)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            kactakac.enabled = false;
            ps.SetActive(true);
            pss.Play();
            dinamitcol.GetComponent<SphereCollider>().enabled = true;
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Arrow.SetActive(false);
            }
            
        }
       
    }
    private void FixedUpdate()
    {

        kactakac.transform.LookAt(cam);
        if (dinamitcol.GetComponent<SphereCollider>().enabled)
        {
            timer2 += Time.deltaTime;
            if (timer2 > 0.2f)
            {
                dinamitcol.GetComponent<SphereCollider>().enabled = false;
            }
           
        }

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
                transform.localScale = new Vector3(transform.localScale.x + 0.3f, transform.localScale.y + 0.3f, transform.localScale.z + 0.3f);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.3f, transform.localScale.y - 0.3f, transform.localScale.z - 0.3f);
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

    }

}
