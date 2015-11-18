using UnityEngine;
using System.Collections;

public class SpawnTower : MonoBehaviour {

    [SerializeField]
    private GameObject tower;
    [SerializeField]private GameObject upgradeMenu;
    private GameObject localUpgradeMenu;

	// Use this for initialization
	void Start () {
        localUpgradeMenu = (GameObject)Instantiate(upgradeMenu, tower.transform.position, Quaternion.identity);
        GameObject canvas = GameObject.Find("Canvas");
        localUpgradeMenu.transform.SetParent(canvas.transform, false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            
            GameObject obj = Instantiate(upgradeMenu, tower.transform.position, Quaternion.identity) as GameObject;
            obj.transform.SetParent(this.transform);
        }
       // Debug.Log(tempObject.GetComponent<RectTransform>());
        localUpgradeMenu.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(tower.transform.position);
	}
}
