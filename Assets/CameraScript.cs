using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    GameObject player;
    Vector3 position;
    Vector3 fixedPosition;

    public GameObject leftEye;
    public GameObject rightEye;

    Vector3 eyeVector;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        position = transform.position - player.transform.position;
        fixedPosition = new Vector3 (15f, 25f, -15f);

        eyeVector = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if(leftEye.GetComponent<CameraRaycaster>().isSeeingPlayer() && !rightEye.GetComponent<CameraRaycaster>().isSeeingPlayer() ) {
            //rotate
            if (eyeVector.x > -6) {
                    //eyeVector.x = eyeVector.x - 0.03f;
                eyeVector.x = eyeVector.x - (0.06f + (eyeVector.x/100 )  );
            }

            //default
            if (eyeVector.z > 0.1f) {
                eyeVector.z = eyeVector.z * 0.99f;
            }
        }

        if (!leftEye.GetComponent<CameraRaycaster>().isSeeingPlayer() && rightEye.GetComponent<CameraRaycaster>().isSeeingPlayer()) {
            //rotate
            if (eyeVector.z < 6) {
                //eyeVector.z = eyeVector.z + 0.03f;
                eyeVector.z = eyeVector.z + (0.06f - (eyeVector.z/100) );
            }

            //default
            if (eyeVector.x < -0.1f) {
                eyeVector.x = eyeVector.x * 0.99f;
            }
        }

        if (leftEye.GetComponent<CameraRaycaster>().isSeeingPlayer() && rightEye.GetComponent<CameraRaycaster>().isSeeingPlayer()) {

            //dafault
            if (eyeVector.x < -0.1f) {
                //eyeVector.x = eyeVector.x + 0.1f;
                eyeVector.x = eyeVector.x * 0.99f;
            }
            //dafault
            if (eyeVector.z > 0.1f) {
                eyeVector.z = eyeVector.z * 0.99f;
            }
        }

        if (!leftEye.GetComponent<CameraRaycaster>().isSeeingPlayer() && !rightEye.GetComponent<CameraRaycaster>().isSeeingPlayer()) {
            if (eyeVector.x > -6) {
                eyeVector.x = eyeVector.x - (0.06f + (eyeVector.x / 100));
            }
            if (eyeVector.z < 6) {
                eyeVector.z = eyeVector.z + (0.06f - (eyeVector.z / 100));
            }
        }



        //transform.position = player.transform.position + position + eyeVector;
        transform.position = player.transform.position + fixedPosition + eyeVector;

        transform.LookAt(player.transform.position);
	}

}
