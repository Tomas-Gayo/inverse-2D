using UnityEngine;

public class Dust : MonoBehaviour
{
    public GameObject prefab;
    public Transform prefabPoint;
    public float duration;

    // Instantiate  the prefab in a specific point
    public void InstantiateDust()
    {
        GameObject dust = Instantiate(prefab, prefabPoint.position, Quaternion.identity);

        if (duration > 0)
        {
            Destroy(dust, duration);
        }
    }
}
