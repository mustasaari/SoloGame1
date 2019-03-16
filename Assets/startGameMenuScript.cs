using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGameMenuScript : MonoBehaviour {

    public Light valo;
    public Light torch1;
    public Light torch2;

    public GameObject fadeGameName;
    public GameObject fadeStart;
    public GameObject fadeExit;

    bool dim = false;
    float translation = 0;
    bool mouseover = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dim) {
            valo.intensity = valo.intensity -0.1f * Time.deltaTime * 60;
            torch1.intensity = torch1.intensity -0.05f * Time.deltaTime * 60;
            torch2.intensity = torch2.intensity  -0.05f * Time.deltaTime * 60;
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

        if (Input.GetAxis("Horizontal") > 0) {
            Debug.Log("lightup");
            //light up exit label
            fadeStart.GetComponent<TextFader>().lightUp();
            if (Input.GetButtonDown("Fire1")) {
                dim = true;
                fadeGameName.GetComponent<TextFader>().startFade();
                fadeStart.GetComponent<TextFader>().startFade();
                fadeExit.GetComponent<TextFader>().startFade();
            }
        }

    }

    private void OnMouseDown() {
        dim = true;
        fadeGameName.GetComponent<TextFader>().startFade();
        fadeStart.GetComponent<TextFader>().startFade();
        fadeExit.GetComponent<TextFader>().startFade();
    }

    private void OnMouseOver() {
        fadeStart.GetComponent<TextFader>().lightUp();
    }
}
