using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Character character;

    [SerializeField]
    private float walkSpeed = 3.5f;

    private Vector2 _inputPosition;
    private Vector2 _prevPos;

    private void Start()
    {
        _prevPos = transform.position;
    }

    private void Update()
    {
        Input();
    }

    private void FixedUpdate()
    {
        Move(_inputPosition);
        character.velocity = ((Vector2)transform.position - _prevPos) / Time.deltaTime;
        _prevPos = transform.position;
    }

    private void Input()
    {
        _inputPosition = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
    }

    private void Move(Vector2 inputPosition)
    {
        character.rb2D.MovePosition(character.rb2D.position + inputPosition * walkSpeed * Time.fixedDeltaTime);
    }
}