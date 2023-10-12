using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOp : MonoBehaviour
{
    public  GameObject Isisklar, Alt, Ust, Floorr1, Floorr2;
    public static int tur;

    private void Start()
    {
        //Isisklar.SetActive(false);
        Ust.SetActive(false);
    }

    private void Update()
    {
        if (tur == 1 )
        {
            Ust.SetActive(false);
            Alt.SetActive(true);
        }
        else if (tur == 2)
        {
            Ust.SetActive(true);
            Alt.SetActive(false);
        }
        else if (tur == 3)
        {
            Floorr1.SetActive(true);
            Floorr2.SetActive(false);
            Isisklar.SetActive(true);
           
        }
        else if (tur == 4)
        {
            Floorr2.SetActive(true);
            Floorr1.SetActive(false);
            Isisklar.SetActive(false);
        }
    }
}
