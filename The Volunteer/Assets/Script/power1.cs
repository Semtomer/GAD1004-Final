using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power1 : MonoBehaviour
{
    float maxgrabdis = 20;
    Transform grabobj;
    Rigidbody grabob;
    public Camera cam;
    public LayerMask Lay;    
    float dis;
   
    void Update()
    {
        RaycastHit hito;
        //Ray ray = cam.ViewportPointToRay(Vector3.one*0.5f);
        Ray rayo = CenterRay();
        if(Physics.Raycast(rayo,out hito,maxgrabdis,Lay))
        {
            Debug.DrawRay(rayo.origin,rayo.direction*maxgrabdis,Color.blue,0.01f);   
        }               
        if(grabobj && grabobj)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                dis = dis + 0.5f;
            }
            else if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                dis = dis - 0.5f;
            }
            if(dis > maxgrabdis)
            {
                dis = maxgrabdis;
            }
            else if(dis < 2)
            {
                dis = 2;
            }
            grabobj.transform.position = cam.transform.position + cam.transform.forward*dis;
            
            if(Input.GetMouseButtonDown(1))
            {
                grabob.isKinematic = true;
                //grabbedrb.AddForce(cam.transform.forward*throwforce,ForceMode.VelocityChange);
                grabobj = null;
            }
            
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(grabob && grabobj)
            {
                grabob.constraints = RigidbodyConstraints.None;
                grabob.isKinematic = false;
                grabob = null;
                grabobj = null;
            
            }
            else
            {
               RaycastHit hit;
               //Ray ray = cam.ViewportPointToRay(Vector3.one*0.5f);
               Ray ray = CenterRay();
              if(Physics.Raycast(ray,out hit,maxgrabdis,Lay))
               {
                 grabobj = hit.collider.gameObject.GetComponent<Transform>();
                 grabob = hit.collider.gameObject.GetComponent<Rigidbody>();
           
                 //cam.transform.position = new Vector3(10,0,0);
                 dis = Vector3.Distance(grabobj.transform.position,cam.transform.position);
                 
                 grabob.constraints = RigidbodyConstraints.FreezePositionY;
                }
                Debug.DrawRay(ray.origin,ray.direction*maxgrabdis,Color.blue,0.01f);
            }
        }
    }    
    Ray CenterRay()
    {
        return cam.ViewportPointToRay(Vector3.one*0.5f);
    }
}
