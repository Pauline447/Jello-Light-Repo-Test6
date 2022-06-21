using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorenAbstimmen : MonoBehaviour
{
    public Material blurMaterial1;
    public Material blurMaterial2;
    public float blurAmount1;
    public float blurAmount2;
    public float blurmin = 0f;
    public float blurmax = 2.5f;
    private float speed = 1f;
    //public bool startBlur = false;
    //public bool endBlur = false;
    private bool onOne;
    private bool anglerfischActive = true;
    public int numberOfSensors1;
    public int numberOfSensors2;
    public GameObject[] sensors1;
    public GameObject[] sensors2;
    // Start is called before the first frame update
    void Start()
    {
        blurAmount1 = blurmin;
        blurAmount2 = blurmax;
        StartCoroutine(SetOn());
        //blurMaterial.SetFloat("_Blur_Amount", blurAmount);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (onOne)
        {
            blurAmount1 += speed * Time.deltaTime;
            blurAmount1 = Mathf.Clamp(blurAmount1, blurmin, blurmax);
            blurMaterial1.SetFloat("_Blur_Amount", blurAmount1);

            blurAmount2 -= speed * Time.deltaTime;
            blurAmount2 = Mathf.Clamp(blurAmount2, blurmin, blurmax);
            blurMaterial2.SetFloat("_Blur_Amount", blurAmount2);
        }
        else
        {
            blurAmount1 -= speed * Time.deltaTime;
            blurAmount1 = Mathf.Clamp(blurAmount1, blurmin, blurmax);
            blurMaterial1.SetFloat("_Blur_Amount", blurAmount1);
           
            blurAmount2 += speed * Time.deltaTime;
            blurAmount2 = Mathf.Clamp(blurAmount2, blurmin, blurmax);
            blurMaterial2.SetFloat("_Blur_Amount", blurAmount2);
        }
        for(int i = 0; i < numberOfSensors1; i++)
        {
            if(onOne)
            {
                sensors1[i].SetActive(false);
            }
            else
            {
                sensors1[i].SetActive(true);
            }

        }
        for (int i = 0; i < numberOfSensors2; i++)
        {
            if (onOne)
            {
                sensors2[i].SetActive(true);
            }
            else
            {
                sensors2[i].SetActive(false);
            }

        }
    }
    private IEnumerator SetOn()
    {
        while(anglerfischActive)
        {
          onOne = true;
          yield return new WaitForSeconds(4f);
          onOne = false;
          yield return new WaitForSeconds(4f);
        }
    }
}
