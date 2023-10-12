using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManagement : MonoBehaviour
{
    public float waitTimeForEachLetter = 0.05f;

    string Text1 = "   Welcome to our game 'The Volunteer'\n\n" +
        "\tTom is a teenager who has just graduated from high school. He has been researching witchcraft on the deep web for several years.\n\n" +
        "\tOne day, while he is having dinner with his family, his parents ask Tom what he wants to do in the future. Tom tells them that he doesn't want to go to college and is interested in witchcraft.\n\n" +
        "\tFamily members who don't believe in witchcraft turn against Tom and pressure him to go to college.";

    string Text2 = "\tThat day, Tom is kicked out of the house and he thinks about what to do outside alone.\n\n" +
        "\tWhile walking down the street, Tom finds a newspaper drifting on the sidewalk. He sees an advertisement in the newspaper. In the advertisement, it is written that a volunteer is sought for an experiment and before the experiment, the volunteers will be given 100.000$.\n\n" +
        "\tInstead of staying out, Tom sees staying in the hospital and earning money at the same time as an inevitable opportunity and goes to the hospital.";

    string currentText = "";

    AudioSource aSource;
    public AudioClip doorSlam, slowWalking, newspaper;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        StartCoroutine(ShowText());

    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < Text1.Length; i++)
        {
            print(i);

            currentText = Text1.Substring(0, i + 1);
            GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(waitTimeForEachLetter);

            if (i == 464)
            {
                yield return new WaitForSeconds(3);
            }
        }

        for (int i = 0; i < Text2.Length; i++)
        {
            print(i);

            if (i == 19)
            {
                aSource.clip = doorSlam;
                aSource.Play();
            }
            else if (i == 95)
            {
                aSource.clip = slowWalking;
                aSource.Play();
            }
            else if (i == 130)
            {
                aSource.clip = newspaper;
                aSource.Play();
            }

            currentText = Text2.Substring(0, i + 1);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(waitTimeForEachLetter);

            if (i == 506)
            {
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene(2);
            }
        }
    }
}
