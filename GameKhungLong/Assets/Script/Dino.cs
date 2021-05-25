using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1;
    private Rigidbody2D _rigidbody;
    private bool _canJump = true;
    private GameDriver _gameDriver;
    [SerializeField]private bool isRunning = false;

    private Animator anim;
    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _canJump = true;
        anim = gameObject.GetComponent<Animator>();
    }
    public void Setup(GameDriver gameDriver)
    {
        _gameDriver = gameDriver;
    }
    private void Update()
    {
        if (_gameDriver.IsRunning)
        {
            if(_canJump) isRunning = true;
            else isRunning = false;
        }else isRunning = false;

        anim.SetBool("isRunning", isRunning);
    }

    public void Jump()
    {
        if (_canJump)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse /* .Force */);
            _canJump = false;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Stand")
        {
            //TODo: collides with stand , allow Jump
            _canJump = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //TODO: inform collision
            _gameDriver.Die();
        }

    }

}
