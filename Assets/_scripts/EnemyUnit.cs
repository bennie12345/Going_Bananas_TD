using UnityEngine;
using System.Collections;

public class EnemyUnit : MonoBehaviour
{
    public float health;
    private Tags _tags;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    void Start()
    {
        _tags.GiveTag(_tags.enemyTag);
    }


    void TakeDamage(int dmgAmount)
    {
        health = health - dmgAmount;
        print(health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
