using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public GameObject firstImage, secondImage, thirdImage, HowToPlayScreen;
    bool sFImage, sSImage, sTImage;

    private void Start()
    {
        HowToPlayScreen.SetActive(false);
        sFImage = true;
        secondImage.SetActive(false);
        sSImage = false;
        thirdImage.SetActive(false);
        sTImage = false;
    }

    public void StartB()
    {
        SceneManager.LoadScene("First Scene");
    }

    public void HowtoPlayB()
    {
        HowToPlayScreen.SetActive(true);
    }

    public void ExitB()
    {
        Application.Quit();
    }
    public void PreviousB()
    {
        if (sSImage)
        {
            secondImage.SetActive(false);
            sSImage = false;
            firstImage.SetActive(true);
            sFImage = true;
        }
        else if (sTImage)
        {
            thirdImage.SetActive(false);
            sTImage = false;
            secondImage.SetActive(true);
            sSImage = true;
        }
    }
    public void NextB()
    {
        if (sFImage)
        {
            firstImage.SetActive(false);
            sFImage = false;
            secondImage.SetActive(true);
            sSImage = true;
        }
        else if (sSImage)
        {
            secondImage.SetActive(false);
            sSImage = false;
            thirdImage.SetActive(true);
            sTImage = true;
        }
    }
    public void CloseB()
    {
        HowToPlayScreen.SetActive(false);
    }
}
