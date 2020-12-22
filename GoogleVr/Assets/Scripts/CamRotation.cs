using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

 public class CamRotation : MonoBehaviour 
 {
     private float x;
     private float y;
     private Vector3 rotateValue;
 
     void FixedUpdate()
     {
         y = CrossPlatformInputManager.GetAxis("Mouse X");
         x = CrossPlatformInputManager.GetAxis("Mouse Y");
        //  Debug.Log(x + ":" + y);
         rotateValue = new Vector3(x, y * -1, 0);
         transform.eulerAngles = transform.eulerAngles - rotateValue;
     }
 }