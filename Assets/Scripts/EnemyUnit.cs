using UnityEngine;
using System.Collections;

public class EnemyUnit : MonoBehaviour
{
    public float health;
    private Tags _tags;
    private float _moneyOnDeath;
    private bool _death;
    private CurrencyManager _currencyManager;
    private ScoreManager _scoreManager;
    private Animator _anim;
    private float _scoreWorth;
    private EnemyMovement _enemyMovement;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
        _currencyManager = FindObjectOfType<CurrencyManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _enemyMovement = FindObjectOfType<EnemyMovement>();
        _anim = GetComponent<Animator>();

    }

    void Start()
    {
        _tags.GiveTag(_tags.crocodileEnemy,this.gameObject);
        _scoreWorth = Random.Range(1, 999);
        _moneyOnDeath = Random.Range(100, 250);
    }


    void TakeDamage(int dmgAmount)
    {
        health -= dmgAmount;
       // print(health);
        if(health <= 0)
        {
            _anim.SetBool(_tags.deathTag, true);
            _enemyMovement.moveSpeed = 0;
            print("am I dying");
            _currencyManager.Currency += _moneyOnDeath;
            _scoreManager.Score += _scoreWorth;
            Destroy(this.gameObject, 1f);
           

        }
    }

    void OnDeath()
    {

    }

    void Update()
    {
    }
}
