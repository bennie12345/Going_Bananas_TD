using UnityEngine;
using System.Collections;

public class UnitSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject unit;
    [SerializeField]
    private Transform UnitPos;

    private Tags _tags;
    

    bool? isPlacingUnit;
    GameObject unitToPlace;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

    void OnEnable()
    {
        EventManager.OnClicked += SpawnUnit;
    }

    Vector3 MousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    void SpawnUnit()
    {
        isPlacingUnit = true;
        unitToPlace = Instantiate(unit, UnitPos.position, UnitPos.rotation) as GameObject;
    }

    void Update()
    {
        if (isPlacingUnit == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 roundMousePos = new Vector2(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
            mousePos.z = 0;
            unitToPlace.transform.position = mousePos;

            //  GameObject _u = GameObject.FindGameObjectWithTag("Unit");
            unitToPlace.GetComponent<Unit>().enabled = false;
           // _unit.enabled = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(MousePos().x, MousePos().y), 1);
            for (int i = 0; i < colliders.Length; i++)
            {
                Debug.Log(colliders[i].tag);
                if (colliders[i].tag == _tags.pos1Tag)
                {
                    Debug.Log("unit can be placed here");
                }
                else if (colliders[i].tag != "Tree")
                {
                   // Debug.Log("unit can't be placed here");
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                isPlacingUnit = false;
                unitToPlace.GetComponent<Unit>().enabled = true;
            }
        }
    }
}
