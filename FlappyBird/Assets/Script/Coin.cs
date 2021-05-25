using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private GameDriver _gameDriver;
    private Sound _sound;
    private float _speed;
    private Transform _transform;
    private Vector2 _end;
    private void Start()
    {
        _sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
        _transform = transform;
    }
    public void Setup(GameDriver gameDriver, Vector2 end , float speed)
    {
        _gameDriver = gameDriver;
        _end = end;
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        {
            if (col.CompareTag("Player"))
            {
                _sound.playSound("point");
                _gameDriver._score += 10;
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        if (!_gameDriver.IsRunning) return;
        float d = _speed * Time.deltaTime;
        _transform.Translate(-d, 0, 0);

        if (_transform.position.x < _end.x)
        {
            Destroy(gameObject);
        }
        
    }
}
