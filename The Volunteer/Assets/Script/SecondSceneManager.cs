using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecondSceneManager : MonoBehaviour
{
    Text currentText;
    Animator animator;
    public GameObject dealpage;
    float sayım;
    public GameObject kararma;

    AudioSource signSound;

    string[] Texts = 
    {
        "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tWelcome Tom!", 
        "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tThank you for volunteering for our experiment.",
        "\t\t\t\t\t\t\t\t\t\t\t\t\t\tOur experiment has been approved by the government and\n\t\t\t\t\tyou will not be told what kind of experiment you volunteered for due to the confidentiality of the experiment.",
        "\t\t\t\t\t\t\t\t\tWe guarantee that no harm will come to your health during and after the experiment,\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tand that you will not experience any side effects.",
        "\t\t\t\t\t\t\t\tPrior to the experiment, you must sign a procedural agreement. After signing the agreement,\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tyour money will be deposited in your bank account.",
        "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tFrom now on, our nurses will help you.",
        "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tPress E to sign the agreement."
    };

    int textNumber = 0;

    void Start()
    {
        Cursor.visible = false;
        currentText = GetComponent<Text>();
        currentText.text = Texts[0];

        signSound = GetComponent<AudioSource>();
        signSound.Play();

        animator = GameObject.FindGameObjectWithTag("RightArm").GetComponent<Animator>();      
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextText();
        }

        if (currentText.text == Texts[6] && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Sign");
            
            //GameObject.FindGameObjectWithTag("Canvas").SetActive(false);                       
            Destroy(dealpage,1.1f);
        }
        if(dealpage == null)
        {
            kararma.SetActive(true);
            sayım += Time.deltaTime;
            Debug.Log(sayım);
            if(sayım > 1.7f)
            {
              SceneManager.LoadScene(3);
            }
        }
    }

    void NextText()
    {
        if (textNumber < Texts.Length-1)
        {
            textNumber++;
            currentText.text = Texts[textNumber];
        }
    }
}
