using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RestartTextScript : MonoBehaviour {

    bool enabled;
    Text text;
    Color color;

	// Use this for initialization
	void Start () {
        enabled = false;
        text = GetComponent<Text>();
        color = text.color;
        color.a = 0f;
        text.color = color;
	}
	
	// Update is called once per frame
	void Update () {
        if (enabled) {
            color.a += 0.01f;
            text.color = color;

            if (Input.GetButton("Fire1")) {
                loadMenu();
            }
        }
		
	}

    public void enableRestart() {
        enabled = true;
    }

    public void loadMenu() {
        Debug.Log("METODI");
        GameManager.resetManager();
        SceneManager.LoadScene(0);
    }

    public void OnMouseDown() {
        Debug.Log("lelllelel");
    }
}
