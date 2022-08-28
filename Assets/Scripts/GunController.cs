using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GunController : MonoBehaviour
{
    private static GunController instance;
    public static GunController Instance { get => instance; set => instance = value; }

    [SerializeField]
    RectTransform cross;
    [SerializeField]
    LayerMask layerMask;
    public GameObject Gun;
   
    [SerializeField]
    float attackCoolDown;
    public GameObject tankx;
    public bool tankbool;
    public bool banditbool;
    float waitForAttack;
    public GameObject muzzle;
    Vector2 firstPosition, tempPosition;
    public GameObject followspline;
    bool onClick;
    public GameObject banditx;
    public GameObject particle;
    public Image Crosshair;
    bool crosshairBool;
    public bool buyume;
    float timer;
    public GameObject tts;
    public bool Intro;
    public float IntroTimer;
    public GameObject BackwardSpline;
    public float LookDummyTime;
    public float IntroFalseTimer;
    public float GunActiveTimer;
    public Transform GunPos;
    public float step;
    public GameObject Table,arrow1,arrow2,arrow3,arrow4;
  
    private void Awake()
    {
        if (instance == null)
            instance = this;
        Intro = true;
    }

    void Start()
    {
        Crosshair.enabled = false;
        waitForAttack = 0;
        onClick = false;
     
        firstPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        tempPosition = Vector2.zero;
       
       
        

    }
    private void FixedUpdate()
    {
        if (Intro)
        {
            IntroTimer += Time.deltaTime;
            if (IntroTimer > LookDummyTime)
            {
                Camera.main.GetComponent<SplineFollower>().enabled = true;
                BackwardSpline.GetComponent<SplineFollower>().enabled = true;
            }
            if (IntroTimer > GunActiveTimer)
            {
                BackwardSpline.GetComponent<SplineFollower>().enabled = false;
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, GunPos.localRotation, step);
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, GunPos.localPosition, step / 190f);

            }
            if (IntroTimer > IntroFalseTimer)
            {
                Intro = false;
                Crosshair.enabled = true;
                Camera.main.GetComponent<SplineFollower>().enabled = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

       

        if (crosshairBool)
        {
            buyume = true;
            timer += Time.deltaTime;
            if (timer > 0.03f)
            {
                buyume = false;
            }
            if (timer > 0.06f)
            {
                crosshairBool = false;
                timer = 0;
            }
            if (buyume == true)
            {
                Crosshair.rectTransform.localScale = new Vector3(transform.localScale.x + 0.3f, transform.localScale.y + 0.3f, transform.localScale.z + 0.3f);
            }
            else
            {
                Crosshair.rectTransform.localScale = new Vector3(transform.localScale.x - 0.3f, transform.localScale.y - 0.3f, transform.localScale.z - 0.3f);
            }
        }
        else
        {
           Crosshair.rectTransform.localScale  = new Vector3(0.88f, 0.88f, 1);
        }
        if (Input.GetMouseButton(0) && !Intro)
        {
            tts.SetActive(false);
                Gun.GetComponent<Animator>().SetFloat("multiplier", 1f);

            Table.GetComponent<Rigidbody>().useGravity = true;
            
                arrow1.SetActive(false);
                arrow2.SetActive(false);
            
           
            if (tankbool)
            {
                if ( !tank.tankyokedildi && !tank.kaybet)
                {
                    tankx.GetComponent<SplineFollower>().enabled = true;
                    Camera.main.GetComponent<SplineFollower>().enabled = true;
                    Camera.main.GetComponent<SplineFollower>().direction = Spline.Direction.Forward;
                    if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 3)
                    {
                        Camera.main.GetComponent<SplineFollower>().followSpeed = 0.5f;
                    }
                    if (SceneManager.GetActiveScene().buildIndex == 1)
                    {
                        Camera.main.GetComponent<SplineFollower>().followSpeed = 0.44f;
                    }
                }
                else
                {
                    Camera.main.GetComponent<SplineFollower>().enabled = false;
                }
            }
           
            
            if (banditbool)
            {
                if (!bandits.kaybet && !bandits.kazan)
                {
                    Camera.main.GetComponent<SplineFollower>().enabled = true;
                    Camera.main.GetComponent<SplineFollower>().direction = Spline.Direction.Forward;
                    banditx.GetComponent<SplineFollower>().enabled = true;
                    followspline.GetComponent<SplineFollower>().enabled = true;
                    if (SceneManager.GetActiveScene().buildIndex == 2)
                    {
                        Camera.main.GetComponent<SplineFollower>().followSpeed = 2.5f;
                    }
                }
                else
                {
                  //  followspline.GetComponent<SplineFollower>().enabled = false;
                    Camera.main.GetComponent<SplineFollower>().enabled = false;
                }
            }
            }
        else
        {
           Gun.GetComponent<Animator>().SetFloat("multiplier", 0.0001f);
        }
 

        GunMoves();
        if (isMouseOnScreen())
        {
            if (Input.GetMouseButtonDown(0) && !Intro)
            {
                tempPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                onClick = true;
                //Debug.Log("X: " + firstPosition.x);
                //Debug.Log("Y: " + firstPosition.y);
            }
            else if (Input.GetMouseButtonUp(0) && !Intro)
            {
                onClick = false;
                firstPosition = cross.position;
            }
            else if (onClick && !Intro)
            {
                SetCrossHair();
                Shoot();
            }
        }
        else
            onClick = false;
    }

    private void SetCrossHair()
    {
        Vector2 mouseDifference = tempPosition - new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 pos = firstPosition - mouseDifference;
        if (pos.x < 0)
            pos.x = 0;
        else if (pos.x > Screen.width)
            pos.x = Screen.width;
        if (pos.y < 0)
            pos.y = 0;
        else if (pos.y > Screen.height)
            pos.y = Screen.height;
        cross.position = pos;
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(cross.position);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            transform.LookAt(hit.point);
            if (waitForAttack > attackCoolDown)
            {
                waitForAttack = 0;
                muzzle.GetComponent<ParticleSystem>().Play();
                /// GetComponent<Animator>().SetTrigger("Shoot");

                if (hit.transform.gameObject.CompareTag("tank"))
                {
                    crosshairBool = true;
                  tank.instance.ps.GetComponent<ParticleSystem>().Play();
                  tank.instance.  can -= 2;
                    tank.instance.canbar.fillAmount = tank.instance.can / tank.instance.maxcan;
                    tank.instance.buyukucul = true;
                    tank.instance.TankShape1.GetComponent<MeshRenderer>().material = tank.instance.mat[1];
                    tank.instance.TankShape2.GetComponent<MeshRenderer>().material = tank.instance.mat[1];
                    tank.instance.StartCoroutine(tank.instance.colorRed());
                  //  Instantiate(particle, hit.transform.position, Quaternion.Euler(90, 0, 0));
                }
                else if (hit.transform.gameObject.CompareTag("dinamit"))
                {
                    crosshairBool = true;
                    hit.transform.gameObject.GetComponent<dinamit>().say++;
                    hit.transform.gameObject.GetComponent<dinamit>().kactakac.text = hit.transform.gameObject.GetComponent<dinamit>().say + " / " + hit.transform.gameObject.GetComponent<dinamit>().maxsay;
                    hit.transform.gameObject.GetComponent<dinamit>().buyukucul = true;
                    Instantiate(particle, hit.transform.position, Quaternion.Euler(90, 0, 0));
                }
                else if (hit.transform.gameObject.CompareTag("barrel"))
                {
                    crosshairBool = true;
                    hit.transform.gameObject.GetComponent<barrel>().say++;
                    hit.transform.gameObject.GetComponent<barrel>().kactakac.text = hit.transform.gameObject.GetComponent<barrel>().say + " / " + hit.transform.gameObject.GetComponent<barrel>().maxsay;
                    hit.transform.gameObject.GetComponent<barrel>().buyukucul = true;
                    Instantiate(particle, hit.transform.position, Quaternion.Euler(90, 0, 0));
                }
                else if (hit.transform.gameObject.CompareTag("bandit") && !bandits.kaybet)
                {
                    hit.transform.gameObject.GetComponent<bandit>().can--;
                    crosshairBool = true;
                    hit.transform.gameObject.GetComponent<bandit>().buyukucul = true;
                    hit.transform.gameObject.GetComponent<bandit>().banditShape.GetComponent<SkinnedMeshRenderer>().material = hit.transform.gameObject.GetComponent<bandit>().mat[1];
                    hit.transform.gameObject.GetComponent<bandit>().StartCoroutine(hit.transform.gameObject.GetComponent<bandit>().colorRed());
                    Instantiate(particle, hit.transform.position, Quaternion.Euler(90, 0, 0));
                }
                else if (hit.transform.gameObject.CompareTag("ground"))
                {
                 
                    Instantiate(particle, hit.point, Quaternion.Euler(90, 0, 0));
                }
                // Instantiate(bulletHolePref, hit.point, new Quaternion(0, 0, 0, 0));*/
            }
        }
    }
    private void GunMoves()
    {
        waitForAttack += Time.deltaTime;
    }
    bool isMouseOnScreen()
    {
        if (Input.mousePosition.x > Screen.width || Input.mousePosition.y > Screen.height || Input.mousePosition.x < 0 || Input.mousePosition.y < 0)
            return false;
        return true;
    }
}
