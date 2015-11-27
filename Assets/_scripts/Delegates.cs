using UnityEngine;
using System.Collections;

public class Delegates : MonoBehaviour
{
   // delegate void MyDelegate();
    //MyDelegate myDelegate;

	// Use this for initialization
	void Start ()
    {
        /*myDelegate += ColorChange;
        myDelegate += ColorChanged;

        myDelegate();*/
	}

    void OnEnable()
    {
        EventManager.OnClicked += ColorChange;
        EventManager.OnClicked += ColorChanged;
    }

    void ColorChange()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    void ColorChanged()
    {
        print("The color has changed!");
    }
}
