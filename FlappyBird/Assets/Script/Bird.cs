using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float _jumpForce=2;
    public Rigidbody2D r2;
    private bool isStart = false;
    private Animator anim;
    private Sound _sound;
    public GameDriver _gameDriver;
    private Transform _transform;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
        r2.gravityScale = 0;
        _sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
        _transform = transform;
    }
    private void Update()
    {
        anim.SetBool("Flying", isStart);
        if(r2.velocity.y > 0)
        {
            _transform.localEulerAngles = new Vector3(_transform.localEulerAngles.x,
                                                  transform.localEulerAngles.y,
                                                   15);
        }
        else if (r2.velocity.y < 0)
        {
            _transform.localEulerAngles = new Vector3(_transform.localEulerAngles.x,
                                                  transform.localEulerAngles.y,
                                                   -15);
        }else{
            _transform.localEulerAngles = new Vector3(_transform.localEulerAngles.x,
                                                  transform.localEulerAngles.y,
                                                   0);
        }
    }

    // Update is called once per frame
    public void Setup(GameDriver gameDriver)
    {
        _gameDriver = gameDriver;
    }
    public void Jump()
    {
        isStart = true;
        r2.velocity = Vector2.zero;
        r2.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        _sound.playSound("flying");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chimney"))
        {
            _gameDriver.Dead();
            Debug.Log("You die by" + collision.gameObject.name);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stand"))
        {
            _gameDriver.Dead();
            Debug.Log("You die by" + collision.gameObject.name);
        }

    }
}
