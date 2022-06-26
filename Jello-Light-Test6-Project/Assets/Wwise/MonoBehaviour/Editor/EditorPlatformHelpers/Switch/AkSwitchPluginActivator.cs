#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
public class AkSwitchPluginActivator
{
	static AkSwitchPluginActivator()
	{
		AkPluginActivator.BuildTargetToPlatformName.Add(UnityEditor.BuildTarget.Switch, "Switch");
		AkBuildPreprocessor.BuildTargetToPlatformName.Add(UnityEditor.BuildTarget.Switch, "Switch");
	}
}
#endif