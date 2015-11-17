using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private float _moveSpeed;
    private bool _hitBase = false;

	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (_hitBase == false)
        {
            Vector2 movement = new Vector2(1, 0f);
            transform.Translate(movement * _moveSpeed * Time.deltaTime);
        }

	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Base")
        {
            Destroy(this.gameObject);
            _hitBase = true;
        }
    }
}