using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimney : MonoBehaviour
{
    [SerializeField] private float _speed=3;
    [SerializeField] Transform _transform;
    private GameDriver _gameDriver;
    private Vector2 _end;
    private bool isCollect = true;
    private Bird  _Player;
    private Sound _sound;
    void Start()
    {
        _transform = transform;
        _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Bird>();
        _sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
    }
    public void Setup(GameDriver gameDriver, Vector2 end, float speed)
    {
        _gameDriver = gameDriver;
        _end = end;
        _speed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (!_gameDriver.IsRunning) return;
        float d = _speed * Time.deltaTime;
        _transform.Translate(-d, 0, 0);

        if(_transform.position.x < _end.x)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < _Player.transform.position.x - 1 && isCollect)
        {
            _gameDriver._score += 1;
            _sound.playSound("point");
            isCollect = false;
        }
    }
}
