using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDriver : MonoBehaviour
{
    enum Phase
    {
        Initial,
        Running,
        Dead,
    }

    [SerializeField] private Dino _dino = null;
    [SerializeField] private GameObject[] _enemyPrefabs = null;

    [SerializeField] private Transform _enemyStart = null;
    [SerializeField] private Transform _enemyEnd   =null;

    //[SerializeField] private BackGround _backGround = null;

    private Phase _phase = Phase.Initial;

    [SerializeField]private float _enemyInterval  = 3;
    private float _enemyWaitSpawn = 2;

    [SerializeField]private float _speed = 5;
    private float __changeSpeedCountDown = 0;

    public bool IsRunning { get { return _phase == Phase.Running; } }

    public void Start()
    {
        _dino.Setup(this);
        
        //_backGround.speed = _speed*2;
    }
    public void Die()
    {
        _phase = Phase.Dead;
    }

    public void Update()
    {   //up la release
        //down la press
        //key ko thi hold
        
        if (Input.GetKeyDown(KeyCode.Space) == true ||
            Input.GetMouseButtonDown(0)==true)
        {
            performMainAction();
        }
        if (IsRunning)
        {
            waitSpawnEnemy();
            speedUprade();
        }
        

    }
    public void restart()
    {
        GameObject[] allEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0, c = allEnemys.Length; i < c ; i++)
        {
            Destroy(allEnemys[i]);
        }
        _phase = Phase.Running;
        _speed = 5;
        _enemyInterval = 3;
    }
    private void performMainAction()
    {
        switch (_phase)
        {
            case Phase.Initial:
                _phase = Phase.Running;
                break;
            case Phase.Running:
                _dino.Jump();

                break;
            case Phase.Dead:

                restart();
                break;
        }
    }
    public void speedUprade()
    {
        if(__changeSpeedCountDown <= 5)
        {
            __changeSpeedCountDown += Time.deltaTime;
            if (__changeSpeedCountDown > 5)
            {
                _speed += 0.5f;
                if (_speed >= 15) _speed = 15;
                _enemyInterval -= 0.25f;
                if (_enemyInterval <= 1) _enemyInterval = 1;
                //_backGround.speed = _speed;
                __changeSpeedCountDown = 0;
            }
        }
    }

    private void waitSpawnEnemy()
    {
        if (_enemyWaitSpawn > 0)
        {
            _enemyWaitSpawn -= Time.deltaTime;
            if (_enemyWaitSpawn <= 0)
            {
                spawnEnemy();
                _enemyWaitSpawn = _enemyInterval + UnityEngine.Random.Range(0f,1f);
            }
        }
    }

    private void spawnEnemy()
    {
        //TODO: pick prefab
        int index = UnityEngine.Random.Range(0, _enemyPrefabs.Length);
        GameObject prefab = _enemyPrefabs[index];
        //TODO: craate gameObject
        GameObject enemyObject = Instantiate(prefab, _enemyStart.position, Quaternion.identity);
        //TODO: setup gameobject
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.Setup(this,_enemyEnd.position.x, _speed);
    }
}
