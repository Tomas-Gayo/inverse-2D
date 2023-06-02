using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Dependencies")]
    public PlayerPathSO playerPath;

    public void SaveCheckpoint()
    {
        playerPath.path = transform;
    }
}
