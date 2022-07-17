using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class TriggerAnimationAnglerfisch : MonoBehaviour
{
    public Animator anglerfishAnim;
    private MMFeedbacks startSoundFeedback;
    private MMFeedbacks stopSoundFeedback;
    private MMFeedbacks resumeSoundFeedback;
    private SetDoneOnce _setDoneOnce;
    public bool moves;

    // Start is called before the first frame update
    void Start()
    {
        startSoundFeedback = GameObject.Find("Anglerfish danger start").GetComponent<MMFeedbacks>();
        stopSoundFeedback = GameObject.Find("Anglerfish danger stop").GetComponent<MMFeedbacks>();
        resumeSoundFeedback = GameObject.Find("Anglerfish danger resume").GetComponent<MMFeedbacks>();
        _setDoneOnce = GameObject.Find("Anglerfish danger start").GetComponent<SetDoneOnce>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(moves)
        {
         if (collision.gameObject.tag == "Player")
            {
                if(!_setDoneOnce.doneOnceYes)
                {
                    startSoundFeedback.PlayFeedbacks();
                    _setDoneOnce.doneOnceYes = true;
                }
                else
                {
                    resumeSoundFeedback.PlayFeedbacks();
                }
                anglerfishAnim.SetBool("TouchSensor",true);
                StartCoroutine(WaitForABit());
            }
        }
   
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (moves)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine(WaitForABitShorter());
            }
        }
    }
    private IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(1f);
        anglerfishAnim.SetBool("TouchSensor", false);
    }
    private IEnumerator WaitForABitShorter()
    {
        yield return new WaitForSeconds(0.5f);
        stopSoundFeedback.PlayFeedbacks();
    }
}
