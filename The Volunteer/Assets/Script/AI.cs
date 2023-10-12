using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
    public Transform target;
    private Transform target2;
    public Transform[] pointstogo;
    bool timetogo = true;
    float waittime;
    int rast;
    public int maxrand;
    bool exittheview = false;
    float extrafollow;
    static public bool cansee = false;
    public static bool walksound = false, runsound = false ;
    public LayerMask lay;
    NavMeshAgent agentt;
    Rigidbody rigi;
    Animator anim;
    //public bool friendly;
    public bool friendly = true; 
    public GameObject youcaught;
    public bool gece = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
        agentt = GetComponent<NavMeshAgent>();
        rast = Random.Range(0,maxrand);
        target2 = GameObject.FindWithTag("Wall").transform;
    }

    void Update()
    {
        agentt.SetDestination(pointstogo[rast].position);
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        float dis = Vector3.Distance(transform.position,target.position);
        Vector3 targetDir2 = target2.position - transform.position;
        float angle2 = Vector3.Angle(targetDir2, transform.forward);
        float dis2 = Vector3.Distance(transform.position,target2.position);
        if(walksound && cansee == false)
        {
            //if(friendly == true)
           // {
              agentt.SetDestination(target.position);
              agentt.speed = 7;
              anim.SetBool("koşma",true);
            //}
        }
        else if(runsound && cansee == false)
        {
            //if(friendly == true)
           // {
              agentt.SetDestination(target.position);
              agentt.speed = 7;
              anim.SetBool("koşma",true);
           // }
        }
        else
        {
           anim.SetBool("koşma",false);
        }
        if(anima.camsee == true && cansee == false)
        {
           //if(friendly == true)
           //{
              agentt.SetDestination(target.position);
              agentt.speed = 7;
              anim.SetBool("koşma",true);
          // }
        }
        else if(anima.camsee == false && cansee == false)
        {
            agentt.SetDestination(pointstogo[rast].position);
            agentt.speed = 3.5f;
            anim.SetBool("koşma",false);
            //print("çıktım camden");
        }

        if((dis > dis2) && (angle2 < 45) && (walksound == false) && runsound == false)
        {
            if((angle2 < 45) && (dis2 < 20))//angle = normal açı derecesi
            {                                  // dis = duğrudan kaç birimse o kadar
                print("oyuncu değil");
            }
        }
        else if((dis2 > dis) && (cansee == false) && (walksound == false) && runsound == false)
        {
            if((angle < 90.0f) && (dis < 20))
            {
                if(friendly == true)
                {
                agentt.SetDestination(target.position);
                agentt.speed = 7;
                waittime = 4;
                print("oyuncu");
                exittheview = true;
                anim.SetBool("koşma",true);
                }            }
            else
            { 
                if((exittheview == true))
                { 
                   extrafollow += Time.deltaTime;
                   if(extrafollow < 3)
                   {
                     if(friendly == true)
                     {
                      agentt.SetDestination(target.position);
                      agentt.speed = 7;
                      anim.SetBool("koşma",true);
                     }
                   }
                   else
                   {
                       extrafollow = 0;
                       exittheview = false;
                   }
                }
                else
                {
                  agentt.SetDestination(pointstogo[rast].position);
                  agentt.speed = 3.5f;
                  anim.SetBool("koşma",false);
                }
                if(gece == false)
                {
                  rigi.isKinematic = false;
                }
                
            }
        }
        
        if(timetogo == false)
        {
           waittime += Time.deltaTime;
           if( waittime < 3)
           {
               agentt.speed = 0;
               anim.SetBool("bekleme",true);
           }
           else
           {
               agentt.speed = 3.5f;
               timetogo = true;
               waittime = 0;
               anim.SetBool("bekleme",false);
           }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.transform == target)
        {
            //youcaught.SetActive(true);
            //if(friendly == true)
            //{
              StartCoroutine(yakalanma());
           // }
            //Vector3 pos = transform.position;
            if(gece == false)
            {
               rigi.isKinematic = true;
            }
            
        }/*
        else if(collision.gameObject.layer == lay)
        {
           rigi.isKinematic = true;
        }*/
    }
    public void OnCollisionExit(Collision coli)
    {
        /*if(coli.gameObject.layer == lay)
        {
           rigi.isKinematic = false;
        }*/
    }
    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.transform == pointstogo[rast])
        {
           rast = Random.Range(0,maxrand);
           //print(rast);
           timetogo = false;
        }
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "walksoundhear")
        {
            walksound = true;
        }
        else if(collider.gameObject.name == "runsoundhear")
        {
            runsound = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.name == "walksoundhear")
        {
            walksound = false;
        }
        if(collider.gameObject.name == "runsoundhear")
        {
            runsound = false;
        }
    }
    IEnumerator yakalanma()
    {
        youcaught.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
