using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 3.5f;

    private Animator _animator;
    private Rigidbody2D _rb2D;
    private Vector2 _inputPosition;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Input();
    }

    private void FixedUpdate()
    {
        Move(_inputPosition);
    }

    private void Input()
    {
        _inputPosition = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
    }

    private void Move(Vector2 inputPosition)
    {
        _rb2D.MovePosition(_rb2D.position + inputPosition * walkSpeed * Time.fixedDeltaTime);
    }
}