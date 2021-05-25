using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDriver : MonoBehaviour
{
    enum Status
    {
        Initial,
        Flying,
        Pause,
        Dead,
    }
    public float _spawnChimneyDelay ;
    public GameObject[] _Chimneys = null;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;
    public int _score = 0;
    public int _highScore = 0;

    public Bird _bird;
    public Transform _positionStart = null;
    public Transform _positionEnd = null;
    public BackGround _backGround = null;
    public BackGround1 _backGround1 = null;
    private Status _status = Status.Initial;
    [SerializeField]private ControlCanvas _canvas = null;
    public float speed = 3 ;
    [SerializeField] private float speedMax = 15;
    [SerializeField] private float speedUpdate = 5;
    [SerializeField] private float spawnMinTime = 0.5f;
    [SerializeField] private float spawnInterval = 3;
    [SerializeField]public bool IsRunning { get { return _status == Status.Flying; } }
    
    void Start()
    {
        _bird = GameObject.FindGameObjectWithTag("Player").GetComponent<Bird>();
        _bird.Setup(this);
        _backGround.Setup(this);
        _backGround1.Setup(this);
        _spawnChimneyDelay = spawnInterval;
        _highScore = PlayerPrefs.GetInt("_highScore",0);
        _score = 0;
        
        
    }

    
    void Update()
    {

        _scoreText.text=("Score: " + _score);
        _highScoreText.text = ("HighScore: " + _highScore);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_status)
            {
                case Status.Initial:
                    _status = Status.Flying;
                    _bird.r2.gravityScale = 1;
                    break;
                case Status.Flying:
                    _bird.Jump();
                    break;
                case Status.Dead:
                    restart();
                    break;
                
            }
        }
        if(IsRunning)
        {
            spawnChimney();
            updateSpeedAndSpawnTime();
        }
        
        
    }
    public void updateSpeedAndSpawnTime()
    {
        if(speedUpdate >= 0)
        {
            speedUpdate -= Time.deltaTime;
            if (speedUpdate < 0)
            {
                speed += 0.5f;
                if (speed >= speedMax)
                {
                    speed = speedMax;
                }
                
                spawnInterval -= 0.25f;
                if(spawnInterval < spawnMinTime)
                {
                    spawnInterval = spawnMinTime;
                }

                speedUpdate = 5;
            }
        }
    }
    
    public void spawnChimney()
    {
        if(_spawnChimneyDelay >= 0)
        {
            _spawnChimneyDelay -= Time.deltaTime;
            if (_spawnChimneyDelay < 0)
            {
                CreateChimney();
                _spawnChimneyDelay = spawnInterval + UnityEngine.Random.Range(0f,1f);
            }
        }
    }
    public void CreateChimney()
    {
        int choice = UnityEngine.Random.Range(1, 3);
        int choice1 = UnityEngine.Random.Range(-4,4);
        GameObject prefab = _Chimneys[0];
        GameObject prefab1 = _Chimneys[1];
        GameObject coin = _Chimneys[2];
        GameObject _coin = Instantiate(coin, new Vector2(_positionStart.position.x - 4, choice1), Quaternion.identity);
        Coin coin1 = _coin.GetComponent<Coin>();
        coin1.Setup(this, _positionEnd.position, speed);
        switch (choice)
        {
            case 1:
                int index = UnityEngine.Random.Range(0,1);
                int index1 = UnityEngine.Random.Range(0, 3);
                GameObject chimneyObject = Instantiate(prefab, new Vector2(_positionStart.position.x, -1 - index), Quaternion.identity);
                GameObject chimneyObject1 = Instantiate(prefab1, new Vector2(_positionStart.position.x, 2 + index1), Quaternion.identity);
                Chimney chimney = chimneyObject.GetComponent<Chimney>();
                Chimney chimney1 = chimneyObject1.GetComponent<Chimney>();
                chimney.Setup(this, _positionEnd.position, speed);
                chimney1.Setup(this, _positionEnd.position, speed);
                break;
            case 2:
                chimneyObject = Instantiate(prefab, new Vector2(_positionStart.position.x, 0 ), Quaternion.identity);
                chimneyObject1 = Instantiate(prefab1, new Vector2(_positionStart.position.x,2.5f), Quaternion.identity);
                chimney = chimneyObject.GetComponent<Chimney>();
                chimney1 = chimneyObject1.GetComponent<Chimney>();
                chimney.Setup(this, _positionEnd.position, speed);
                chimney1.Setup(this, _positionEnd.position, speed);
                break;
            case 3:
                index = UnityEngine.Random.Range(1,2);
                switch (index)
                {
                    case 1:
                        chimneyObject = Instantiate(prefab, new Vector2(_positionStart.position.x, 2), Quaternion.identity);
                        chimneyObject1 = Instantiate(prefab1, new Vector2(_positionStart.position.x,6), Quaternion.identity);
                        chimney = chimneyObject.GetComponent<Chimney>();
                        chimney1 = chimneyObject1.GetComponent<Chimney>();
                        chimney.Setup(this, _positionEnd.position, speed);
                        chimney1.Setup(this, _positionEnd.position, speed);
                        break;
                    case 2:
                        chimneyObject = Instantiate(prefab, new Vector2(_positionStart.position.x, -5), Quaternion.identity);
                        chimneyObject1 = Instantiate(prefab1, new Vector2(_positionStart.position.x, -3), Quaternion.identity);
                        chimney = chimneyObject.GetComponent<Chimney>();
                        chimney1 = chimneyObject1.GetComponent<Chimney>();
                        chimney.Setup(this, _positionEnd.position, speed);
                        chimney1.Setup(this, _positionEnd.position, speed);
                        break;
                }
                
                break;
        }
        
    }
    public void Dead()
    {
        
        _status = Status.Dead;
        if(PlayerPrefs.GetInt("_highScore") < _score)
        {
            PlayerPrefs.SetInt("_highScore", _score);
        }
    }
    public void restart()
    {
        //GameObject[] allChimneys = GameObject.FindGameObjectsWithTag("Chimney");
        //for(int i=0; i < allChimneys.Length; i++)
        //{
        //    Destroy(allChimneys[i]);
        //}
        //_status = Status.Flying;
        SceneManager.LoadScene(0);

    }
    public void Resume()
    {
        _canvas.isPause = false;
    }

    
}
