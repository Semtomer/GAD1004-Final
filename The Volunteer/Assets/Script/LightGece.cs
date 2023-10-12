using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGece : MonoBehaviour  
{
    public GameObject AltKat, UstKat, Cikis, YerAlti, FloorLamps, StreetLamps;
    public static int tur2;

    void Start()
    {
        AltKat.SetActive(true);
        UstKat.SetActive(false);
        Cikis.SetActive(false);
        YerAlti.SetActive(false);
        FloorLamps.SetActive(false);
        StreetLamps.SetActive(true);
    }
    void Update()
    {
        if (tur2 == 1)
        {
            UstKat.SetActive(false);
            AltKat.SetActive(true);
            StreetLamps.SetActive(true);
        }
        else if (tur2 == 2)
        {
            UstKat.SetActive(true);
            AltKat.SetActive(false);
            StreetLamps.SetActive(false);
        }
        else if (tur2 == 3)
        {
            AltKat.SetActive(false);
            Cikis.SetActive(true);
            StreetLamps.SetActive(false);
        }
        else if (tur2 == 4)
        {
            AltKat.SetActive(true);
            Cikis.SetActive(false);
            StreetLamps.SetActive(true);
        }
        else if (tur2 == 5)
        {
            YerAlti.SetActive(true);
        }
        else if (tur2 == 6)
        {
            YerAlti.SetActive(false);
            Cikis.SetActive(false);
            FloorLamps.SetActive(true);
        }
    }
}
