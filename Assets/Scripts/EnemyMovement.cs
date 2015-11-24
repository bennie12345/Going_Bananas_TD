using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    protected float _moveSpeed;
    protected bool _hitBase = false;

	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	virtual public void Update () {

        if (_hitBase == false)
        {
            Vector2 movement = new Vector2(1, 0f);
            transform.Translate(movement * _moveSpeed * Time.deltaTime);
        }

	
	}

    virtual public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Base")
        {
            //GetComponent<Animation>().Stop("croc_walking");
            //Destroy(this.gameObject);
            
            _hitBase = true;
            
        }
    }
}