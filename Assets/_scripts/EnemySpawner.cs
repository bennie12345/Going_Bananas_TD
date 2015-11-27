using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _crocEnemy;
    [SerializeField]
    private GameObject _rhinoEnemy;
    [SerializeField]
    private float _timeUntilSpawn = 0f;
    [SerializeField]
    private float _startTime = 0f;
    [SerializeField]
    private float _secondsBetweenSpawn = 3f;
    private float _chooseEnemy;
    // Use this for initialization
    void Start()
    {

    }

    void SpawnEnemy()
    {
        if (_chooseEnemy == 1f)
        {
            GameObject enemyCroc = Instantiate(_crocEnemy) as GameObject;

            enemyCroc.transform.position = transform.position;
        }

        if (_chooseEnemy == 2f)
        {
            GameObject enemyRhino = Instantiate(_rhinoEnemy) as GameObject;

            enemyRhino.transform.position = transform.position;
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        _timeUntilSpawn = Time.time - _startTime;

        if (_timeUntilSpawn >= _secondsBetweenSpawn)
        {
            _startTime = Time.time;
            _timeUntilSpawn = 0;
            _chooseEnemy = Random.Range(1, 3);
            SpawnEnemy();
        }
    }
}