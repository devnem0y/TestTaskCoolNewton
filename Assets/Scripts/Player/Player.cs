using UnityEngine;

public class Player : MonoBehaviour, IPlayer, IController
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    private Rigidbody2D _rb;
    private int _moveDirection;
    private bool _jump;
    
    private bool IsGrounded => _rb.IsTouchingLayers(LayerMask.GetMask("Ground"));

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (IsGrounded) _rb.AddForce(new Vector2(_speed * _moveDirection, _rb.velocity.y));
		
        if (!IsGrounded || !_jump) return;
        
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _jump = false;
    }

    public void SetDirection(int axis)
    {
        _moveDirection = axis;
    }

    public void SetJump()
    {
        _jump = true;
    }

    private void Update() //TODO: Для тестов, потом убрать
    {
        if (Input.GetKeyDown(KeyCode.Space)) SetJump();
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) SetDirection(-1);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) SetDirection(1);
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) SetDirection(0);
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) SetDirection(0);
    }
    
}