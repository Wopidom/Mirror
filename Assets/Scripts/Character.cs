using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Vector2 velocity;

    private int _isMovingHash;

    private void Start()
    {
        LevelManager.Instance.cmVirtualCamera.Follow = transform;
        _isMovingHash = Animator.StringToHash("isMoving");
    }

    private void Update()
    {
        Debug.Log(velocity);
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        //Animations
        if (velocity.sqrMagnitude > 0)
        {
            animator.SetBool(_isMovingHash, true);
        }
        else
        {
            animator.SetBool(_isMovingHash, false);
        }

        //Orientation
        if (velocity.x > 0)
            spriteRenderer.flipX = false;
        else if (velocity.x < 0)
            spriteRenderer.flipX = true;
    }
}
