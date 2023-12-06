using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [Header("Dependencies")]
    public Animator animator;

    public void OnPicked()
    {
        animator.SetTrigger("Collected");
    }
}
