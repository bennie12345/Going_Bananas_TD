using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private GameObject[] _targets;
    private Vector3 _targetPos;
    public float speed;
    [SerializeField]private int _dmg;
    private Tags _tags;
    private float _lifeTime;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    // Use this for initialization
    void Start ()
    {
        _targetPos = Pos();
        _tags.GiveTag(_tags.projectileTag,this.gameObject);
    }
    
    Vector3 Pos()
    {
        _targets = GameObject.FindGameObjectsWithTag(_tags.crocodileEnemy);
        Vector3 pos = new Vector3(_targets[Random.Range(0, _targets.Length)].transform.position.x, _targets[Random.Range(0, _targets.Length)].transform.position.y, 0);
        return pos;
    }

    void EnemyFollow()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update ()
    {
        EnemyFollow();
        DestroyAfterLifeTime();
	}

    void DestroyAfterLifeTime()
    { 
        _lifeTime += Time.deltaTime;
        if (_lifeTime >= 0.5f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == _tags.crocodileEnemy /*|| other.gameObject.tag == _tags.rhinoEnemy*/)
        {
            other.SendMessage("TakeDamage",_dmg);
            Destroy(this.gameObject);
        }
    }
}
