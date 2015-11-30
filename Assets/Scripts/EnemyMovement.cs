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
        moveSpeed = Random.Range(minSpeed, maxSpeed);
       // Debug.Log(_moveSpeed);
    }
	
	// Update is called once per frame
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
            //GetComponent<Animation>().Stop("croc_walking");
            //Destroy(this.gameObject);
           // Debug.Log("making contact with the base");
            
            _hitBase = true;
            
        }
    }
}