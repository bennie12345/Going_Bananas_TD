using UnityEngine;
using System.Collections;

public class ChangeValues : MonoBehaviour
{
    private int hp = 50;
    private int atk = 5;
    private int def = 7;
    private int mp = 10;
    private int spd = 5;

    //whenever you subscribe a method to an event you also have to unsubscribe it.
    void OnEnable()
    {
        EventManager.OnClicked += ValueIncrease;
    }

    void OnDisable()
    {
        EventManager.OnClicked -= ValueIncrease;
    }

    void ValueIncrease()
    {
        hp += 10;
        atk += 3;
        def += 7;
        mp += 10;
        spd += 5;
        print("hp: " + hp + "atk: " + atk + "def: " + def + "mp: " + mp + "spd: " + spd);
    }
}
