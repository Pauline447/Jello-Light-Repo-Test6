using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class TriggerAnimationAnglerfisch : MonoBehaviour
{
    public Animator anglerfishAnim;
    private MMFeedbacks startSoundFeedback;
    private MMFeedbacks stopSoundFeedback;
    // Start is called before the first frame update
    void Start()
    {

        startSoundFeedback = GameObject.Find("Anglerfish danger start").GetComponent<MMFeedbacks>();
        stopSoundFeedback = GameObject.Find("Anglerfish danger stop").GetComponent<MMFeedbacks>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            startSoundFeedback.PlayFeedbacks();
            anglerfishAnim.SetBool("TouchSensor",true);
            StartCoroutine(WaitForABit());
        }
    }
    private IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(1.5f);
        stopSoundFeedback.PlayFeedbacks();
        anglerfishAnim.SetBool("TouchSensor", false);
    }
}
