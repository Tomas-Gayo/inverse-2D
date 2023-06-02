using System.Collections;
using UnityEngine;

public class BrickBlockController : MonoBehaviour
{
    public BlockBounce BlockBounce;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

}
