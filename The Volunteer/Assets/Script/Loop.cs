using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    public float uzaklık, hiz;
  
    void Update()
    {
        float x = Mathf.Sin(Time.time * hiz) * uzaklık;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
