using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playercont2 : MonoBehaviour
{
    CharacterController crt;
    float gravity = -9.8f;
    Vector3 curspeeed = Vector3.zero;
    public float speed = 6;
    float jumphight = 7;
    [HideInInspector] public static bool hiscrouch = false;
    public GameObject soundwall1;
    public GameObject soundwall2;
    private GameObject onbehind;
    bool back = false;
    public TextMeshProUGUI text2;
    float vistime;
    float viswaittime;
    public TextMeshProUGUI text1;
    bool visnext = true;
    public Image ımage1;
    GameObject skas;
    Animator anim;
    
    void Start()
    {
        crt = GetComponent<CharacterController>();
        onbehind = null;
        viswaittime = 30;
        skas = GameObject.FindWithTag("skin");   
    }

    void LateUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = Vector3.zero;
        move = (v*speed*Time.deltaTime*transform.forward + h*speed*Time.deltaTime*transform.right);
        if(crt.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
              curspeeed.y = jumphight;
            }
        }
        if(Input.GetKeyDown(KeyCode.C) && hiscrouch == false)
        {
            hiscrouch = true;/*
            transform.localScale = new Vector3(1,0.5f,1);
            Vector3 pos = transform.position;
            pos.y -= 0.5f;*/
            crt.height = 1.5f;
            speed = 4;

        }
        else if(Input.GetKeyDown(KeyCode.C) && hiscrouch == true)
        {
            hiscrouch = false;/*
            transform.localScale = new Vector3(1,1,1);
            Vector3 pos2 = transform.position;
            pos2.y += 0.5f;*/
            crt.height = 3f;
            speed = 6;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && hiscrouch == false)
        {
           speed = 8;
           soundwall2.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && hiscrouch == false)
        {
            speed = 6;
            soundwall2.SetActive(false);
        }
        if(((Input.GetKey(KeyCode.W))|| (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D))) && hiscrouch == false)
        {
            soundwall1.SetActive(true);
            
        }
        else if(((Input.GetKey(KeyCode.UpArrow))|| (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.DownArrow))) && hiscrouch == false)
        {
           soundwall1.SetActive(true);
        }
        else
        {
            soundwall1.SetActive(false);
            
        }/*
        if(hiscrouch == true)
        {
           if(Input.GetKeyDown(KeyCode.E) && onbehind != null)
            {
              Destroy(onbehind);
            }
            if(back == true)
            {
                text2.text = "(E) give shock";
            }
            else if(back == false)
            {
                text2.text = "";
            }
                    
        }*/
        if(onbehind == null)
        {
            back = false;
        }
         //there is invisible power
         /*
        if(visnext == true)
        {
            viswaittime += Time.deltaTime;
            if(viswaittime >= 30)
            {
                if(Input.GetKeyDown(KeyCode.H))
                {
                  AI.cansee = true;
                  skas.SetActive(false);
                }
                viswaittime = 30; 
            }
        }
        if(AI.cansee == true)
        {
           vistime += Time.deltaTime;
           if((vistime > 10.1))
           {
             AI.cansee = false;
             vistime = 0;
             viswaittime = 0;
             skas.SetActive(true);
           }
        }
        if((vistime < 10) && (viswaittime < 30))
        {
            int a = (int)viswaittime;
            text1.text = a.ToString() + "/30";
            ımage1.enabled = true;
            
        }
        else if((vistime < 10) && AI.cansee == true)
        {
            int b = (int)vistime;
            text1.text = b.ToString() +"/10";
            ımage1.enabled = false;
        }
        else if(viswaittime == 30)
        {
           text1.text = "Redy";
           ımage1.enabled = false;
        }*/
        curspeeed.y += gravity*1.5f*Time.deltaTime;
        crt.Move(move);
        crt.Move(curspeeed*Time.deltaTime);
    }
    void OnTriggerEnter(Collider coli)
    {
        if(coli.gameObject.tag == "back")
        {
            //Debug.Log("arkadasın");
            AI aı = coli.gameObject.GetComponentInParent<AI>();
            onbehind = aı.gameObject;
            back = true;
        }
    }
    void OnTriggerExit(Collider coli)
    {
        if(coli.gameObject.tag == "back")
        {
            //Debug.Log("çıktın");
            onbehind = null;
            back = false;
        }
    }
}
