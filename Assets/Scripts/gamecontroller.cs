using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamecontroller : MonoBehaviour
{
    public GameObject wp, gop, startbuton,tts,tts2;
    public static bool start;
    float timer;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        bandits.kazan = false;
        tank.tankyokedildi = false;
        
        //startbuton.SetActive(true);
        start = false;
        wp.SetActive(false);
        gop.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(tank.tankyokedildi || bandits.kazan )
        {
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                wp.SetActive(true);
            }
            
        }
        if (bandits.kaybet || tank.kaybet)
        {
            timer += Time.deltaTime;
            if (timer > 2.5f)
            {
                gop.SetActive(true);
            }
           
        }
    }

    public void butonsec(int butonNo)
    {
        if(butonNo == 1)//restart
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (butonNo == 2)//nextlevel
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(2);
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(3);
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(1);
            }

        }
        if (butonNo == 3)
        {
           
         /*  start = true;
            startbuton.SetActive(false);
            tts.SetActive(false);
            tts2.SetActive(true);*/
        }
    }


}
