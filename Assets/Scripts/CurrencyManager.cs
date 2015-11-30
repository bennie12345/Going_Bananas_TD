using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    private float currency;
    [SerializeField]private Text _currText;

    void Start()
    {
        currency = 600;
    }

   public float Currency {
        get {
            return currency;
        } set {
            currency = value;
        }
    }

    void Update()
    {
        _currText.text = "" + currency;
    }
}
