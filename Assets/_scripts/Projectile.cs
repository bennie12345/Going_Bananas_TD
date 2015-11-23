using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private GameObject[] _targets;
    private Vector3 _targetPos;
    public float speed;

    // Use this for initialization
    void Start ()
    {
        _targetPos = Pos();
    }

    Vector3 Pos()
    {
        _targets = GameObject.FindGameObjectsWithTag("Enemy");
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
	}
}
