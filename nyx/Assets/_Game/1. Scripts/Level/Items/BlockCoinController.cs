using UnityEngine;

public class BlockCoinController : MonoBehaviour
{
    public float duration = 0.5f;

    // When the coin is enabled destroy it after a specific time
    private void OnEnable()
    {
        if (duration > 0)
        {
            Destroy(gameObject, duration);
        }      
    }
}
