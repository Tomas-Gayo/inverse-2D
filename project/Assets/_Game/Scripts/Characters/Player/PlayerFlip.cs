using UnityEngine;


public class PlayerFlip : MonoBehaviour, ITransformScaleAnchor
{
	public InputReader InputReader;

    public Sprite Sprite;
    public bool isFacingRight;
    
    float x_Axis;

    public Vector3 LocalScale 
    { 
        get { return transform.localScale; }
        set { transform.localScale = value; }
    }

    #region SetCallbacks
    private void OnEnable()
    {
        InputReader.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        InputReader.MoveEvent -= OnMove;
    }
    #endregion

    private void Awake()
    {
        Sprite = new Sprite(this, isFacingRight);
    }

    private void Update()
    {
        Sprite.Update(x_Axis);
    }

    #region Inputs Listeners
    private void OnMove(float input)
    {
        x_Axis = input;
    }
    #endregion

}
