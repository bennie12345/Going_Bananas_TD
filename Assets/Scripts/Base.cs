using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{

    [SerializeField]
    private float _baseHealth = 100f;
    private CrocEnemy _crocEnemy;
    private RhinoEnemy _rhinoEnemy;
    private float _damageToBase;
    // Use this for initialization
    void Start()
    {

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
        
        
        if (other.gameObject.tag == "CrocEnemy")
        {
            _damageToBase = 2;
            StartCoroutine(DamageBase());
        }

        if (other.gameObject.tag == "RhinoEnemy")
        {

            _damageToBase = 1;
            StartCoroutine(DamageBase());
        }

    }

    IEnumerator DamageBase()
    {
        yield return new WaitForSeconds(1);
        _baseHealth -= _damageToBase * Time.deltaTime;
    }
}