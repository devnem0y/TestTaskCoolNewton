using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer, IController
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    private Rigidbody2D _rb;
    private int _moveDirection;
    private bool _jump;
    
    private bool IsGrounded => _rb.IsTouchingLayers(LayerMask.GetMask("Ground"));
    
    public int Health { get; private set; }
    public int Coins { get; private set; }
    
    public event Action TakeDamage;
    public event Action ChangeCoins;
    public event Action Finish;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Health = 3;
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Spike")) return;
        
        Health--;
        TakeDamage?.Invoke();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeadZone"))
        {
            Health--;
            TakeDamage?.Invoke();
        }
        
        if (col.gameObject.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            Coins++;
            ChangeCoins?.Invoke();
        }
        
        if (col.gameObject.CompareTag("Finish")) Finish?.Invoke();
    }
}