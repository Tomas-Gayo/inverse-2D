using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "HealthUIRequest")]
	public sealed class HealthUIRequestGameEventListener : BaseGameEventListener<HealthUIRequest, HealthUIRequestGameEvent, HealthUIRequestUnityEvent>
	{
	}
}