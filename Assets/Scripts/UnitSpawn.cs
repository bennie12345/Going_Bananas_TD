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
    private Color _color;
    private SpriteRenderer _r;

    bool? isPlacingUnit;
    private bool _canPlace;
    [SerializeField]private string _tag;
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

    public void setLayerMask(string l)
    {
        
    }

    public void SpawnUnit(GameObject u)
    {

        if (_currencyManager.Currency >= 300)
        {
            unitToPlace = Instantiate(u, MousePos(), UnitPos.rotation) as GameObject;
            _r = unitToPlace.GetComponent<SpriteRenderer>();
            _color = _r.material.color;
            

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
                Debug.Log(colliders[i]);

                if (colliders[i].tag == GetComponent<Unit>().Tag)
                {
                    unitToPlace.GetComponent<Renderer>().material.color = Color.green;
                    _canPlace = true;
                }
                else 
                {
                    
                    _canPlace = false;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {

                if (_canPlace)
                {
                    isPlacingUnit = false;
                    _currencyManager.Currency -= 300;
                    unitToPlace.GetComponent<Unit>().enabled = true;
                    unitToPlace.GetComponent<Renderer>().material.color = _color;
                } 
            }

            }
        }

    void Update()
    {

        PlaceUnit();
    }
}
