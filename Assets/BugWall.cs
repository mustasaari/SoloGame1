using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugWall : MonoBehaviour {

    public int startTime;
    public int repeatSpeed;
    public GameObject bug;
    public GameObject audio;
    public GameObject bugSpawnAudio;
    bool enabled;

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().speed = 0;
        InvokeRepeating("SpawnBugs", startTime, repeatSpeed);
        enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spellHits() {
        //Debug.Log("BUGWALL HIT");
        if (enabled) {
            GetComponent<Animator>().speed = 1;
            enabled = false;
            Instantiate(audio, transform.position, transform.rotation);
        }
    }

    public void SpawnBugs() {
        if ( enabled) {
            GameObject clone;
            clone = Instantiate(bug, transform.position, transform.rotation);
            clone.transform.Rotate(0, 90, 1);
            clone.GetComponent<Rigidbody>().AddForce(Vector3.right * 7, ForceMode.Impulse);
            Instantiate(bugSpawnAudio, transform.position, transform.rotation);
        }
    }
}
