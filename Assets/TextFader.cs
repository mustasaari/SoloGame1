using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFader : MonoBehaviour {

    bool fade = false;
    float red;
    float green;
    float blue;
    float alpha;
    float lightup;

	// Use this for initialization
	void Start () {
        red = GetComponent<TextMesh>().color.r;
        green = GetComponent<TextMesh>().color.g;
        blue = GetComponent<TextMesh>().color.b;
        alpha = GetComponent<TextMesh>().color.a;
        lightup = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (lightup > 0) {
            lightup -= 0.02f * Time.deltaTime * 60;
        }

        if (fade) {
            alpha = (alpha - 0.02f) * Time.deltaTime * 60;
        }
        GetComponent<TextMesh>().color = new Color(red + lightup, green + lightup, blue, alpha);

    }

    public void startFade() {
        fade = true;
    }

    public void lightUp() {
        if (lightup < 1 - green && lightup < 1 -red) {
                lightup = (lightup + 0.04f) * Time.deltaTime *60;
        }
    }
}
