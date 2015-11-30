using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    private float currency;
    [SerializeField]private Text _currText;

    void Start()
    {
<<<<<<< HEAD:Assets/Scripts/CurrencyManager.cs
        currency = 600;
=======
        currency = 1200;
>>>>>>> 1209f6a14e12449b9a423999da2ac11600131cb4:Assets/_scripts/CurrencyManager.cs
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