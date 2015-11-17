using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

    public float baseHealth = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (baseHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            StartCoroutine(DamageBase());
        }
    }

    IEnumerator DamageBase()
    {
        yield return new WaitForSeconds(1);
        baseHealth -= 1;
    }
}
