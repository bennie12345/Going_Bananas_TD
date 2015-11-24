using UnityEngine;
using System.Collections;

public class PlaceTower : MonoBehaviour {

    [SerializeField]
    private GameObject _towerPrefab;
    private GameObject _tower;

    private bool _canUpgradeTower()
    {
        if (_tower != null) //Checks if there is a tower to upgrade if it exists gets the current level
        {
            TowerData towerData = _tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.getNextLevel(); //upgrades to next level
            if (nextLevel != null)
            {
                return true;
            }
        }
        return false;
    }

    private bool _canPlaceTower()
    {
        return _tower == null; //Checks if the spot is taken already
    }

    void OnMouseUp()
    {
        if(_canPlaceTower())
        {
            _tower = (GameObject)
                Instantiate(_towerPrefab, transform.position, Quaternion.identity);
            //Reduce player gold (To do)
        }
        else if (_canUpgradeTower())
        {
            _tower.GetComponent<TowerData>().increaseLevel();
           // reduce gold again for upgrade (To do)
        }
    }
}
