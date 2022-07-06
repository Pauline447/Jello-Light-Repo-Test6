using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public float LensSize;
    public ZoomTrigger[] _zoomTriggers;
    public int numberOfTriggers;
    public float endValue;
    public float defaultValue = 10f;
    public float lerpDuration = 3;
    public float timeElapsed;

    public float zoomValue;

    public bool hugZoom;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void Awake()
    {
        vCam.m_Lens.OrthographicSize = defaultValue;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0; i<numberOfTriggers;i++)
        {
            if (_zoomTriggers[i].doZoom ||hugZoom)
            {
                LensSize = Mathf.Lerp(_zoomTriggers[i].startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                vCam.m_Lens.OrthographicSize = LensSize;
            }
        }
        //vCam.m_Lens.OrthographicSize = LensSize;
    }
    public void SetZoomValues(float _endValue)
    {
        endValue = _endValue;
    }
    public void ResetTimer()
    {
        timeElapsed = 0f;
    }
    public void ResetZoom()
    {
        vCam.m_Lens.OrthographicSize = defaultValue;        
        LensSize = vCam.m_Lens.OrthographicSize;
    }
}
