using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ZoomTrigger : MonoBehaviour
{
    public bool doZoom = false;

    public CinemachineVirtualCamera vCam;
    public CameraZoom camZoom;
    public float startValue; //für Camera Zoom
    public float endValue;
    public float zoomSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startValue = vCam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            doZoom = true;
            camZoom.SetZoomValues(endValue, zoomSpeed);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doZoom = false;
            camZoom.SetZoomValues(endValue, zoomSpeed);
        }
    }
}
