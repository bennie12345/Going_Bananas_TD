using UnityEngine;
using System.Collections;

public class UnitSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject unit;
    [SerializeField]
    private Transform UnitPos;

    private Tags _tags;
    private CurrencyManager _currencyManager;

    bool? isPlacingUnit;
    private bool _canPlace;
    GameObject unitToPlace;

    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
        _currencyManager = FindObjectOfType<CurrencyManager>();
    }

    Vector3 MousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 roundMousePos = new Vector2(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));

        return roundMousePos;
    }

    public void SpawnUnit(GameObject u)
    {
        if (_currencyManager.Currency >= 300)
        {
                    unitToPlace = Instantiate(u, MousePos(), UnitPos.rotation) as GameObject;
        isPlacingUnit = true;
        }

        
    }

    void PlaceUnit()
    {
        if (isPlacingUnit == true)
        {
            Vector3 mousePos = MousePos();
            unitToPlace.transform.position = mousePos;

            unitToPlace.GetComponent<Unit>().enabled = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(MousePos().x, MousePos().y), 1);
            for (int i = 0; i < colliders.Length; i++)
            {
                Debug.Log(colliders[i].tag);
                if (colliders[i].tag == "notplaceable")
                {
                    
                    _canPlace = false;
                }
                else if (colliders[i].tag != "notplaceable")
                {
                     
                    _canPlace = true;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                
                if (_canPlace)
                {
                    isPlacingUnit = false;
                    _currencyManager.Currency -= 300;
                    unitToPlace.GetComponent<Unit>().enabled = true;
                }

            }
        }
    }

    void Update()
    {

        PlaceUnit();
    }
}
