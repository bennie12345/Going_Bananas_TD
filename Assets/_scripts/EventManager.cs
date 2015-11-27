using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnClicked;


    public void OnButtonClick()
    {
        if (OnClicked != null)
        {
            OnClicked();
        }
    }
}
