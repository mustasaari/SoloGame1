using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour {

    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
    public GameObject spotlight;

    public GameObject endtext;

    bool end = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (end) {
            torch1.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().intensity -= 0.1f;
            torch2.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().intensity -= 0.1f;
            torch3.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().intensity -= 0.1f;

            spotlight.GetComponent<Light>().intensity -= 0.5f;

            endtext.GetComponent<Text>().color = new Color(endtext.GetComponent<Text>().color.r, endtext.GetComponent<Text>().color.g, endtext.GetComponent<Text>().color.b, endtext.GetComponent<Text>().color.a + 0.05f);
        }
	}

    public void OnTriggerEnter(Collider other) {
        Debug.Log("Collison enter");
        if (other.gameObject.tag == "Player") {
            torch1.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().emissionRate = 0f;
            torch2.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().emissionRate = 0f;
            torch3.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().emissionRate = 0f;
            end = true;
        }
    }
}
