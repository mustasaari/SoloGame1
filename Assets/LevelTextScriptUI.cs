using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTextScriptUI : MonoBehaviour {

    Text text;
    bool fadein;
    Color color;
    float countdown;
    int levelNumber;

	// Use this for initialization
	void Start () {
        fadein = true;
        text = GetComponent<Text>();
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        //levelNumber++;
        text.text = "Level " +levelNumber;
        countdown = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (fadein) {
            text.color = new Color(1, 1, 0, countdown);
            countdown += 0.01f;
        }
        else {
            text.color = new Color(1, 1, 0, countdown);
            countdown -= 0.005f;
        }

        if (text.color.a >= 1) {
            fadein = false;
        }
    }
}
