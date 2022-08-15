using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpPower = 5;
    [SerializeField] private float _legsRadius = 1;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private const string Jump = "Jump";

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);

        if (Input.GetMouseButtonDown(0))
            TryJump(isGrounded);
    }

    private void TryJump(bool isGrounded)
    {
        if (!isGrounded)
            return;

        _animator.SetTrigger(Jump);
        _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }
}
