using UnityEngine;

public class MisteryBlockController : MonoBehaviour
{
    public BlockBounce BlockBounce;
    public GameObject itemPrefab;
    public Transform itemPoint;

    private SpriteRenderer s_ren;

    private bool isActive = true;

    void Awake()
    {
        s_ren = GetComponent<SpriteRenderer>();
    }

    // Player can collision with the block and get an item, after that, the block cannot be used anymore
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only can be used once
        if (isActive)
        {
            if (collision.CompareTag("Player"))
            {
                StartCoroutine(BlockBounce.BrickBounce());

                s_ren.color = Color.white;

                Instantiate(itemPrefab, itemPoint.position, Quaternion.identity);


                isActive = false;
            }
        }
        
    }
}
