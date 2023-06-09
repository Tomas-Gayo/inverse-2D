[System.Serializable]
public class HealthUIRequest
{
    public HealthSO health;

    public HealthUIRequest(HealthSO health)
    {
        this.health = health;
    }
}
