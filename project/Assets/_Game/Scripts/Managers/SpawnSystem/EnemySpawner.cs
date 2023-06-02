using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuration")]
    [Tooltip("Amount of enemies to spawn.")]
    public int enemiesAmount;
    public float timeBetweenSpawns;
    public GameObject enemyParent;
    [Header("Dependencies")]
    public GameObject enemy;
    public Transform spawnPoint;

    // Private variables
    private bool canSpawn;

    private void Start()
    {
        canSpawn = true;
    }

    public void SpawnEnemies()
    {
        if (!canSpawn)
            return;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        canSpawn = false;
        for (int i = 0; i < enemiesAmount; i++)
        {
            GameObject myEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            myEnemy.transform.parent = enemyParent.transform;

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

}
