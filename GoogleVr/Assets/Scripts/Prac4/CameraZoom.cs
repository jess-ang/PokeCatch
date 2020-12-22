using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraZoom : MonoBehaviour
{
    public float minFov, maxFov, zoomRate;
    private Camera _cam;
    void Awake()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckZoom();
    }

    private void CheckZoom()
    {
        if(CrossPlatformInputManager.GetButtonDown("ZoomIn"))
            ChangeFOV(-zoomRate);
        if(CrossPlatformInputManager.GetButtonDown("ZoomOut"))
            ChangeFOV(zoomRate);
    }

    private void ChangeFOV(float zoomRate)
    {
        float fov = _cam.fieldOfView + zoomRate;
        fov = Mathf.Clamp(fov,minFov,maxFov);
        _cam.fieldOfView = fov;
    }
}
