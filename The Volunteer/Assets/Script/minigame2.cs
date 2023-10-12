using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame2 : MonoBehaviour
{
    public Button[] mini1;
    bool m1 = true,m2 = true,m3 = true,m4 = true;
    bool O = true;
    Animator anim;
    public static bool miko = false;
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if(gameObject.activeInHierarchy == false)
        {
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = (false);
        }
        else if(gameObject.activeInHierarchy ==  true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = (true);
        }
        if(m1 == false&&m2== false&&m3 == false && O == false)
        {
           miko = true;
           gameObject.SetActive(false);
        }
    }
    public void minik1()
    {
       m1 = false;
       if(m1 == false)
       {
          mini1[0].transform.Rotate(0,0,-90);
       } 
       
    }
     public void minik2()
    {
       m2 = false;
       if(m2 == false)
       {
          mini1[1].transform.Rotate(0,0,-90);
       } 
       
    }
     public void minik3()
    {
       m3 = false;
       if(m3 == false)
       {
          mini1[2].transform.Rotate(0,0,-90);
       } 
       
    }
    public void reboot()
    {
        O = false;
    }

}
