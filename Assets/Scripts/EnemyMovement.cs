using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 movement = new Vector2(1, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
	
	}
}
