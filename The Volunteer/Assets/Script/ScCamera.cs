using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCamera : MonoBehaviour
{
   public static bool okay, Active = true;
   
    void FixedUpdate()
    {
        if (Active == true)
        {
            if (okay == true)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -110, 0), 0.02f);
                
                if (transform.rotation == Quaternion.Euler(0, -110, 0))
                {
                    okay = false;
                }
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -210, 0), 0.02f);
                if (transform.rotation == Quaternion.Euler(0, -210, 0))
                {
                    okay = true;
                }
            }
        }
    }
}
