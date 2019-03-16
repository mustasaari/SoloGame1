using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarScript : MonoBehaviour {

    private float oldtransformy;
    private float oldtransformz;
    private float oldtransfromx;
    float deltaTime = 0.0f;

    // Use this for initialization
    void Start () {
        oldtransformy = transform.localScale.y;
        oldtransformz = transform.localScale.z;
        oldtransfromx = transform.localScale.x;
		
	}
	
	// Update is called once per frame
	void Update () {
        //GetComponent<RectTransform>().transform.position = new Vector3(10, 101, 10);
        //transform.localScale = new Vector3( ( GameManager.health/100f ) * 3f , 0.5f, 0.5f);

        if ( GameManager.health <= 0) {
            transform.localScale = new Vector3( 0f , oldtransformy, oldtransformz);
        }
        else {
            transform.localScale = new Vector3( (GameManager.health / 100f) * oldtransfromx, oldtransformy, oldtransformz);
        }

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        //transform.localScale = new Vector3(2, , 2);
    }

    void OnGUI() {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
