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
    private Tags _tags;
    private int _timesThrown;
    [SerializeField]private int _maxTimesThrown;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }


    void Start()
    {
        _layerMask = LayerMask.GetMask("Enemy");
        _tags.GiveTag(_tags.unitTag, this.gameObject);
        
    }

    void AttackThrow()
    {
        Instantiate(_ObjectToThrow, transform.position, transform.rotation);
        _timesThrown++;
        print("throwing shit, literally");
        if (_timesThrown >= _maxTimesThrown)
        {
            DestroyOnLimit();
        }
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

    void DestroyOnLimit()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        AttackDoolDown();
        Collider2D[] col = Physics2D.OverlapCircleAll(this.transform.position, _targetingRadius, _layerMask);

        if (col !=null)
        {
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i].gameObject.tag == _tags.enemyTag)
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
}
