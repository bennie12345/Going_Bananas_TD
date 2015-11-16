using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {
    private bool isMenuOpen = false;
    private GameObject upgradeMenu;
    

	// Use this for initialization
	void Start () {
        upgradeMenu = GameObject.FindGameObjectWithTag("UpgradeMenu");
        upgradeMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp()
    {
        if(!isMenuOpen) //&& upgradeMenu != null)
        {
            //open menu
            upgradeMenu.SetActive(true);
            isMenuOpen = true;
        }
    }
    public void QuitUpgradeMenu()
    {
        if(isMenuOpen && upgradeMenu != null)
        {
            //close menu
            upgradeMenu.SetActive(false);
            isMenuOpen = false;
        }   
    }

    public void UpgradeAttack()
    {
        //upgrade attack
        if (isMenuOpen && upgradeMenu != null)
        { 
            
        }
    }

    public void UpgradeDefense()
    {
        //upgrade defense
        if (isMenuOpen && upgradeMenu != null)
        {

        }
    }
}
