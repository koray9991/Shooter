using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float lifetime;
    public GameObject ps;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void Activate( Vector3 position,Vector3 velocity)
    {
        transform.position = position;
        rb.velocity = velocity;
        gameObject.SetActive(true);
        
        StartCoroutine("Decay");
    }
    private IEnumerator Decay()
    {
        yield return new WaitForSeconds(lifetime);
        Deactivate();
    }
   
    public void Deactivate()
    {
        bulletpool.main.AddToPool(this);
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tank")
        {
            Deactivate();
        }
        
        if (other.tag == "dinamit")
        {
            Deactivate();
        }
        if (other.tag == "barrel")
        {
            Deactivate();
        }
        if (other.tag == "bandit")
        {
            Deactivate();
        }
        if (other.tag == "ground")
        {
            if ((SceneManager.GetActiveScene().buildIndex == 0))
            {
                Instantiate(ps, new Vector3(transform.position.x, 1.28f, transform.position.z), Quaternion.Euler(90, 0, 0));
            }
            if ((SceneManager.GetActiveScene().buildIndex == 1))
            {
                Instantiate(ps, new Vector3(transform.position.x, 1.28f, transform.position.z), Quaternion.Euler(90, 0, 0));
            }
            if ((SceneManager.GetActiveScene().buildIndex == 2))
            {
                Instantiate(ps, new Vector3(transform.position.x, 1.35f, transform.position.z), Quaternion.Euler(90, 0, 0));
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
      
    }
}
