using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telekinetic : MonoBehaviour
{
    public float maxgrabdis = 40f;
    public float mingrabdis = 1f;
    public LineRenderer line;
    public Transform shotpoint;

    Rigidbody grabobject;
    float pickdis;
    Vector3 pickoffset;
    Vector3 picktarpos;
    Vector3 pickforce; 
    private void Start()
    {
        if(!shotpoint)
        {
            shotpoint = transform;
        }
        if(!line)
        {
            var obj =new GameObject("Physichun pick line");
            line = obj.AddComponent<LineRenderer>();
            line.startWidth = 0.02f;
            line.endWidth = 0.02f;
            line.useWorldSpace = true;
            line.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Grab();
        }
        if(Input.GetMouseButtonDown(1))
        {
            if(grabobject)
            {
                Release(true);
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            Release();
        }
        pickdis = Mathf.Clamp(pickdis + Input.mouseScrollDelta.y,mingrabdis,maxgrabdis);
    }

    void LateUpdate()
    {
        var middlepoint = (transform.position + picktarpos) / 2f;
        middlepoint += Vector3.ClampMagnitude(pickforce / 2f,1f);
        DrawQuadraticBezierCurve(line,shotpoint.position,middlepoint,grabobject.worldCenterOfMass - pickoffset);
    }
    void FixedUpdate()
    {
        if(grabobject != null)
        {
            var ray = Camera.main.ViewportPointToRay(Vector3.one*.5f);
            picktarpos = (ray.origin + ray.direction * pickdis) + pickoffset;
            var forcedir = picktarpos - grabobject.position;
            pickforce = forcedir / Time.fixedDeltaTime * 0.3f / grabobject.mass;
            grabobject.velocity = pickforce;
        }
    }
    void Grab()
    {
       var ray = Camera.main.ViewportPointToRay(Vector3.one*.5f);
       if(Physics.Raycast(ray,out RaycastHit hit,maxgrabdis) && hit.rigidbody != null)
       {
          pickoffset = hit.rigidbody.worldCenterOfMass - hit.point;
          pickdis = hit.distance;
          grabobject = hit.rigidbody;
          grabobject.collisionDetectionMode = CollisionDetectionMode.Continuous;
          grabobject.useGravity = false;
          grabobject.freezeRotation = true;
          grabobject.isKinematic = false;
          line.gameObject.SetActive(true);
       }
       
    }
    void Release(bool setkinemat = false)
    {
        grabobject.collisionDetectionMode = CollisionDetectionMode.Discrete;
        grabobject.useGravity = true;
        grabobject.freezeRotation = false;
        grabobject.isKinematic = setkinemat;
        grabobject = null;
        line.gameObject.SetActive(false);
           
    }
    void DrawQuadraticBezierCurve(LineRenderer linerend,Vector3 point0,Vector3 point1, Vector3 point2)
    {
        linerend.positionCount = 10;
        float t = 0f;
        Vector3 b = new Vector3(0,0,0);
        for(int i = 0; i<linerend.positionCount;i++)
        {
            b = (1 - t)*(1 - t) *point0 + 2*(1 - t)*t*point1+t*t*point2;
            linerend.SetPosition(i,b);
            t += (1/(float)line.positionCount);
        }

    }

}
