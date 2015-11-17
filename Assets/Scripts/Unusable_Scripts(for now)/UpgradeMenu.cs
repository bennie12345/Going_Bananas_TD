using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {
    private bool isMenuOpen = false;
    [SerializeField]
    private GameObject theUpgradeMenu;
    private GameObject localUpgradeMenu;
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp()
    {
        if(!isMenuOpen)
        {
            //open menu
            localUpgradeMenu = Instantiate(theUpgradeMenu, this.transform.position, Quaternion.identity) as GameObject;
            GameObject canvas = GameObject.Find("Canvas");
            localUpgradeMenu.transform.SetParent(canvas.transform, false);
            localUpgradeMenu.GetComponentInChildren<RectTransform>().position = Camera.main.WorldToScreenPoint(this.transform.position);

            isMenuOpen = true;
        }
    }
    public void QuitUpgradeMenu()
    {
        //close menu
        Debug.Log(localUpgradeMenu);
        localUpgradeMenu.SetActive(false);
        isMenuOpen = false;
    }

    public void UpgradeAttack()
    {
        //upgrade attack
        if (isMenuOpen)
        { 
            
        }
    }

    public void UpgradeDefense()
    {
        //upgrade defense
        if (isMenuOpen)
        {

        }
    }
}