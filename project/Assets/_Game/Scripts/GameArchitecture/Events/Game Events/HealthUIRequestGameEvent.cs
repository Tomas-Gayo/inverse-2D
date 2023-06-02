using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "HealthUIRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "HealthUI",
	    order = 120)]
	public sealed class HealthUIRequestGameEvent : GameEventBase<HealthUIRequest>
	{
	}
}