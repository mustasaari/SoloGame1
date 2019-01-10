using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseScript : MonoBehaviour {

    GameObject player;
    private bool eaten;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (eaten) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
            transform.localScale -= new Vector3(1f, 1f, 1f);

            if ( transform.localScale.x < 0 || transform.localScale.y < 0 || transform.localScale.z < 0) {
                Destroy(gameObject);
            }
        }
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            player = collision.gameObject;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            eaten = true;
        }
    }
}
