using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarScript : MonoBehaviour {

    private float oldtransformy;
    private float oldtransformz;
    private float oldtransfromx;

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

        //transform.localScale = new Vector3(2, , 2);
    }
}
