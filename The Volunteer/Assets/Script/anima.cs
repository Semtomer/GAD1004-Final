using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anima : MonoBehaviour
{
    Animator anim;
    public GameObject minigame11;
    public GameObject minigame22;
    public GameObject minigame33;
    public GameObject player;
    public GameObject youdied;
    public GameObject kaçış;
    public GameObject credits;
    public GameObject kamera;

    float sayım;
    bool aktif;
    bool aktif2;
    public static bool camsee = false;
    float sayım2;
    float sayım3;
    public GameObject ısınkararma;
   float kararmafalesür;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("x",false);
    }

    void Update()
    {
        if (true)
        {
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A)))
            {
                anim.SetBool("y", true);
            }
            else
            {
                anim.SetBool("y", false);
            }
            if (((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A))) && (Input.GetKey(KeyCode.LeftShift) && (playercontroller.hiscrouch == false)))
            {
                anim.SetBool("k", true);
            }
            else
            {
                anim.SetBool("k", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);     
        }
        if(password.kapıçalış == true)
        {
            anim.SetBool("açıl",true);
            sayım2 += Time.deltaTime;
            if(sayım2 > 2)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = (false);     
                password.kapıçalış = false;
            }
        }
        
        if(aktif == true)
        {
            sayım += Time.deltaTime;
            if(sayım > 1.5f)
            {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        if(aktif2 == true)
        {
            StartCoroutine(ending());
        }

        if(ısınkararma.activeInHierarchy == true)
        {
            kararmafalesür += Time.deltaTime;
            if(kararmafalesür > 1.7f)
            {
                ısınkararma.SetActive(false);
                kararmafalesür = 0;
            }
        }
    }

    void OnTriggerStay(Collider coli)
    {
        if(coli.gameObject.name == "password")
        {
           Cursor.lockState = CursorLockMode.Confined;
           Cursor.visible = (true);
           minigame11.SetActive(true);
        }
        if(coli.gameObject.name == "fazlalık")
        {
            Cursor.lockState = CursorLockMode.Confined;
           Cursor.visible = (true);
           minigame22.SetActive(true);
            Debug.Log("elektrik panaele değdin");
        }
        if(coli.gameObject.name == "kangir")
        {
            gameObject.transform.position = new Vector3(-764,50,-484);
            ısınkararma.SetActive(true);
        }
        if(coli.gameObject.name == "kançık")
        {
            gameObject.transform.position = new Vector3(-768,57,-480);
            ısınkararma.SetActive(true);
        }
        if(coli.gameObject.tag == "camview")
        {
           camsee = true;
        }
        if(coli.gameObject.name == "kasa")
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = (true);
            minigame33.SetActive(true);
        }
    }
    void OnTriggerExit(Collider coli)
    {
        if(coli.gameObject.name == "password")
        {
           Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
            minigame11.SetActive(false);
        }
        if(coli.gameObject.name == "fazlalık")
        {
            Cursor.lockState = CursorLockMode.Confined;
           Cursor.visible = (false);
           minigame22.SetActive(false);
        }
        if(coli.gameObject.tag == "camview")
        {
            camsee = false;
        }
        if(coli.gameObject.name == "kasa")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
            minigame33.SetActive(false);
        }
        
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "asit")
        {
           youdied.SetActive(true);
           aktif = true;
        }
        if(hit.gameObject.tag == "özgürlük")
        {
            kaçış.SetActive(true);
            aktif2 = true;
        }
    }

    IEnumerator ending()
    {
        kamera.SetActive(false);

        yield return new WaitForSeconds(3f);

        kaçış.SetActive(false);
        credits.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }
}
