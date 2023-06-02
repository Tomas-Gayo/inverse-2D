using UnityEngine;
using Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject playerParent;
    public GameObject playerPrefab;
    public CinemachineVirtualCamera playerVC;
    public PlayerPathSO playerPath;

    public void InstantiatePlayer()
    {
        GameObject player = GetPlayer();
        Transform spawnPosition = GetSpawnPosition();

        player.transform.parent = playerParent.transform;
        player.transform.position = spawnPosition.position;
        playerVC.Follow = player.transform;
    }

    private GameObject GetPlayer()
    {
        GameObject playerInLevel = GameObject.FindGameObjectWithTag("Player");

        if (playerInLevel == null)
        {
            playerInLevel = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
        }

        return playerInLevel;
    }

    private Transform GetSpawnPosition()
    {
        var spawnPosition = playerPath.path;

        if (spawnPosition == null)
        {
            return transform.GetChild(0).transform;
        }

        return spawnPosition;
    }
}
