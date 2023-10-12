using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    CharacterController crt;
    float gravity = -9.8f;
    Vector3 curspeeed = Vector3.zero;
    public float speed = 6;
    float jumphight = 7;
    [HideInInspector] public static bool hiscrouch = false, coktu = false;
    public GameObject soundwall1;
    public GameObject soundwall2;
    private GameObject onbehind;
    public GameObject lelelelel;
    bool back = false;
    public TextMeshProUGUI text2;
    float vistime;
    float viswaittime;
    public TextMeshProUGUI text1;
    bool visnext = true;
    public Image ımage1;
    //public GameObject skas;
    Animator anim;
    private SkinnedMeshRenderer skinmesh;
    public Material firstMaterial, secondMaterial;
    public bool skillactive = false, HBasıldı = false;
    public AudioSource CokerekSes, NormalOyunSesi, ElektrikPanel;
    public static bool camerasee = false;

    void Start()
    {
        crt = GetComponent<CharacterController>();
        onbehind = null;
        viswaittime = 30;
        //skas = GameObject.FindWithTag("skin");
        skinmesh = GameObject.FindWithTag("skin").GetComponent<SkinnedMeshRenderer>();
        skinmesh.material = firstMaterial;
        NormalOyunSesi.Play();
    }

    void LateUpdate()
    {
        if (true)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = Vector3.zero;
            move = (v * speed * Time.deltaTime * transform.forward + h * speed * Time.deltaTime * transform.right);
            if (crt.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    curspeeed.y = jumphight;
                }
            }
            if (Input.GetKeyDown(KeyCode.C) && hiscrouch == false)
            {
                hiscrouch = true;/*
            transform.localScale = new Vector3(1,0.5f,1);
            Vector3 pos = transform.position;
            pos.y -= 0.5f;*/
                crt.height = 1.5f;
                speed = 4;
                CokerekSes.Play();
                coktu = true;
            }
            else if (Input.GetKeyDown(KeyCode.C) && hiscrouch == true)
            {
                hiscrouch = false;/*
            transform.localScale = new Vector3(1,1,1);
            Vector3 pos2 = transform.position;
            pos2.y += 0.5f;*/
                crt.height = 3f;
                speed = 6;
                CokerekSes.Pause();
                coktu = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && hiscrouch == false)
            {
                speed = 8;
                soundwall2.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) && hiscrouch == false)
            {
                speed = 6;
                soundwall2.SetActive(false);
            }

            if (((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D))) && hiscrouch == false)
            {
                soundwall1.SetActive(true);

            }
            else if (((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.DownArrow))) && hiscrouch == false)
            {
                soundwall1.SetActive(true);
            }
            else
            {
                soundwall1.SetActive(false);

            }

            if (hiscrouch == true && skillactive == true)
            {
                if (Input.GetKeyDown(KeyCode.E) && onbehind != null)
                {
                    Destroy(onbehind);
                }
                if (back == true)
                {
                    text2.text = "(E) give shock";
                }
                else if (back == false)
                {
                    text2.text = "";
                }
            }

            if (onbehind == null)
            {
                back = false;
            }
            //there is invisible power
            if (visnext == true && skillactive == true)
            {
                viswaittime += Time.deltaTime;
                if (viswaittime >= 30)
                {
                    if (Input.GetKeyDown(KeyCode.H))
                    {
                        AI.cansee = true;
                        //skas.SetActive(false);
                        skinmesh.material = secondMaterial;
                        HBasıldı = true;
                        print("Hbasıldı");
                           
                    }
                    viswaittime = 30;
                }
            }
            if (AI.cansee == true && skillactive == true)
            {
                vistime += Time.deltaTime;
                if ((vistime > 10.1))
                {
                    AI.cansee = false;
                    vistime = 0;
                    viswaittime = 0;
                    //skas.SetActive(true);
                    skinmesh.material = firstMaterial;
                    HBasıldı = false;
                    print("Hb falseı");
                }
            }
            if ((vistime < 10) && (viswaittime < 30) && skillactive == true)
            {
                int a = (int)viswaittime;
                text1.text = a.ToString() + "/30";
                ımage1.enabled = true;
            }
            else if ((vistime < 10) && AI.cansee == true && skillactive == true)
            {
                int b = (int)vistime;
                text1.text = b.ToString() + "/10";
                ımage1.enabled = false;
            }
            else if (viswaittime == 30 && skillactive == true)
            {
                text1.text = "Ready";
                ımage1.enabled = false;
               
            }
            curspeeed.y += gravity * 1.5f * Time.deltaTime;
            crt.Move(move);
            crt.Move(curspeeed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider coli)
    {
        if (coli.gameObject.tag == "back")
        {
            //Debug.Log("çıktın");
            onbehind = null;
            back = false;
        }

        if (coli.gameObject.tag == "ElektrikPanel")
        {
            NormalOyunSesi.Play();
            ElektrikPanel.Pause();
           // Debug.Log("elektrik panelden çıktın");
        }

        if (coli.gameObject.name == "Floorr1")
        {
            LightOp.tur = 4;
        }
    }

    private void OnTriggerEnter(Collider coli)
    {
        if (coli.gameObject.tag == "back")
        {
            //Debug.Log("arkadasın");
            AI aı = coli.gameObject.GetComponentInParent<AI>();
            onbehind = aı.gameObject;
            back = true;
        }

        if (coli.gameObject.tag == "ElektrikPanel")
        {
            NormalOyunSesi.Pause();
            ElektrikPanel.Play();
            //Debug.Log("elektrik panaele değdin");
        }

        if (coli.gameObject.name == "IlkIsıkAc")
        {
            LightOp.tur = 2;
            LightGece.tur2 = 2;
        }
        else if (coli.gameObject.name == "IlkKapat")
        {
            LightOp.tur = 1;
            LightGece.tur2 = 1;
        }
        else if (coli.gameObject.name == "Cikis")
        {
            LightGece.tur2 = 3;
        }
        else if (coli.gameObject.name == "Cikis2")
        {
            LightGece.tur2 = 4;
        }
        else if (coli.gameObject.name == "YerAlti")
        {
            LightGece.tur2 = 5;
        }
        else if (coli.gameObject.name == "Floor")
        {
            LightGece.tur2 = 6;
        }

        if (coli.gameObject.tag == "Alarm"  )
        {
            print("olmen lazım");
            if (HBasıldı == false)
            {
                StartCoroutine(yakalanma());
            }
        }

        if (coli.gameObject.name == "Floorr1")
        {
            LightOp.tur = 4;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Floorr2")
        {
            LightOp.tur = 3;
        }
    }

    IEnumerator yakalanma()
    {
        lelelelel.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
