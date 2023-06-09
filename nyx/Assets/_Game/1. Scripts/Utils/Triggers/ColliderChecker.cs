using UnityEngine;
using UnityEngine.Events;

public class ColliderChecker : MonoBehaviour
{
    [Header("Configuration")]
    public TagNameSO validTag;

    [Header("Events")]
    public UnityEvent onCollisionsEnter;
    public UnityEvent onCollisionStay;
    public UnityEvent onTriggerExit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(validTag.tagName))
            onCollisionsEnter?.Invoke();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(validTag.tagName))
            onCollisionStay?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(validTag.tagName))
            onTriggerExit?.Invoke();

    }
}
