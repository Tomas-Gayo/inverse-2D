using NUnit.Framework;
using UnityEngine;

public class JumpTest
{
    [Test]
    public void Calculate_Jump_Positive_Height_Default_Values()
    {
        Jump jump = ScriptableObject.CreateInstance<Jump>();
        jump.Configure(1.0f, 1.0f, 0.0f);

        Assert.AreEqual(2.0f, jump.CalculateForce(-2.0f, 1.0f));
    }

    [Test]
    public void Calculate_Jump_Zero_Height_Default_Values()
    {
        Jump jump = ScriptableObject.CreateInstance<Jump>();
        jump.Configure(0.0f, 1.0f, 0.0f);

        Assert.AreEqual(0.0f, jump.CalculateForce(-1.0f, 1.0f));
    }

    [Test]
    public void Calculate_Jump_Negative_Height_Default_Values()
    {
        Jump jump = ScriptableObject.CreateInstance<Jump>();
        jump.Configure(-1.0f, 1.0f, 0.0f);

        Assert.AreEqual(double.NaN, jump.CalculateForce(-1.0f, 1.0f));
    }

    [Test]
    public void Set_Default_Gravityscale()
    {
        Jump jump = ScriptableObject.CreateInstance<Jump>();
        jump.Configure(1.0f, 1.0f, 0.0f);

        Assert.AreEqual(1, jump.SetGravityScale(true));
    }

    [Test]
    public void Set_Fall_GravityScale()
    {
        Jump jump = ScriptableObject.CreateInstance<Jump>();
        jump.Configure(1.0f, 1.0f, 0.0f);

        Assert.AreEqual(0.0f, jump.SetGravityScale(false));
    }
}
