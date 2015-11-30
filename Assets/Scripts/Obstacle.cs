using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private Tags _tags;
    private EnemyMovement _enemyMovement;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
        _enemyMovement = FindObjectOfType<EnemyMovement>();
    }

    void Start()
    {
        _tags.GiveTag(_tags.bananaTag, this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == _tags.crocodileEnemy )
        {
            Debug.Log("ive found the enemy");
            _enemyMovement.moveSpeed = 0;
        }
    }
}
