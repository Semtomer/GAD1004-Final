using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crazyman : MonoBehaviour
{
    int textNumber = 0 , textNumber2 = 0;
    public TextMeshProUGUI currentText;
    //bool TimeKosunma;
    bool ilkonuşma = false, ikincikonuşma = false;
    public GameObject konuşmalar , görevtablosu , görevyazısı, görevyazısı1, aldın;
    bool bir = true,iki = false,üç = false;
    void Start()
    {
        
    }
    string[] Texts =
    {
        "Crazy Darwin: Yes, I know know know ",
        "Tom: Can you tell me ?",
        "Crazy Darwin: Yes yes, but I want something from you ",
        "Tom: What do you want ?",
        "Crazy Darwin: Mmm... Bring me some Morfin from Nurse room",
        "Tom: Ahhh alright",
    };
    string[] Texts2 =
    {
        "text",
        "Crazy Darwin: There it is",
        "Tom: Now, tell me the password",
        "Crazy Darwin: Okay child ",
        "Crazy Darwin: Password is '2563' ",
    };

    // Update is called once per frame
    void Update()
    {
        if(üç == true)
        {
           if(konuşmalar.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = (true);
        }
        else if(konuşmalar.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
        }
        }
        
        if(ilkonuşma == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                NextText();
            }
           
        }
        if(ikincikonuşma == true)
        {
            ilkonuşma = false;
            if(Input.GetMouseButtonDown(0))
            {
                NextText2();
            }
        }
    }
    void OnTriggerStay(Collider coli)
    {
       if(coli.gameObject.tag == "Text")
       {
           if(bir == true)
           {
              konuşmalar.SetActive(true);
              ilkonuşma = true;
           }
           else if(iki == true)
           {
               konuşmalar.SetActive(true);
               ikincikonuşma = true;
           }
           üç = true;
       }
       if(coli.gameObject.name == "Morfin")
       {
           aldın.SetActive(true);
           if(Input.GetKeyDown(KeyCode.E))
           {
               Destroy(coli.gameObject);
               görevyazısı1.SetActive(false);
               görevyazısı.SetActive(true);
               iki = true;
               ikincikonuşma = true;
               aldın.SetActive(false);
           }
       }
    }
    void OnTriggerExit(Collider coli)
    {
       if(coli.gameObject.name == "Morfin")
       {
           aldın.SetActive(false);
       }
       üç = false;
    }
    void NextText()
    {
        if (ilkonuşma == true)
        {
            if (textNumber < Texts.Length - 1)
            {
                textNumber++;
                currentText.text = Texts[textNumber];
            }
            else
            {
                ilkonuşma = false;
                konuşmalar.SetActive(false);
                bir = false;
                görevtablosu.SetActive(true);
            }
        }
    }
    void NextText2()
    {
        if (ikincikonuşma == true)
        {
            if (textNumber2 < Texts2.Length - 1)
            {
                textNumber2++;
                currentText.text = Texts2[textNumber2];
            }
            else
            {
                ikincikonuşma = false;
                konuşmalar.SetActive(false);
                görevtablosu.SetActive(false);
            }
        }
    }
}
