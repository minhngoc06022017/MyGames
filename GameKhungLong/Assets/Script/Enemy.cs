using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _endX;
    private float _speed;
    private GameDriver _gameDriver;
    private Transform _transform;

    public void Setup(GameDriver gameDriver,float endX,float speed)
    {
        _gameDriver = gameDriver;
        _endX = endX;
        _speed = speed;
    }

    public void Awake()
    {
        _transform = transform;
    }
    public void Update()
    {
        if (!_gameDriver.IsRunning) return;
        //TODO: move right to left
        float d = _speed * Time.deltaTime;
        _transform.Translate(-d, 0, 0);

        //TODo : check for endx to Destroy
        if (_transform.position.x <= _endX)
        {
            Destroy(gameObject);
        }
    }
}
