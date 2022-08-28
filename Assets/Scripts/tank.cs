using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Splines;
using TMPro;
public class tank : MonoBehaviour
{
    public GameObject ps;
    public Image canbar;
    public float maxcan, can;
   public bool buyukucul;
    float timer;
    bool buyume;
    public float bx, by, bz;
    public GameObject bone;
    public GameObject destroyps;
    public int tankdestroy;
    public GameObject canvas;
    public GameObject bone2, obj1, obj2, obj3, obj4, obj5, obj6;
    public GameObject camgun;
    public static bool tankyokedildi;
    public static bool kaybet;
    float tankatesetmetimer;
    public GameObject tankates;
   public static int tankatesint;
    public TextMeshPro cantext;
    public GameObject TankShape1, TankShape2;
    public Material[] mat;
    public static tank instance;
    public GameObject FireParticle;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        kaybet = false;
        tankyokedildi = false;
        can = maxcan;
        tankatesint = 0;
        canbar.fillAmount = can / maxcan;
    }

    // Update is called once per frame
    void Update()
    {
        if (can < maxcan / 2 && can>0)
        {
            FireParticle.SetActive(true);
        }
        else
        {
            FireParticle.SetActive(false);
        }
        cantext.text = can + " / " + maxcan;
        if (can <= 0)
        {
            GetComponent<SplineFollower>().followSpeed = 0;
            camgun.GetComponent<SplineFollower>().followSpeed = 0;
            GetComponent<BoxCollider>().enabled = false;
            bone.SetActive(false);
            bone2.SetActive(true);
            tankyokedildi = true;
            if (tankdestroy == 0)
            {
                destroyps.SetActive(true);
                destroyps.GetComponent<ParticleSystem>().Play();
                obj1.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-300, 300), Random.Range(300, 500), Random.Range(-300, 300)));
                obj2.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-300, 300), Random.Range(300, 500), Random.Range(-300, 300)));
                obj3.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-300, 300), Random.Range(300, 500), Random.Range(-300, 300)));
                obj4.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-300, 300), Random.Range(300, 500), Random.Range(-300, 300)));
                obj5.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-300, 300), Random.Range(300, 500), Random.Range(-300, 300)));
                obj6.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-300, 300), Random.Range(300, 500), Random.Range(-300, 300)));
            }
            tankdestroy = 1;
            canvas.SetActive(false);
            obj1.transform.Rotate(1, 2, 3);
            obj2.transform.Rotate(-1, -1, -3);
            obj3.transform.Rotate(1, -1, 1);
            obj4.transform.Rotate(-2, 1, 1);
            obj5.transform.Rotate(1, -1, 1);
            obj6.transform.Rotate(-1, -2, 2);


        }
        if (kaybet)
        {
            GetComponent<BoxCollider>().enabled = false;
            tankatesetmetimer += Time.deltaTime;
            if (tankatesetmetimer > 2f )
            {
                tankates.SetActive(true);
                if (tankatesint == 0)
                {
                    tankates.GetComponent<ParticleSystem>().Play();
                }
                tankatesint = 1;
            }
        }
    }
    private void FixedUpdate()
    {


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
                transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z + 0.2f);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f, transform.localScale.z - 0.2f);
            }
        }
    }

    public IEnumerator colorRed()
    {
        yield return new WaitForSeconds(0.1f);
        TankShape1.GetComponent<MeshRenderer>().material = mat[0];
        TankShape2.GetComponent<MeshRenderer>().material = mat[0];

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            ps.GetComponent<ParticleSystem>().Play();
            can -= 5;
            canbar.fillAmount = can / maxcan;
            buyukucul = true;
            TankShape1.GetComponent<MeshRenderer>().material = mat[1];
            TankShape2.GetComponent<MeshRenderer>().material = mat[1];
            StartCoroutine(colorRed());

        }
        if (other.tag == "dinamitexp")
        {
            
            can -= 50;
            canbar.fillAmount = can / maxcan;

        }
        if(other.tag == "finish")
        {
            kaybet = true;
            GetComponent<SplineFollower>().followSpeed = 0;
        }
        if (other.tag == "barrelexp")
        {

            can -= 50;
            canbar.fillAmount = can / maxcan;

        }
    }
}
