using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    [SerializeField]
    private GameObject[] _bases;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _bases = GameObject.FindGameObjectsWithTag("Base");

        if (_bases.Length == 0)
        {
            Application.LoadLevel("GameOverScene");
        }
	
	}
}
