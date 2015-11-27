using UnityEngine;
using System.Collections;

public class EnemyUnit : MonoBehaviour
{
    public float health;
    private Tags _tags;
    public float moneyOnDeath;
    private bool _death;
    private CurrencyManager _currencyManager;
    private Animator _anim;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
        _currencyManager = FindObjectOfType<CurrencyManager>();
        _anim = GetComponent<Animator>();

    }

    void Start()
    {
        _tags.GiveTag(_tags.crocodileEnemy,this.gameObject);
    }


    void TakeDamage(int dmgAmount)
    {
        health = health - dmgAmount;
        print(health);
        if (health <= 0)
        {
            _death = true;
            _anim.SetBool(_tags.deathTag, true);
        }
    }

    private IEnumerator KillOnAnimationEnd()
    {
        if (_death)
        {
            yield return new WaitForSeconds(0.1f);
            _death = false;
            OnDeath();
        }
    }

    void OnDeath()
    {
        _currencyManager.Currency += moneyOnDeath;
        Destroy(this.gameObject);
    }

    void Update()
    {
        StartCoroutine(KillOnAnimationEnd());
    }
}
