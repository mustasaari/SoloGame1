using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignpostPlay : MonoBehaviour {

    bool mouseover;

	// Use this for initialization
	void Start () {
        mouseover = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if ( mouseover) {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 0.5f );
        }

	}

    public void OnMouseOver() {
        
    }

    public void OnMouseEnter() {
        mouseover = true;
    }

    public void OnMouseExit() {
        mouseover = false;
    }
}
