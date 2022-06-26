#if UNITY_SWITCH && !UNITY_EDITOR
public partial class AkCommonUserSettings
{
	partial void SetSampleRate(AkPlatformInitSettings settings)
	{
		settings.uSampleRate = m_SampleRate;
	}
}
#endif

public class AkSwitchSettings : AkWwiseInitializationSettings.CommonPlatformSettings
{
#if UNITY_EDITOR
	[UnityEditor.InitializeOnLoadMethod]
	private static void AutomaticPlatformRegistration()
	{
		RegisterPlatformSettingsClass<AkSwitchSettings>("Switch");
	}
#endif // UNITY_EDITOR

	public AkSwitchSettings()
	{
		SetUseGlobalPropertyValue("CommsSettings.m_CommandPort", false);
		SetUseGlobalPropertyValue("CommsSettings.m_NotificationPort", false);
		IgnorePropertyValue("CommsSettings.m_InitializeSystemComms");
		IgnorePropertyValue("AdvancedSettings.m_RenderDuringFocusLoss");
		IgnorePropertyValue("AdvancedSettings.m_SoundBankPersistentDataPath");

		CommsSettings = new AkCommonCommSettings
		{
			m_DiscoveryBroadcastPort = AkCommonCommSettings.DefaultDiscoveryBroadcastPort,
			m_CommandPort = (ushort)(AkCommonCommSettings.DefaultDiscoveryBroadcastPort + 1),
			m_NotificationPort = (ushort)(AkCommonCommSettings.DefaultDiscoveryBroadcastPort + 2),
			m_InitializeSystemComms = false,
		};
	}
}

