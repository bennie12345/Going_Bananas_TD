using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    
    private Tags _tags;
    public float moveSpeed;
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
<<<<<<< HEAD:Assets/Scripts/EnemyMovement.cs
        moveSpeed = Random.Range(minSpeed, maxSpeed);
       // Debug.Log(_moveSpeed);
=======
        _moveSpeed = Random.Range(minSpeed, maxSpeed);
>>>>>>> 1209f6a14e12449b9a423999da2ac11600131cb4:Assets/_scripts/EnemyMovement.cs
    }

	virtual public void Update () {

        if (_hitBase == false)
        {
            Vector2 movement = new Vector2(1, 0f);
            transform.Translate(movement * moveSpeed * Time.deltaTime);
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