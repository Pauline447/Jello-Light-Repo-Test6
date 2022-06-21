using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nn.hid;

public class RumbleManager : MonoBehaviour
{
    public RumbleController _rumbleController;
    private const float VIBRATION_INTERVAL = 0.005f; //BNVIB files are sampled at a rate of 200 Hz == every 5 milliseconds == 0.005 seconds

    public void Awake() //initilize conrollers + sichergehen, dass vibration nicht nur per frame sondern gaaanz oft durchgeführt wird (Vibration_InterVal)
    {
        m_RumbleControllers = new RumbleController[] { new RumbleController((NpadId)0) }; //RumbleController Klasse wird erstellt
        InvokeRepeating(nameof(_rumbleController.UpdateVibration), 0.1f, VIBRATION_INTERVAL); //why?
    }

    //////////////////////////////////////////////////////////////////////////

    public void UpdateVibrations()
    {
        for (int i = 0; i < m_RumbleControllers.Length; i++)
        {
            m_RumbleControllers[i].UpdateVibration(); //UpdateVibration der RumbleController Klasse wird aufgerufen
        }
    }

    //////////////////////////////////////////////////////////////////////////

    public void SetRumble(uint _controllerId, VibrationValue _value)
    {
        if (_controllerId >= m_RumbleControllers.Length) return;

        m_RumbleControllers[_controllerId].SetRumble(_value); //SetRumble von RumbleController Klasse wird aufgerufen
    }

    //////////////////////////////////////////////////////////////////////////

    public void TurnOffRumble(uint _controllerId)
    {
        if (_controllerId >= m_RumbleControllers.Length) return;

        SetRumble(_controllerId, VibrationValue.Make());
        m_RumbleControllers[_controllerId].UpdateVibration();
    }

    //////////////////////////////////////////////////////////////////////////

    public void TurnOffAllControllers()
    {
        for (uint i = 0; i < m_RumbleControllers.Length; i++)
        {
            TurnOffRumble(i);
        }
    }

    //////////////////////////////////////////////////////////////////////////

    //public void PlayEffect(uint _controllerId, RumbleFile _effect) //nur wichtig, wenn man die Sound waves als Rumble haben will
    //{
    //    if (_controllerId >= m_RumbleControllers.Length) return;

    //    m_RumbleControllers[_controllerId].PlayEffect(_effect);
    //}

    //////////////////////////////////////////////////////////////////////////

    //public void IgnoreProceduralRumble(uint _controllerId, bool _ignore) //nur wichtig, wenn man zwei verschiedene Rumbles benutzt und das eine ausgeschaltet werden soll während das andere aktiv is
    //{
    //    if (_controllerId >= m_RumbleControllers.Length) return;

    //    m_RumbleControllers[_controllerId].IgnoreProceduralRumble = _ignore;
    //}

    //////////////////////////////////////////////////////////////////////////

    private RumbleController[] m_RumbleControllers; //initialisierung RumbleController Klasse

    public float MaxAmplitude { get; set; }
}
