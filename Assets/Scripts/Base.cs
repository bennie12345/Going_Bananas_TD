using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{

    [SerializeField]
    private float _baseHealth = 100f;
    private Tags _tags;
    private float _damageToBase;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    void Start()
    {
        _tags.GiveTag(_tags.baseTag,this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (_baseHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == _tags.crocodileEnemy)
        {
            _damageToBase = 15;
            StartCoroutine(DamageBase());
            
        }

        if (other.gameObject.tag == _tags.rhinoEnemy)
        {
            _damageToBase = 10;
            StartCoroutine(DamageBase());
        }

    }

    IEnumerator DamageBase()
    {
        yield return new WaitForSeconds(1);
        _baseHealth -= _damageToBase * Time.deltaTime;
        
    }
}