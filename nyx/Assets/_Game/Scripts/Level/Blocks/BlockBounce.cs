using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBounce : MonoBehaviour
{
    public float distance = 20f;
    public float bounce = 5f;

    private Vector3 target;
    private Vector3 origin;

    private AudioSource source;

    private void Awake()
    {
        origin = transform.position;
        target = new Vector3(origin.x, origin.y + bounce);
        source = GetComponent<AudioSource>();
    }
    public IEnumerator BrickBounce()
    {
        if (transform.position == origin)
        {
            source.Play();
            // Move Towards calculates the position between current and target but cannot go farther than the specified distance 
            transform.position = Vector3.MoveTowards(transform.position, target, distance * Time.deltaTime);

            yield return new WaitForSeconds(0.1f);

            // Back to the origin position
            transform.position = origin;
        }
    }

    // Destroy the block after a bounce
    public IEnumerator BrickBouceDestroy()
    {
        StartCoroutine(BrickBounce());

        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);
    }
}
