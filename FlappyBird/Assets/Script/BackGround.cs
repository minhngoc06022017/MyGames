using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Renderer _renderer;
    public float _offset;
    private GameDriver _gameDriver;
    private Transform _transform;
    private float _speed;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
       _transform = transform;
    }
    public void Setup(GameDriver gameDriver)
    {
        _gameDriver = gameDriver;
    }

    private void Update()
    {
        _speed = _gameDriver.speed;
        if (!_gameDriver.IsRunning) return;
        _offset += _speed * Time.deltaTime / _transform.localScale.x;
        _renderer.material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
    }
}
