using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private float timeUntilSpawn = 0f;
    [SerializeField]
    private float startTime = 0f;
    [SerializeField]
    private float secondsBetweenSpawn = 3f;
    // Use this for initialization
    void Start()
    {

    }

    void SpawnEnemy()
    {

        GameObject myEnemy = Instantiate(Enemy) as GameObject;

        myEnemy.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        timeUntilSpawn = Time.time - startTime;

        if (timeUntilSpawn >= secondsBetweenSpawn)
        {
            startTime = Time.time;
            timeUntilSpawn = 0;
            SpawnEnemy();
        }
    }
}