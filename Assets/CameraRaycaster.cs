using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour {

    bool imSeeingPlayer;
    GameObject player;
    Vector3 position;

    // Use this for initialization
    void Start () {
        imSeeingPlayer = true;
        player = GameObject.FindGameObjectWithTag("Player");
        position = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update() {

        transform.position = player.transform.position + position;
        transform.LookAt(player.transform.position);

        RaycastHit hit;
        if ( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50f) ) {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            //Debug.Log("Camera Eye : " +hit.transform.gameObject.tag);

            if (hit.transform.gameObject.tag == "Player") {
                imSeeingPlayer = true;
            }
            else {
                imSeeingPlayer = false;
            }

        }

    }

    public bool isSeeingPlayer() {
        return imSeeingPlayer;
    }
}
