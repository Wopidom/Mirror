using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;
    //public TaskProgression taskProgression;
    public Vector2 velocity;

    private Vector2 _previousPos;

    private void Start()
    {
        InitCharacter();
        _previousPos = transform.position;
    }

    private void Update()
    {
        velocity = ((Vector2)transform.position - _previousPos) / Time.deltaTime;
        _previousPos = (Vector2)transform.position;

        //if (velocity.sqrMagnitude > 0)
        //    taskProgression.cancelTask = true;
        //else
        //    taskProgression.cancelTask = false;
    }

    private void InitCharacter()
    {
        //KTKManager.Instance.cmCameraController.SetTarget(transform);
        //KTKManager.Instance.cmCameraController.StartFollowing();
    }
}
