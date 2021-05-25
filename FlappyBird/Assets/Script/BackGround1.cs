using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround1 : MonoBehaviour
{
    private Renderer _renderer;
    public float _offset;
    private GameDriver _gameDriver;
    private Transform _transform;
    [SerializeField] private Material _morning=null;
    [SerializeField] private Material _night=null;
    [SerializeField] private float _changeMapDelay = 30;
    private int index = 1;
    private float _speed;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
       _transform = transform;
        _renderer.sharedMaterial = _morning;
    }
    public void Setup(GameDriver gameDriver)
    {
        _gameDriver = gameDriver;
    }

    private void Update()
    {
        _speed = _gameDriver.speed;
        if (!_gameDriver.IsRunning) return;
        swapMap();
        _offset += _speed * Time.deltaTime / _transform.localScale.x;
        _renderer.material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
    }
    public void swapMap()
    {
        if (_changeMapDelay >= 0)
        {
            _changeMapDelay -= Time.deltaTime;
            if (_changeMapDelay < 0)
            {
                _changeMapDelay = 30;
                index += 1;
                if (index % 2 == 0)
                {
                    _renderer.sharedMaterial = _night;
                }
                else
                {
                    _renderer.sharedMaterial = _morning;
                }
            }
        }
    }
}
