using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    public Button[] k1;
    public Button[] y1;
    public Button[] s1;
    public Button[] m1;
   bool K1 = true,K2 = true,K3 = true,K4 = true,K5 = true;
   bool Y1 = true,Y2 = true,Y3 = true,Y4 = true,Y5 = true;
   bool S1 = true,S2 = true,S3 = true,S4 = true,S5 = true;
   bool M1 = true,M2 = true,M3 = true,M4 = true,M5 = true;
   bool O = true;
   public GameObject door2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy == false)
        {
           Cursor.lockState = CursorLockMode.Locked;
        }
        else if(gameObject.activeInHierarchy ==  true)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(((Y1 && Y2 && Y3 && Y4 && Y5) == false) && ((K1 && K2 && K3 && K4 && K5) == false) && ((S1 && S2 && S3 && S4 && S5) == false) && ((M1 && M2 && M3 && M4 && M5) == false) && O == false)
        {
           Destroy(door2);
           gameObject.SetActive(false);
        }
    }
    public void kırmızı1()
    {
       K1 = false;
       if(K1 == false)
       {
          k1[1].transform.Rotate(0,0,-90);
       }
       
       
    }
    public void kırmızı2()
    {
       K2 = false;
       if(K2 == false)
       {
         k1[0].transform.Rotate(0,0,-90);
       }
       
    }
    public void kırmızı3()
    {
       K3 = false;
       if(K3 == false)
       k1[2].transform.Rotate(0,0,-90);
    }
    public void kırmızı4()
    {
       K4 = false;
       if(K4 == false)
       k1[3].transform.Rotate(0,0,-90);
    }
    public void kırmızı5()
    {
       K5 = false;
       if(K5 == false)
       k1[4].transform.Rotate(0,0,-90);
    }
    public void yeşil1()
    {
       Y1 = false;
       y1[1].transform.Rotate(0,0,-90);
    }
    public void yeşil2()
    {
       Y2 = false;
       y1[0].transform.Rotate(0,0,-90);
    }
    public void yeşil3()
    {
       Y3 = false;
       y1[2].transform.Rotate(0,0,-90);
    }
    public void yeşil4()
    {
       Y4 = false;
       y1[3].transform.Rotate(0,0,-90);
    }
    public void yeşil5()
    {
       Y5 = false;
       y1[4].transform.Rotate(0,0,-90);
    }

    public void sarı1()
    {
       S1 = false;
       s1[1].transform.Rotate(0,0,-90);
    }
    public void sarı2()
    {
       S2 = false;
       s1[0].transform.Rotate(0,0,-90);
    }
    public void sarı3()
    {
       S3 = false;
       s1[2].transform.Rotate(0,0,-90);
    }
    public void sarı4()
    {
       S4 = false;
       s1[3].transform.Rotate(0,0,-90);
    }
    public void sarı5()
    {
        S5 = false;
       s1[4].transform.Rotate(0,0,-90);
    }

    public void mavi1()
    {
       M1 = false;
       m1[1].transform.Rotate(0,0,-90);
    }
    public void mavi2()
    {
       M2 = false;
       m1[0].transform.Rotate(0,0,-90);
    }
    public void mavi3()
    {
       M3 = false;
       m1[2].transform.Rotate(0,0,-90);
    }
    public void mavi4()
    {
      M4 = false;
       m1[3].transform.Rotate(0,0,-90);
    }
    public void mavi5()
    {
       M5 = false;
       m1[4].transform.Rotate(0,0,-90);
    }

    public void onay()
    {
       O = false;
    }
}
