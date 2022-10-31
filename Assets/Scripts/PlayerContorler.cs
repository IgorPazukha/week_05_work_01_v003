using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerContorler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;

    private bool _isGround = true;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    private static readonly int _runningAnimation = Animator.StringToHash("IsRunning");
    private static readonly int _groundAnimation = Animator.StringToHash("IsGround");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float userInputHorizontal;
        float userInputVertical;

        userInputHorizontal = Input.GetAxis("Horizontal");
        userInputVertical = Input.GetAxis("Vertical");

        SetDerection(userInputHorizontal);
        JumpPlayer(userInputVertical);

        _animator.SetBool(_runningAnimation, userInputHorizontal != 0);
        _animator.SetBool(_groundAnimation, _isGround);

        Flip(userInputHorizontal);
    }

    private void SetDerection(float direction)
    {
        float delta = direction * _speed * Time.deltaTime;
        float XPosition = transform.position.x + delta;
        transform.position = new Vector2(XPosition, transform.position.y);
    }

    private void JumpPlayer(float userInputVertical)
    {
        if(userInputVertical > 0 && CheckGround())
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool CheckGround()
    {
        return _isGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
    }

    private void Flip(float direction)
    {
        _spriteRenderer.flipX = direction < 0 ? true : false;
    }
}