using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpool : MonoBehaviour
{
    public static bulletpool main;
    public GameObject bulletprefab;
    public int poolsize;
    private List<bullet> availablebullets;
    private void Awake()
    {
        main = this;
    }
    void Start()
    {
        availablebullets = new List<bullet>();
        for (int i = 0; i < poolsize; i++)
        {
            bullet b = Instantiate(bulletprefab, transform).GetComponent<bullet>();
            b.gameObject.SetActive(false);
            availablebullets.Add(b);
        }
    }

   
    void Update()
    {
        
    }

    public void pickFromPool(Vector3 position,Vector3 velocity)
    {
        if (availablebullets.Count < 1) return;
        availablebullets[0].Activate(position, velocity);
        availablebullets.RemoveAt(0);
        
    }
    public void AddToPool(bullet Bullet)
    {
        if (!availablebullets.Contains(Bullet)) availablebullets.Add(Bullet);
    }
}
