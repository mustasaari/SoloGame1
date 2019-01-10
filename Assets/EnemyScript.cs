using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Sword") {
            Debug.Log("Sword Hit");
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}
