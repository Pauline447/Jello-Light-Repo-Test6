using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public float LensSize;
    public ZoomTrigger _zoomTrigger;
    public float endValue;
    public float zoomSpeed;
    public float defaultValue = 10f;
    private float lerpDuration = 3;
    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        ResetZoom();

    }

    // Update is called once per frame
    void Update()
    {
        if(_zoomTrigger.doZoom)
        {
            LensSize = Mathf.Lerp(_zoomTrigger.startValue, endValue, timeElapsed/lerpDuration);
            timeElapsed += Time.deltaTime;
            vCam.m_Lens.OrthographicSize = LensSize;
        }
        else
        {
            ResetZoom();
        }
        //vCam.m_Lens.OrthographicSize = LensSize;
    }
    public void SetZoomValues(float _endValue, float _zoomSpeed)
    {
        endValue = _endValue;
        zoomSpeed = _zoomSpeed;
    }
    public void ResetZoom()
    {
        vCam.m_Lens.OrthographicSize = defaultValue;        
        LensSize = vCam.m_Lens.OrthographicSize;
    }
}
