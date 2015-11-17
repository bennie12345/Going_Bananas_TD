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

            if (Input.GetMouseButtonDown(0))
            {
                isPlacingUnit = false;
            }
        }
    }
}
