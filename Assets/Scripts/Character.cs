using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class Character : MonoBehaviour
{
    public BehaviorTree tree;
    public Rigidbody2D rb2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Vector2 velocity;

    private int _isMovingHash;
    private Vector2 _prevPos;

    private void Start()
    {
        LevelManager.Instance.cmVirtualCamera.Follow = transform;
        _isMovingHash = Animator.StringToHash("isMoving");
        _prevPos = transform.position;
    }

    private void Update()
    {
        velocity = ((Vector2)transform.position - _prevPos) / Time.deltaTime;
        _prevPos = transform.position;

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
