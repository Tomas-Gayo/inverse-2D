using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class HealthUIRequestEvent : UnityEvent<HealthUIRequest> { }

	[CreateAssetMenu(
	    fileName = "HealthUIRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "HealthUI",
	    order = 120)]
	public class HealthUIRequestVariable : BaseVariable<HealthUIRequest, HealthUIRequestEvent>
	{
	}
}