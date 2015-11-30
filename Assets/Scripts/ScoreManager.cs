using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private float _score;
    [SerializeField]
    private Text _scoretxt;

	// Use this for initialization
	void Start ()
    {
        _score = 0;
	}

    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        _scoretxt.text = "" + _score;
	}
}
