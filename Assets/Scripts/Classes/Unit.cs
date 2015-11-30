using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    [SerializeField]
    private GameObject _ObjectToThrow;
    [SerializeField]
    private float _targetingRadius;
    [SerializeField]
    private int _maxTimesThrown;

    [SerializeField]
    private string _tag;
    private GameObject _target;
    private float _timer;
    private bool _canAttack;
    private int _layerMask;
    private Tags _tags;
    private int _timesThrown;

    protected Animator _anim;

    public string Tag {
        get {
            return _tag;

        }
    }

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _tags = FindObjectOfType<Tags>();
    }


    void Start()
    {
        _layerMask = LayerMask.GetMask("Enemy");
        _tags.GiveTag(_tags.unitTag, this.gameObject);

    }

    void AttackThrow()
    {
        _anim.SetBool("isThrowing", true);
        Instantiate(_ObjectToThrow, transform.position, transform.rotation);
        _timesThrown++;
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

        if (col != null)
        {
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i].gameObject.tag == _tags.crocodileEnemy)
                {
                    if (_timer >= 1)
                    {
                        AttackThrow();
                        _timer = 0;
                        _anim.SetBool("canThrow", false);
                    }

                }
            }
        }


    }
}