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
        while (isPlacingUnit == true)
        {
           
        }
    }


}
