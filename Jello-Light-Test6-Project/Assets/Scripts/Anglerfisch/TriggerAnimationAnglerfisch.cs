using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationAnglerfisch : MonoBehaviour
{
    public Animator anglerfishAnim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anglerfishAnim.SetBool("TouchSensor",true);
            StartCoroutine(WaitForABit());
        }
    }
    private IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(1.5f);
        anglerfishAnim.SetBool("TouchSensor", false);
    }
}
