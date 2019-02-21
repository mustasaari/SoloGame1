using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitgame : MonoBehaviour {

    public GameObject exitLabel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") < 0 ) {
            Debug.Log("lightup");
            //light up exit label
            exitLabel.GetComponent<TextFader>().lightUp();

            if (Input.GetButtonDown("Fire1")) {
                Application.Quit();
            }

        }
	}

    public void OnMouseDown() {
        Application.Quit();
    }

    private void OnMouseOver() {
        exitLabel.GetComponent<TextFader>().lightUp();
    }
}
