//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using nn.hid;


//public class RumbleController : MonoBehaviour
//{
//    public RumbleController(NpadId _npadId)
//    {
//        m_npadId = _npadId;

//        //TODO The player should be able to change this value 
//        m_MaxAmplitude = 0.5f;
//        //m_EffectPlayer = new RumbleFilePlayer();

//        UpdateVibrationDeviceHandles(); // Do an initial setting of the device handles
//    }

//    //////////////////////////////////////////////////////////////////////////

//    public void UpdateVibration() //why?
//    {
//        UpdateVibrationDeviceHandles();

//        //var currValue = m_EffectPlayer.GetNextSample();

//        //if (!IgnoreProceduralRumble)
//        //{
//        //    currValue.amplitudeHigh += m_Vibration.amplitudeHigh * m_MaxAmplitude;
//        //    currValue.amplitudeLow += m_Vibration.amplitudeLow * m_MaxAmplitude;
//        //}

//        //SetLeftVibration(currValue);
//        //SetRightVibration(currValue);
//    }

//    //////////////////////////////////////////////////////////////////////////

//    private void UpdateVibrationDeviceHandles()
//    {
//        var currentStyle = Npad.GetStyleSet(m_npadId);

//        if (currentStyle == m_previousNpadStyle)
//        {
//            return;
//        }

//        m_previousNpadStyle = currentStyle;

//        // We should check if a device goes from inactive to active so we can clear any vibration it's still outputting from when it became inactive.
//        bool wasLeftDeviceNull = (m_vibrationDeviceHandleLeft == null);
//        bool wasRightDeviceNull = (m_vibrationDeviceHandleRight == null);

//        // Set these as null. By the end of the function, any active vibration devices will have a set handle.
//        m_vibrationDeviceHandleLeft = null;
//        m_vibrationDeviceHandleRight = null;

//        if (currentStyle == NpadStyle.None || currentStyle == NpadStyle.Invalid)
//        {
//            // Invalid or disconnected controller.
//            return;
//        }

//        var vibrationDeviceHandles = new VibrationDeviceHandle[VIBRATION_DEVICE_COUNT_MAX]; // Temporary buffer to get handles
//        var vibrationDeviceCount = Vibration.GetDeviceHandles(vibrationDeviceHandles, VIBRATION_DEVICE_COUNT_MAX, m_npadId, currentStyle);

//        for (int i = 0; i < vibrationDeviceCount; i++)
//        {
//            Vibration.InitializeDevice(vibrationDeviceHandles[i]);

//            VibrationDeviceInfo vibrationDeviceInfo = new VibrationDeviceInfo();
//            Vibration.GetDeviceInfo(ref vibrationDeviceInfo, vibrationDeviceHandles[i]);

//            // Cache references to our device handles.
//            switch (vibrationDeviceInfo.position)
//            {
//                case VibrationDevicePosition.Left:
//                    m_vibrationDeviceHandleLeft = vibrationDeviceHandles[i];
//                    if (wasLeftDeviceNull)
//                    {
//                        SetLeftVibration(new VibrationValue()); // Clear out any old value the device may still want to output
//                    }
//                    break;

//                case VibrationDevicePosition.Right:
//                    m_vibrationDeviceHandleRight = vibrationDeviceHandles[i];
//                    if (wasRightDeviceNull)
//                    {
//                        SetRightVibration(new VibrationValue()); // Clear out any old value the device may still want to output
//                    }
//                    break;

//                default:    // This should never happen
//                    Debug.Assert(false, "Invalid VibrationDevicePosition specified");
//                    break;
//            }
//        }
//    }

//    //////////////////////////////////////////////////////////////////////////

//    public void SetRumble(VibrationValue _value)
//    {
//        m_Vibration = _value;
//    }

//    //////////////////////////////////////////////////////////////////////////

//    public void SetLeftVibration(VibrationValue _vibrationValue)
//    {
//        if (m_vibrationDeviceHandleLeft != null)
//        {
//            Vibration.SendValue(m_vibrationDeviceHandleLeft.Value, _vibrationValue);
//        }
//    }

//    //////////////////////////////////////////////////////////////////////////

//    public void SetRightVibration(VibrationValue _vibrationValue)
//    {
//        if (m_vibrationDeviceHandleRight != null)
//        {
//            Vibration.SendValue(m_vibrationDeviceHandleRight.Value, _vibrationValue);
//        }
//    }

//    //////////////////////////////////////////////////////////////////////////

//    //public void PlayEffect(RumbleFile _effect)
//    //{
//    //    m_EffectPlayer.SetFile(_effect);
//    //    m_EffectPlayer.Play();
//    //}

//    //////////////////////////////////////////////////////////////////////////

//    private const int VIBRATION_DEVICE_COUNT_MAX = 2;   // Two is currently the maximum number of vibration devices (left and right).

//    private NpadId m_npadId;
//    private NpadStyle m_previousNpadStyle = NpadStyle.Invalid;
//    private VibrationDeviceHandle? m_vibrationDeviceHandleLeft = null;
//    private VibrationDeviceHandle? m_vibrationDeviceHandleRight = null;

//    private VibrationValue m_Vibration;
//    //private RumbleFilePlayer m_EffectPlayer;
//    private float m_MaxAmplitude;

//    //TODO Placeholder
//    public bool IgnoreProceduralRumble { get; set; } = false;
//}