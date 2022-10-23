using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private int _isRunningHach = Animator.StringToHash("isRunning");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float inputData = Input.GetAxis("Horizontal");
        SetDerection(inputData);

        _animator.SetBool(_isRunningHach, inputData != 0);

        Flip(inputData);
    }

    private void SetDerection(float direction)
    {
        float delta = direction * _speed * Time.deltaTime;
        float XPosition = transform.position.x + delta;
        transform.position = new Vector2(XPosition, transform.position.y);
    }

    private void Flip(float direction)
    {
        if(direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if(direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}