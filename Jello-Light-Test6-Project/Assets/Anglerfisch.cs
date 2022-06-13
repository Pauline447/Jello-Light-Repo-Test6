using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anglerfisch : MonoBehaviour
{
    public Animator SensorsOnOne;
    public Animator SensorsOnTwo;
    public Animator Sensor1;
    public Animator Sensor2;
    public Animator Sensor3;
    public Animator Sensor4;


    public float speed = 1f; //geschwindigkeit
    public float amplitude = 1f; //zwischen was es hin und her geht
    public float shift = 0f; //verschiebung auf der y_achse
    public bool PlayerNearAnglerfish = false;
    public float SetBoolTimer;
    public bool VisibilityOnOne;
    public bool VisibilityOnTwo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        //SensorsOnOne.SetFloat("visibility", Mathf.Sin(Time.time * speed) * amplitude + shift);
        //SensorsOnTwo.SetFloat("visibility", Mathf.Sin(Time.time * speed) * amplitude + shift);
        //Sensor1.SetFloat("visibility", Mathf.Sin(Time.time * speed) * amplitude + shift);
        //Sensor1.SetFloat("visibilityOffset", Mathf.Cos(Time.time * speed ) * amplitude + shift);
        //Sensor2.SetFloat("visibility", Mathf.Sin(Time.time * speed) * amplitude + shift);
        //Sensor3.SetFloat("visibility", Mathf.Sin(Time.time * speed) * amplitude + shift);
        //Sensor4.SetFloat("visibility", Mathf.Sin(Time.time * speed) * amplitude + shift);

        if (PlayerNearAnglerfish == true)
        {
            SetBoolTimer = Mathf.Sin(Time.time * speed) * amplitude + shift;
            SetBoolianTrueInTime();
            //SensorsOnOne.SetBool("visibility", true);
            //SensorsOnTwo.SetBool("visibility", false);
            //Sensor1.SetBool("visibility", true);
            //Sensor2.SetFloat("visibility", true);
            //Sensor3.SetFloat("visibility", true);
            //Sensor4.SetFloat("visibility", true);
        }
        else
        {
            SensorsOnOne.SetBool("visibility", false);
            SensorsOnTwo.SetBool("visibility", false);
            Sensor1.SetBool("visibility", false);
            //Sensor2.SetFloat("visibility", false);
            //Sensor3.SetFloat("visibility", false);
            //Sensor4.SetFloat("visibility", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Player")
            {
                PlayerNearAnglerfish = true;
            }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
            if (other.tag == "Player")
            {
                PlayerNearAnglerfish = false;
            }
    }

    private void SetBoolianTrueInTime()
    {
        //SetBoolTimer = Mathf.Sin(Time.time * speed) * amplitude + shift;
        if (SetBoolTimer >= shift)
        {
            SensorsOnOne.SetBool("visibility", false);
            SensorsOnTwo.SetBool("visibility", true);
            Sensor1.SetBool("visibility", false);
            VisibilityOnOne = false;
            VisibilityOnTwo = true;
        }
        else
        {
            SensorsOnOne.SetBool("visibility", true);
            SensorsOnTwo.SetBool("visibility", false);
            Sensor1.SetBool("visibility", true);
            VisibilityOnOne = true;
            VisibilityOnTwo = false;
        }
    }
}
    


