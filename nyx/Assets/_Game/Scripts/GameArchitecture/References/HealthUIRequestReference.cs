using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class HealthUIRequestReference : BaseReference<HealthUIRequest, HealthUIRequestVariable>
	{
	    public HealthUIRequestReference() : base() { }
	    public HealthUIRequestReference(HealthUIRequest value) : base(value) { }
	}
}