using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

    private ParticleSystem pasy;
    private bool lightIncreasing;

	// Use this for initialization
	void Start () {
        pasy = GetComponent<ParticleSystem>();
        lightIncreasing = true;
	}
	
	// Update is called once per frame
	void Update () {
	
        if (!pasy.IsAlive()) {
            Destroy(gameObject);
        }
        if (GetComponentInChildren<Light>().intensity >= 25) {
            lightIncreasing = false;
        }


        if (lightIncreasing) {
            GetComponentInChildren<Light>().intensity += 0.35f;
        }
        else {
            GetComponentInChildren<Light>().intensity -= 0.35f;
        }

        transform.GetChild(0).Translate(Vector3.forward * 0.1f);


	}
}
