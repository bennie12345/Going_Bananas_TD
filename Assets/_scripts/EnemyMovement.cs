using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    
    private Tags _tags;
    protected float _moveSpeed;
    protected bool _hitBase = false;

    public float minSpeed;
    public float maxSpeed;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    void Start()
    {
        RandomMovementSpeed();
    }

    void RandomMovementSpeed()
    {
        _moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

	virtual public void Update () {

        if (_hitBase == false)
        {
            Vector2 movement = new Vector2(1, 0f);
            transform.Translate(movement * _moveSpeed * Time.deltaTime);
        }

	
	}

    virtual public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == _tags.baseTag)
        {
            GetComponent<AudioSource>().Play();
            _hitBase = true;
            
        }
    }
}