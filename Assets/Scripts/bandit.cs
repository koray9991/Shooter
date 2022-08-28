using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class bandit : MonoBehaviour
{
    public bool buyukucul;
    public bool buyume;
    public float timer;
    int say;
    public float bx, by, bz;
     Rigidbody rb;
    public int can;
    public int forceapplied;
    public GameObject skin;
    public ParticleSystem ps;
    public Animator anim;
    public GameObject banditx;
    bool finishtouch;
    public GameObject banditShape;
    public Material[] mat;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      if(banditx.GetComponent<SplineFollower>().enabled && !bandits.kaybet)
        {
            anim.SetInteger("hareket", 1);
        }
      if(bandits.kaybet && !bndtdmmy.dummykalmadi)
        {
            anim.SetInteger("hareket", 2);
        }

        
        

        if (can <= 0)
        {
            Destroy(gameObject,0.3f);
         //  rb.isKinematic = false;
         //   rb.useGravity = true;
            if (forceapplied == 0)
            {
                //  rb.AddForce(new Vector3(Random.Range(-100, 100), Random.Range(200, 300), Random.Range(-100, 100)));
                GetComponent<BoxCollider>().enabled = false;
                skin.SetActive(false);
                ps.Play();
                forceapplied = 1;
                bandits.deadbandits++;
            }
           // transform.Rotate(1, -1, 1);
        }
    }
    void FixedUpdate()
    {
        if (!buyukucul)
        {
            transform.localScale = new Vector3(bx, by, bz);
        }
        if (buyukucul)
        {
            buyume = true;
            timer += Time.deltaTime;
            if (timer > 0.05f)
            {
                buyume = false;
            }
            if (timer > 0.1f)
            {
                buyukucul = false;
                timer = 0;
            }
            if (buyume == true)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.015f, transform.localScale.y + 0.015f, transform.localScale.z + 0.015f);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.015f, transform.localScale.y - 0.015f, transform.localScale.z - 0.015f);
            }
        }
    }
    public IEnumerator colorRed()
    {
        yield return new WaitForSeconds(0.1f);
        banditShape.GetComponent<SkinnedMeshRenderer>().material = mat[0];
        

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ball" && !bandits.kaybet)
        {
            can--;
            
            buyukucul = true;
            banditShape.GetComponent<SkinnedMeshRenderer>().material = mat[1];
            StartCoroutine(colorRed());
            // transform.DOPunchScale(new Vector3(bx, by, bz), bir, iki, uc);
        }
        if (other.tag == "barrelexp")
        {

            can = 0;


        }
        if (other.tag == "dinamitexp")
        {

            can = 0;
          

        }
        
    }
}
