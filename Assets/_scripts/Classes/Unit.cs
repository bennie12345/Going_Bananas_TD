using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    private GameObject _target;
    [SerializeField]
    private GameObject _ObjectToThrow;
    [SerializeField]
    private float _targetingRadius;

    private int _layerMask;


    void Start()
    {
        _layerMask = LayerMask.GetMask("Enemy");
    }
    // Update is called once per frame
    void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(this.transform.position, _targetingRadius, _layerMask);
       /* if (col.gameObject.tag == "Enemy")
        {
            //AttackThrow();
            Debug.Log(col);
            Debug.Log(col.tag);
        }*/
       
    }

   /* void AttackThrow()
    {
        Instantiate(_ObjectToThrow, transform.position, transform.rotation);
    }*/

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white; // 
        Gizmos.DrawWireSphere(this.transform.position, _targetingRadius); // Draws the radius
    }
}
