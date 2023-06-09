public class Movement
{
    public float H_Speed;
    public float V_Speed;

    public Movement(float H_Speed, float V_Speed)
    {
        this.H_Speed = H_Speed;
        this.V_Speed = V_Speed;
    }

    public float CalculateHoritzontal(float xDirection, float deltaT)
    {
        return xDirection * H_Speed * deltaT;
    }    
    
    public float CalculateVertical(float mass)
    {
        return V_Speed / mass;
    }
}

