using UnityEngine;
using System.Collections;

public class UnitSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject unit;
    [SerializeField]
    private Transform UnitPos;

    void OnEnable()
    {
        EventManager.OnClicked += SpawnUnit;
    }

    void SpawnUnit()
    {
        Instantiate(unit, UnitPos.position, UnitPos.rotation);
    }
}
