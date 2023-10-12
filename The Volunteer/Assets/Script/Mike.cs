using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mike : MonoBehaviour
{
    [SerializeField]
    private GameObject _Canvas, TomText, ikinci_Image, _Image, Ucuncu_Image;
    public Text _text, currentText;
    public static bool Konusuyor = true, TimeKosunma = false, ikinciStart = false, birinciStart = true , üçüncüstart = false;
    public GameObject takeit;
    public GameObject sec,ınv,elekt, sec1, ınv1, elekt1;
    public GameObject kararma;
    int textNumber = 0, textNumber1 = 0 ,textnumber2 = 0;
    bool aşı = false,aşı2 = false,kart = false;
   
    string[] Texts =
    {
        "Mike: Hi I'm Mike!",
        "Mike: You are one of the victims who volunteered",
        "Mike: There are things that you don't know. ",
        "Mike: I have a plan to escape from here. ",
        "Mike: Will you join me?",
    };

    string[] Texts1 =
    {
        "Test",

        "Mike: Don't worry. I have a plan, are you in?",
        "Tom:  Yes ",
        "Mike: You need to collect 3 things",
        "Mike: 1. Exterminator Vaccine from Doctor room",
        "Mike: 2. Invisibility Vaccine from Lab",
        "Mike: 3. Security Card from Security room ",
        "Mike: When you collect them, come and see me  ",
        "Tom: Okay ",
    };
    string[] Texts2 =
    {
        "Test",

        "Mike: Did you collect them ?",
        "Tom:  Yes ",
        "Mike: Nice, I will shrink myself with my ability",
        "Mike: ...and you will get me in your pocket",
        "Mike: Talk with Darwin. He knows door password ",
        "Mike: When we pass that door I don't know what there are",
        "Mike: Just be careful and use your powers wisely  ",
        "Tom:  Alright, I will do that ",
    };

    void Start()
    {
        Cursor.visible = false;
        currentText.text = Texts[0];
        _Canvas.SetActive(false);
        TomText.SetActive(false);
        ikinci_Image.SetActive(false);
        Ucuncu_Image.SetActive(false);
    }

    void Update()
    {
        if (_Canvas.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
        }
        else if (_Canvas.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = (true);
            TimeKosunma = true;
        }
        if (textNumber1 >= 8 )
        {
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = (false);
        }
        if (birinciStart == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextText();
            }
        }

        if (ikinciStart == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextText1();
            }
        }

        if(üçüncüstart == true)
        {
            ikinciStart = false;
            birinciStart = false;
            kararma.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                NextText2();
            }
        }

        if (TomText.activeInHierarchy == true)
        {
            StartCoroutine(ExampleCoroutine());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Text")
        {
            _Canvas.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                _Canvas.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Konusuyor = false;
                _Canvas.SetActive(false);
            }
        }
        else if(other.gameObject.name == "ANAHTAR")
        { 
            takeit.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                sec.SetActive(false);
                sec1.SetActive(true);
                takeit.SetActive(false);
                Destroy(other.gameObject);
                kart = true;
            }
        }
        else if(other.gameObject.name == "AŞI 1")
        {
            takeit.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                ınv.SetActive(false);
                ınv1.SetActive(true);
                takeit.SetActive(false);
                Destroy(other.gameObject);
                aşı = true;
            }
        }
        else if(other.gameObject.name == "AŞI 2")
        {
            takeit.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                elekt.SetActive(false);
                elekt1.SetActive(true);
                takeit.SetActive(false);
                Destroy(other.gameObject);
                aşı2 = true;
            }
        }
        if(aşı == true && aşı2 == true && kart == true)
        {
           üçüncüstart = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "ANAHTAR")
        {
            takeit.SetActive(false);
        }
        else if(other.gameObject.name == "AŞI 1")
        {
            takeit.SetActive(false);
        }
        else if(other.gameObject.name == "AŞI 2")
        {
            takeit.SetActive(false);
        }
    }
    
    void NextText()
    {
        if (TimeKosunma == true)
        {
            if (textNumber < Texts.Length - 1)
            {
                textNumber++;
                currentText.text = Texts[textNumber];
            }
            else
            {
                TomText.SetActive(true);
            }
        }
    }

    void NextText1()
    {
        if (TimeKosunma == true)
        {
            if (textNumber1 < Texts1.Length - 1)
            {
                textNumber1++;
                currentText.text = Texts1[textNumber1];
                //Debug.Log(textNumber1);
            }
            else if (textNumber1 == 8 )
            {
               // Debug.Log("Konusuyor " + Konusuyor);
                Konusuyor = false;
                _Image.SetActive(false);
                Ucuncu_Image.SetActive(true);
            }
        }
    }

    void NextText2()
    {
        _Image.SetActive(true);
        if (TimeKosunma == true)
        {
            if (textnumber2 < Texts2.Length - 1)
            {
                textnumber2++;
                currentText.text = Texts2[textnumber2];
               // Debug.Log(textnumber2);
            }
            else if (textnumber2 == 8 )
            {
                StartCoroutine(diğersahne());
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        kararma.SetActive(true);
        yield return new WaitForSeconds(1);
        TomText.SetActive(false);
        //_Image.SetActive(false);
        birinciStart = false;
        ikinci_Image.SetActive(true);
        kararma.SetActive(false);
    }

    public void ikinci_ImageBittir()
    {
        kararma.SetActive(true);
        StartCoroutine(geçiş());
    }

    IEnumerator geçiş()
    {
        yield return new WaitForSeconds(2);
        currentText.text = "Mike: Now you understand, what I'm trying to say";
        ikinci_Image.SetActive(false);
        _Image.SetActive(true);
        ikinciStart = true;
    }
    IEnumerator diğersahne()
    {
        //Konusuyor = true;
        kararma.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(4);
    }
}


