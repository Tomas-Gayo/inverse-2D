using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
    [Test]
    public void Move_Along_X_Axis_Positive_Input()
    {
        //Movement movement = new Movement(1.0f, 0.0f);
        Movement movement = ScriptableObject.CreateInstance<Movement>();
        movement.Speed = 1.0f;

        Assert.AreEqual(1.0f, movement.CalculateHoritzontal(1.0f, 1.0f));
    }

    [Test]
    public void Move_Along_X_Axis_Negative_Input()
    {
        Movement movement = ScriptableObject.CreateInstance<Movement>();
        movement.Speed = 1.0f;

        Assert.AreEqual(-1.0f, movement.CalculateHoritzontal(-1.0f, 1.0f));
    }

    [Test]
    public void Move_Along_X_Axis_Zero_Input()
    {
        Movement movement = ScriptableObject.CreateInstance<Movement>();
        movement.Speed = 1.0f;

        Assert.AreEqual(0.0f, movement.CalculateHoritzontal(0.0f, 1.0f));
    }

    [Test]
    [TestCase(1.0f)]
    [TestCase(-1.0f)]
    public void Move_Along_X_Axis_Zero_Speed(float direction)
    {
        Movement movement = ScriptableObject.CreateInstance<Movement>();
        movement.Speed = 0.0f;

        Assert.AreEqual(0.0f, movement.CalculateHoritzontal(direction, 1.0f));
    }

    //[Test]
    //public void Move_Along_Y_Axis_Jump()
    //{
    //    Movement Movement = new Movement(0.0f, 5.0f);

    //    Assert.AreEqual(5.0f, Movement.CalculateVertical(1.0f));
    //}

    //[Test]
    //public void Move_Along_Y_Axis_Jump_Zero_Force()
    //{
    //    Movement Movement = new Movement(0.0f, 0.0f);

    //    Assert.AreEqual(0.0f, Movement.CalculateVertical(1.0f));
    //}

    //[Test]
    //public void Move_Along_Y_Axis_Jump_Zero_Mass()
    //{
    //    Movement Movement = new Movement(0.0f, 1.0f);

    //    Assert.AreEqual(Mathf.Infinity, Movement.CalculateVertical(0.0f));
    //}
}
