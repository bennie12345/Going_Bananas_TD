using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    private GameObject _target;
    [SerializeField]
    private GameObject _ObjectToThrow;
    [SerializeField]
    private float _targetingRadius;
    private float _timer;
    private bool  _canAttack;

    private int _layerMask;


    void Start()
    {
        _layerMask = LayerMask.GetMask("Enemy");
    }
    // Update is called once per frame
    void Update()
    {
        AttackDoolDown();
        Collider2D[] col = Physics2D.OverlapCircleAll(this.transform.position, _targetingRadius, _layerMask);

        if (col !=null)
        {
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i].gameObject.tag == "Enemy")
                {
                    Debug.Log("Enemy in range");
                    if (_timer >= 1)
                    {
                        
                        AttackThrow();
                        _timer = 0;
                    }
                    
                }
            }
        }


    }

    void AttackThrow()
    {
        Instantiate(_ObjectToThrow, transform.position, transform.rotation);
        print("throwing");
    }

    void AttackDoolDown()
    {
        _timer += Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(this.transform.position, _targetingRadius); // Draws the radius
    }
}
