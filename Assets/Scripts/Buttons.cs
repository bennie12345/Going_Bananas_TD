using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayMainMenu()
    {
        Application.LoadLevel("MainScene");
    }

    public void InstructionsMainMenu()
    {
        Application.LoadLevel("InstructionScene");
    }

    public void QuitMainMenu()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    { 
        Application.LoadLevel("MainMenu");
    }
}
