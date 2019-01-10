﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    Rigidbody rb;
    public float mouseTopSpeed;
    public float keyboardForcesWalk;
    Animator animator;
    bool controlsEnabled;
    Vector3 movementVector;

    Vector3 lookDirectionVector;

    Camera mainCamera;

    int firstFramesMove;

    public GameObject cameraLeftEye;
    public GameObject cameraRightEye;
    Vector3 cameraLeftEyePos;
    Vector3 cameraRightEyePos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        controlsEnabled = true;
        lookDirectionVector = new Vector3(1, 0, 0);
        mainCamera = Camera.main;
        firstFramesMove = 20;

        cameraRightEyePos = new Vector3(12f , 5.5f, 0f);
        cameraLeftEyePos = new Vector3(0f, 5.5f, 12f);
	}

    // Update is called once per frame
    void Update() {

        cameraLeftEye.transform.position = transform.position + cameraLeftEyePos;
        cameraRightEye.transform.position = transform.position + cameraRightEyePos;

        if(firstFramesMove > 0) {
            rb.AddForce( Quaternion.Euler(0, transform.eulerAngles.y ,0) * Vector3.forward * 27f);
            firstFramesMove--;
        }

        //transform.Translate(Input.GetAxis("Horizontal") * 0.2f ,0, Input.GetAxis("Vertical")*0.2f );
        Debug.Log(GameManager.health);

        if (controlsEnabled) {

            if (rb.velocity.magnitude < mouseTopSpeed) {
                movementVector = new Vector3(Input.GetAxis("Horizontal") * keyboardForcesWalk, 0, Input.GetAxis("Vertical") * keyboardForcesWalk);
                //movementVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y , 0) * movementVector;
                movementVector = Quaternion.Euler(0, -45, 0) * movementVector;


                rb.AddForce(movementVector, ForceMode.Impulse);


                //rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * keyboardForcesWalk, 0, Input.GetAxis("Vertical") * keyboardForcesWalk), ForceMode.Impulse);
            }
            //transform.rotation = Quaternion.LookRotation(rb.velocity);
            if (rb.velocity.magnitude > 0.001f) {
                //if (rb.velocity.x != 0) {
                //lookDirectionVector.x = rb.velocity.x;
                //}
                //if (rb.velocity.z != 0) {
                //lookDirectionVector.z = rb.velocity.z;
                //}
                lookDirectionVector.x = rb.velocity.x;
                lookDirectionVector.z = rb.velocity.z;


                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDirectionVector), 7f);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(rb.velocity.x, 0, rb.velocity.z)), 7f);
            }

            if (Input.GetButtonDown("Jump")) {
                Debug.Log("Jump");
            //rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            }
        }
        else {
            Debug.Log("Controllit EITOIMI!!!!");
        }

    }

    public void stopMovement() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }

    public void enableControls(bool x) {
        controlsEnabled = x;
    }

    public void spellCast() {
        Debug.Log("Spell cast has started");
        RaycastHit[] hit;

        hit = Physics.SphereCastAll(transform.position, 4f, transform.forward, 12f);
        Vector3 directionVector;
        foreach (RaycastHit x in hit) {

            if (x.transform.gameObject.tag == "Enemy") {
                directionVector = x.transform.gameObject.transform.position - transform.position;
                x.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(directionVector.x, 10 ,directionVector.z), ForceMode.Impulse);
            }
            if (x.transform.gameObject.tag == "DoorBreakable") {
                directionVector = x.transform.gameObject.transform.position - transform.position;
                x.transform.gameObject.GetComponent<DoorSmash>().smashDoor(new Vector3(directionVector.x, 5, directionVector.z ));
            }
            if (x.transform.gameObject.tag == "Cheese") {
                Debug.Log("JUUUSTO");
                directionVector = x.transform.gameObject.transform.position - transform.position;
                x.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(directionVector.x, 10, directionVector.z), ForceMode.Impulse);
            }
        }

    }

    private void OnCollisionEnter(Collision collision) {
        //if (collision.gameObject.tag == "Enemy") {
            //takeDamage(1);
            //animator.SetBool("Damage", true);
            //stopMovement();
        //}
    }

    public void takeDamage(int x) {
        animator.SetBool("Damage", true);
        GameManager.health = GameManager.health - x;
    }
}