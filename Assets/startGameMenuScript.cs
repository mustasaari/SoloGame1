using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGameMenuScript : MonoBehaviour {

    public Light valo;

    bool dim = false;
    float translation = 0;
    bool mouseover = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dim) {
            valo.intensity -= 0.01f;
        }

        if (valo.intensity <= 0) {
            SceneManager.LoadScene("Level1");
        }

        if (mouseover && translation < 5) {
            transform.Translate(Vector3.forward * 0.1f);
            translation += 0.5f;
        }
        else if (!mouseover && translation > 0) {
            transform.Translate(Vector3.forward * -0.1f);
            translation -= 0.5f;
        }

    }

    private void OnMouseOver() {
        mouseover = true;
    }

    private void OnMouseEnter() {
        
    }

    private void OnMouseExit() {
        mouseover = false;
    }

    private void OnMouseDown() {
        dim = true;
    }
}
