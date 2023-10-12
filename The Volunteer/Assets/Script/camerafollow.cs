using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
  public float lookspeed = 1;
  public Transform character,target;
  float mousex,mousey;
  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
  }
  void LateUpdate()
  {
    mousex += Input.GetAxis("Mouse X") * lookspeed;
    mousey -= Input.GetAxis("Mouse Y") * lookspeed;
    mousey = Mathf.Clamp(mousey,-45,10);
    transform.LookAt(target);
    target.rotation = Quaternion.Euler(mousey,mousex,0);
    character.rotation = Quaternion.Euler(0,mousex,0);
  }
}
