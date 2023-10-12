using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class password : MonoBehaviour
{
    public string Input;
    public Text write;
    public string code = "2563";
    int maxstring = 4;
    bool pass = false;
    Animator anim;
    public GameObject door1;
    public static bool kapıçalış = false;
    void Start()
    {
       anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        write.text = Input;
        if(Input == code && Input.Length == maxstring)
        {
            //anim.SetBool("açılbek",true);
            kapıçalış = true;
            Destroy(door1,1.5f);
            gameObject.SetActive(false);
            
            
        }
        if(Input != code && Input.Length >= maxstring)
        {
            Input = "";
        }
    }
    public void one()
    {
       Input = Input + "1";
    }
    public void two()
    {
        Input = Input + "2";
    }
    public void three()
    {
        Input = Input + "3";
    }
    public void four()
    {
        Input = Input + "4";
    }
    public void five()
    {
        Input = Input + "5";
    }
    public void six()
    {
        Input = Input + "6";
    }
    public void seven()
    {
        Input = Input + "7";
    }
    public void eight()
    {
        Input = Input + "8";
    }
    public void nine()
    {
        Input = Input + "9";
    }
}
