using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{

    [SerializeField]
    private float _baseHealth = 20f;
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "CrocEnemy")
        {
            _baseHealth -= 2;
        }

        if (coll.gameObject.tag == "RhinoEnemy")
        {
            _baseHealth -= 1;
        }
    }
}