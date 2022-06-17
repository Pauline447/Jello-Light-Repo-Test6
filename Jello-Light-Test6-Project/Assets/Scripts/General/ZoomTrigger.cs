using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ZoomTrigger : MonoBehaviour
{
    public bool doZoom = false;
    public bool endZoom = false;

    public CinemachineVirtualCamera vCam;
    public CameraZoom camZoom;
    public float startValue; //f�r Camera Zoom
    public float endValue;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        startValue = vCam.m_Lens.OrthographicSize;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            camZoom.timeElapsed = 0;
            doZoom = true;
            camZoom.SetZoomValues(endValue);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doZoom = false;
            //camZoom.SetZoomValues(startValue, zoomSpeed);
        }
    }
}
