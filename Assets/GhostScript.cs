using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    private float startPlane;
    private float MyDeltaTime;
    public GameObject player;
    //bool escape;
    float coolDown;
    int randomAction;

    public GameObject attack_sound;
    public GameObject runawaySound;

    // Use this for initialization
    void Start () {
        startPlane = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
        //escape = false;
        coolDown = 0;
        randomAction = 0;
	}
	
	// Update is called once per frame
	void Update () {

        MyDeltaTime = Time.deltaTime * 60;

        //if (!escape) {

            //Look for player
            if (randomAction == 0 || randomAction == 1) {

                Vector3 lookMouseV3;
                Vector3 direction = player.transform.position - transform.position;


                lookMouseV3.x = direction.x;
                lookMouseV3.z = direction.z;
                lookMouseV3.y = 0;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookMouseV3), 1f * MyDeltaTime);

            }

            if (randomAction == 2) {
                transform.Rotate(0, -0.5f, 0);
                //transform.Rotate(Vector3.right);
            }

            if (randomAction == 3) {
                transform.Rotate(0, 0.5f, 0);
                //transform.Rotate(Vector3.left);
            }

            if (randomAction == 4) {
                transform.Translate(Vector3.forward * MyDeltaTime * 0.02f);
            }

            if ( randomAction == 10) {

                Vector3 lookMouseV3;
                Vector3 direction = transform.position - player.transform.position;


                lookMouseV3.x = direction.x;
                lookMouseV3.z = direction.z;
                lookMouseV3.y = 0;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookMouseV3), 4f * MyDeltaTime);

                //runaway
                transform.Translate(Vector3.forward * MyDeltaTime * 0.15f);
            }



            //liiku eteenpäin
            transform.Translate(Vector3.forward * MyDeltaTime * 0.02f);
            coolDown = coolDown - 1 * MyDeltaTime;

            if (coolDown < 0) {

                if (GetComponentInChildren<Cloth>().enabled == false) {
                    GetComponentInChildren<Cloth>().enabled = true;
                }

                if (randomAction == 10) {
                    GetComponentInChildren<Cloth>().enabled = false;
                }

                randomAction = Random.Range(0, 5);
                coolDown = 60;
                //Debug.Log("Random action : " + randomAction);

            }

        //}

    }

    private void OnTriggerEnter(Collider other) {
        //ghostsound
        if (other.gameObject.tag == "Player") {
            Instantiate(attack_sound, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay(Collider other) {
        //Debug.Log("Kummitustormays");
        if (other.gameObject.tag == "Player") {
            GameManager.health--;
        }
    }

    public void runAway() {
        //Debug.Log("Kummitus RUNAWAY");
        Instantiate(runawaySound, transform.position, transform.rotation);
        randomAction = 10;
        coolDown = 250;
    }
}
