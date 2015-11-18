using UnityEngine;
using System.Collections;

public class UnitSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject unit;
    [SerializeField]
    private Transform UnitPos;

    bool? isPlacingUnit;
    GameObject unitToPlace;

    void OnEnable()
    {
        EventManager.OnClicked += SpawnUnit;
    }

    Vector3 MousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    void RaycastSphere()
    {

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

            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(MousePos().x, MousePos().y), 1);
            for (int i = 0; i < colliders.Length; i++)
            {
                Debug.Log(colliders[i].tag);
                if (colliders[i].tag == "Tree")
                {
                    Debug.Log("unit can be placed here");
                }
                else if (colliders[i].tag != "Tree")
                {
                    Debug.Log("unit can't be placed here");
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                isPlacingUnit = false;
            }
        }
    }
}
