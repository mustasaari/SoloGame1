using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheeseScoreScript : MonoBehaviour {

    TextMesh tm;

	// Use this for initialization
	void Start () {
        tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        tm.text = GameManager.cheeses.ToString();
	}
}
