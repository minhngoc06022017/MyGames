using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Renderer _renderer;
    private float _offset;
    
    private Transform _transform;
    [SerializeField] private float _changeMapDelay = 0.5f;
    private float _Delay = 0.5f;
    [SerializeField] private float _stopChange = 3f;
    [SerializeField] private Material _morning = null;
    [SerializeField] private Material _night = null;
    [SerializeField] private Material _morning1 = null;
    [SerializeField] private Material _night1 = null;
    private bool roll = true;
    private int index = 0;
    public float speed = 5f;
    public void Setup()
    {
        
    }
    public void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _offset = 0;
        _transform = transform;
        _Delay = _changeMapDelay;
    }

    public void Update()
    {
        swapMap();
        if (roll)
        {
            _offset += speed * Time.deltaTime / _transform.localScale.y;
            _renderer.material.SetTextureOffset("_MainTex", new Vector2(0, _offset));
        }
        
    }
    public void swapMap()
    {
        if (roll)
        {
            if (_Delay >= 0)
            {
                _Delay -= Time.deltaTime;
                if (_Delay < 0)
                {
                    _Delay = _changeMapDelay ;
                    index += 1;
                    if (index == 1)
                    {
                        _renderer.sharedMaterial = _night;
                    }
                    else if (index == 2)
                    {
                        _renderer.sharedMaterial = _morning;
                    }
                    else if (index == 2)
                    {
                        _renderer.sharedMaterial = _morning1;
                    }
                    else
                    {
                        _renderer.sharedMaterial = _night1;
                        index = 0;
                    }
                }
            }
            if (_stopChange >= 0)
            {
                _stopChange -= Time.deltaTime;
                if (_stopChange < 0)
                {
                    _stopChange = 3f;
                    _renderer.sharedMaterial = _morning;
                    _renderer.material.SetTextureOffset("_MainTex", new Vector2(0, 0));
                    roll = false;
                }
            }
        }
        
    }
}
