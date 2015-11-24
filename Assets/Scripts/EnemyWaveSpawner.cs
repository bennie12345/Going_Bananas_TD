using UnityEngine;
using System.Collections;

public class EnemyWaveSpawner : MonoBehaviour
{
    public float startTimer;
    public float nextWaveTimer;
    private int _enemies;
    [SerializeField] private int _maxEnemies;
    [SerializeField]private Transform[] lanes;
    [SerializeField] private GameObject _enemy;

	// Use this for initialization
	void Start ()
    {
        _enemies = 2;
        InvokeRepeating("SpawnEnemies",startTimer, nextWaveTimer);
	}
	

    void SpawnEnemies()
    {
        for (int i = 0; i < _enemies; i++)
        {
            Instantiate(_enemy,lanes[(Random.Range(0,lanes.Length))].position, Quaternion.identity);
        }
        _enemies++;
        if (_enemies >= _maxEnemies)
        {
            _enemies = _maxEnemies;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
