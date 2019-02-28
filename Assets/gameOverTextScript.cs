using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverTextScript : MonoBehaviour {

    GameObject player;
    Text text;
    Color color;
    public Text restart;
    public Button restartB;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<Text>();
        color = text.color;
        color.a = 0f;
        text.color = color;
    }
	
	// Update is called once per frame
	void Update () {

        if ( player.GetComponentInChildren<AnimScript>().playerDied() ) {
            color.a += 0.003f;
            text.color = color;
        }
        if (color.a >= 0.8f) {
            restart.GetComponent<RestartTextScript>().enableRestart();
            restartB.GetComponent<Button>().interactable = true;
        }
	}
}
