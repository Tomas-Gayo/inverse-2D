using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpriteFlipTest
{
    [Test]
    public void Flip_Sprite_IsFacingRight_To_Left()
    {
        var transform = Substitute.For<ITransformScaleAnchor>();
        bool isFacingRight = true;
        Sprite Sprite = new Sprite(transform, isFacingRight);

        transform.LocalScale = new Vector3(1, 1, 1);
        Sprite.Flip();

        Assert.AreEqual(new Vector3 (-1, 1, 1), transform.LocalScale);
        Assert.False(Sprite.isFacingRight);
    }

    [Test]
    public void Flip_Sprite_IsFacingLeft_To_Right()
    {
        var transform = Substitute.For<ITransformScaleAnchor>();
        bool isFacingRight = false;
        Sprite Sprite = new Sprite(transform, isFacingRight);

        transform.LocalScale = new Vector3(-1, 1, 1);
        Sprite.Flip();

        Assert.AreEqual(new Vector3(1, 1, 1), transform.LocalScale);
        Assert.True(Sprite.isFacingRight);
    }
}
