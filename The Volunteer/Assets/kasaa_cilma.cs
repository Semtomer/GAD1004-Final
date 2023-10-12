using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kasaa_cilma : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(minigame2.miko == true)
        {
          anim.SetBool("x",true);
        }
    }
}
