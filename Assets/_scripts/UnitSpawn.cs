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
<<<<<<< HEAD
    public int _lyrMask = 1;
=======
    private LayerMask _lyrMask;
>>>>>>> origin/master
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
            _r = unitToPlace.GetComponent<SpriteRenderer>();
            _color = _r.material.color;
            

            isPlacingUnit = true;
        }

        
    }

    void PlaceUnit()
    {
        if (isPlacingUnit == true)
        {

            if (unitToPlace.tag == "Gorilla")
            {
                _lyrMask = LayerMask.GetMask("GorillaField");
            }
            else if (unitToPlace.name == "MonkeyUnit")
            {
                _lyrMask = LayerMask.GetMask("BuildUnit");
            }
            else if (unitToPlace.name == "bananana(Clone)")
            {
                _lyrMask = LayerMask.GetMask("BananaField");
            }

            Vector3 mousePos = MousePos();
            unitToPlace.transform.position = mousePos;

            unitToPlace.GetComponent<Unit>().enabled = false;


            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(MousePos().x, MousePos().y), 1,_lyrMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                Debug.Log(colliders[i].tag);
                Debug.Log(colliders[i].IsTouchingLayers(_lyrMask));
                if (colliders[i].tag == "notplaceable")
                {
                    _canPlace = false;
                }
                else if (colliders[i].tag != "notplaceable")
                {
                    unitToPlace.GetComponent<Renderer>().material.color = Color.green;
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
<<<<<<< HEAD
                    
                    GetComponent<AudioSource>().Play();
                    
                }
=======
                    unitToPlace.GetComponent<Renderer>().material.color = _color;
                } 
            }
>>>>>>> origin/master

            }
        }

    void Update()
    {

        PlaceUnit();
    }
}
