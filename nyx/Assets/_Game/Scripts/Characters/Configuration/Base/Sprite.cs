public class Sprite
{
    public ITransformScaleAnchor Transform;
    public bool isFacingRight;

    public Sprite (ITransformScaleAnchor Transform, bool isFacingRight)
    {
        this.Transform = Transform;
        this.isFacingRight = isFacingRight;
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Transform.LocalScale = new (Transform.LocalScale.x * -1, Transform.LocalScale.y, Transform.LocalScale.z);
    }

    public void Update(float direction)
    {
        if (isFacingRight && direction < 0)
        {
            Flip();
        }
        else if (!isFacingRight && direction > 0)
        {
            Flip();
        }
    }
}
