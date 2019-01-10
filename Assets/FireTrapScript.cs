using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapScript : MonoBehaviour {

    public float startDelay;
    public float repeatTime;
    bool isActive;
    GameObject upperLight;

	// Use this for initialization
	void Start () {
        InvokeRepeating("switchState", startDelay, repeatTime);
        upperLight = transform.GetChild(18).gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (isActive) {
            if (upperLight.GetComponent<Light>().intensity < 20) {
                upperLight.GetComponent<Light>().intensity += 0.4f;
            }
        }
        else {
            if (upperLight.GetComponent<Light>().intensity > 0f) {
                upperLight.GetComponent<Light>().intensity -= 0.4f;
            }
        }
		
	}

    public void switchState() {

        if (isActive == true) {
            isActive = false;
            for (int i = 2; i < 18; i++) {
                transform.GetChild(i).GetComponent<ParticleSystem>().enableEmission = false;
            }
        }
        else {
            isActive = true;
            for (int i = 2; i < 18; i++) {
                transform.GetChild(i).GetComponent<ParticleSystem>().enableEmission = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Player" && isActive) {
            collision.gameObject.GetComponent<playerScript>().takeDamage(1);
        }
    }
}
