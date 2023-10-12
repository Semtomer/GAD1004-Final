using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power2 : MonoBehaviour
{
    float maxgrabdis = 60;
    Transform grabobj;
    Rigidbody grabob;
    public Camera cam;
    public LayerMask Lay;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        //Ray ray = cam.ViewportPointToRay(Vector3.one*0.5f);
        Ray ray = CenterRay();
        if(Physics.Raycast(ray,out hit,maxgrabdis,Lay))
        {
           grabobj = hit.collider.gameObject.GetComponent<Transform>();
           grabob = hit.collider.gameObject.GetComponent<Rigidbody>();
           
           //cam.transform.position = new Vector3(10,0,0);
           float dis = Vector3.Distance(grabobj.transform.position,cam.transform.position);
           if(Input.GetKeyDown(KeyCode.T))
           {
              dis = dis + 1;
           }
           else if(Input.GetKeyDown(KeyCode.Y))
           {
               dis = dis - 1;
           }
           if(grabobj)
           {
               if(Input.GetMouseButton(0))
               {
                 grabobj.transform.position = cam.transform.position + cam.transform.forward*dis;
               }
               else
               {
                   grabobj = null;
                   grabob = null;
               }
           }
           
           //Debug.Log("tutuyor");
           grabob.constraints = RigidbodyConstraints.FreezePositionY;
           if(grabobj && grabob == null)
           {
               grabob.constraints = RigidbodyConstraints.None;
               Debug.Log("oldu");
           }   
           //grabobj.transform.position = Input.mousePosition;
        }
        else
        {

        }
        /*
        if(grabobj)
        {
            if(Input.GetMouseButton(0))
            {
                
            }
           
        }
        */
        Debug.DrawRay(ray.origin,ray.direction*maxgrabdis,Color.blue,0.01f);
    }
    Ray CenterRay()
    {
        return cam.ViewportPointToRay(Vector3.one*0.5f);
    }
}
