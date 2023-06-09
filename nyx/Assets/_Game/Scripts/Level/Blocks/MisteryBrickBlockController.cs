using UnityEngine;

public class MisteryBrickBlockController : MonoBehaviour
{
    public BlockBounce BlockBounce;
    public GameObject itemPrefab;
    public Transform itemPoint;

    private Animator animator;

    private bool isActive = true;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Only can be activated once
            if (isActive)
            {
                Instantiate(itemPrefab, itemPoint.position, Quaternion.identity);
                isActive = false;
            }

            
        }
    }
}
