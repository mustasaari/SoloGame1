using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    Rigidbody rb;
    GameObject leftEye;
    GameObject rightEye;
    bool rightEyeSeesWall;
    bool leftEyeSeesWall;
    bool rightEyeSeesPlayer;
    bool leftEyeSeesPlayer;
    bool rightEyeSeesGround;
    bool leftEyeSeesGround;
    bool rightEyeSeesPit;
    bool leftEyeSeesPit;
    bool rightEyeSeesEnemy;
    bool leftEyeSeesEnemy;
    float walkRotation;
    float walkSpeed;
    bool betterTurnRight;
    float leftEyeDistance;
    float rightEyeDistance;
    float defaultWalkSpeed;
    bool isAlive;
    int rimpuilu;

    private float MyDeltaTime;

    Animator animator;
    public GameObject Audio_Splat;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        leftEye = this.gameObject.transform.GetChild(0).gameObject;
        rightEye = this.gameObject.transform.GetChild(1).gameObject;
        walkRotation = 0.0f;
        defaultWalkSpeed = 0.055f;
        walkSpeed = defaultWalkSpeed;
        betterTurnRight = false;
        animator = GetComponentInChildren<Animator>();
        isAlive = true;
        rimpuilu = 0;
    }
	
	// Update is called once per frame
	void Update () {

        MyDeltaTime = Time.deltaTime * 60;

        rightEyeSeesWall = false;
        leftEyeSeesWall = false;
        rightEyeSeesGround = false;
        leftEyeSeesGround = false;
        rightEyeSeesPlayer = false;
        leftEyeSeesPlayer = false;
        rightEyeSeesPit = false;
        leftEyeSeesPit = false;
        rightEyeSeesEnemy = false;
        leftEyeSeesEnemy = false;
        leftEyeDistance = 0.0f;
        rightEyeDistance = 0.0f;

        //transform.Translate(Vector3.forward * 0.01f);



        if (isAlive) {

            RaycastHit hit;
        if (Physics.Raycast(leftEye.transform.position, leftEye.transform.TransformDirection(Vector3.forward), out hit, 10f )) {
            Debug.DrawRay(leftEye.transform.position, leftEye.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(hit.transform.gameObject.tag == "Player") {
                leftEyeSeesPlayer = true;
            }
            if (hit.transform.gameObject.tag == "Ground") {
                leftEyeSeesGround = true;
            }
            if (hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "DoorBreakable") {
                leftEyeSeesWall = true;
            }
            if (hit.transform.gameObject.tag == "Enemy") {
                leftEyeSeesEnemy = true;
            }
        }
        else {
            leftEyeSeesPit = true;
        }
        leftEyeDistance = hit.distance;

        if (Physics.Raycast(rightEye.transform.position, rightEye.transform.TransformDirection(Vector3.forward), out hit, 10f)) {
            //Debug.Log(hit.transform.gameObject.tag);
            Debug.DrawRay(rightEye.transform.position, rightEye.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.gameObject.tag == "Player") {
                rightEyeSeesPlayer = true;
            }
            if (hit.transform.gameObject.tag == "Ground") {
                rightEyeSeesGround = true;
            }
            if (hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "DoorBreakable") {
                rightEyeSeesWall = true;
            }
            if (hit.transform.gameObject.tag == "Enemy") {
                rightEyeSeesEnemy = true;
            }
        }
        else {
            rightEyeSeesPit = true;
        }
        rightEyeDistance = hit.distance;


        if (rightEyeSeesPlayer) {
            //rb.transform.Rotate(Vector3.up * 0.2f);
            walkRotation += 0.08f;
            if (walkSpeed < defaultWalkSpeed * 2f ) {
                walkSpeed += 0.003f;
            }
            animator.SetBool("Eat", true);

        }
        if (leftEyeSeesPlayer) {
            //rb.transform.Rotate(Vector3.up * -0.2f);    //rotate left
            walkRotation -= 0.08f;
            if (walkSpeed < defaultWalkSpeed * 2f) {
                walkSpeed += 0.003f;
            }
            animator.SetBool("Eat", true);
        }
        if (leftEyeSeesEnemy) {
            walkRotation += 0.06f;
        }
        if (rightEyeSeesEnemy) {
            walkRotation -= 0.06f;
        }
        if (leftEyeSeesWall) {
            betterTurnRight = true;
        }
        if (rightEyeSeesWall) {
            betterTurnRight = false;
        }

        if (leftEyeSeesWall && rightEyeSeesGround) {
            //rb.transform.Rotate(Vector3.up * 0.2f);     //rotate right
            walkRotation += 0.02f;
        }
        if (rightEyeSeesWall && leftEyeSeesGround) {
            //rb.transform.Rotate(Vector3.up * -0.2f);     //rotate left
            walkRotation -= 0.02f;
        }
        if (rightEyeSeesPit && leftEyeSeesGround) {
            //rb.transform.Rotate(Vector3.up * -0.2f);     //rotate left
            walkRotation -= 0.02f;
        }
        if (leftEyeSeesPit && rightEyeSeesGround) {
            //rb.transform.Rotate(Vector3.up * 0.2f);     //rotate right
            walkRotation += 0.02f;
        }
        if (leftEyeSeesPit && rightEyeSeesWall) {
            walkRotation -= 0.02f;
            walkSpeed = walkSpeed * 0.95f;
        }
        if (rightEyeSeesPit && leftEyeSeesWall) {
            walkRotation += 0.02f;
            walkSpeed = walkSpeed * 0.95f;
        }

        if ( leftEyeSeesPit && rightEyeSeesPit ) {
            //walkRotation += 0.02f;
            //rb.transform.Rotate(Vector3.up * walkRotation);
            //walkSpeed = 0.02f;
            if (betterTurnRight) {
                walkRotation += 0.2f;
            }
            else {
                walkRotation -= 0.2f;
            }
            if (walkSpeed > 0 ) {
                walkSpeed = walkSpeed * 0.95f;
            }
        }

        if ( leftEyeSeesGround && rightEyeSeesGround ) {
            walkRotation += Random.Range(-0.02f, 0.02f);
        }

        if (leftEyeSeesWall && rightEyeSeesWall) {

            if (walkRotation >= 0) {
                walkRotation += 0.04f;
            }
            else {
                walkRotation -= 0.04f;
            }
            walkSpeed = walkSpeed * 0.95f;
        }


        if ( walkRotation > 1f) {
            walkRotation = 1f;
        }
        if (walkRotation < -1f) {
            walkRotation = -1f;
        }
        if (walkRotation > 0.1f) {
            walkRotation -= 0.01f;
        }
        if (walkRotation < -0.1f) {
            walkRotation += 0.01f;
        }
        if (walkSpeed < defaultWalkSpeed) {
            walkSpeed += 0.001f;
        }
        if (walkSpeed > defaultWalkSpeed) {
            walkSpeed -= 0.001f;
        }

                rb.transform.Rotate(Vector3.up * walkRotation * MyDeltaTime);
                rb.transform.Translate(Vector3.forward * walkSpeed * MyDeltaTime);


            //transform.Rotate(Vector3.up * walkRotation);
            //transform.Translate(Vector3.forward * walkSpeed);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Eat") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f) {
            animator.SetBool("Eat", false);
        }


    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("OnTrigger");
        if (other.gameObject.tag == "Sword") {
            animator.SetBool("Death", true);
            if (isAlive) {
                Instantiate(Audio_Splat, transform.position, transform.rotation);
            }

            isAlive = false;
            //GetComponent<BoxCollider>().enabled = false;
            //rb.isKinematic = true;
            //Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (isAlive) {
            if (collision.gameObject.tag == "Player") {
                collision.gameObject.GetComponent<playerScript>().takeDamage(1);
                //collision.gameObject.GetComponent<playerScript>().rotateTowards(transform);
                collision.gameObject.GetComponent<playerScript>().bounceAway(transform);
            }
        }

        //IF BUG IS UPSIDE DOWN THEN DO WHAT?!?!
        if (Vector3.Dot(transform.up, Vector3.down) >= -0.05 && isAlive) {
            rb.AddForce(Vector3.up * 5);
            rb.AddTorque(new Vector3(Random.Range(-rimpuilu, rimpuilu),Random.Range(-rimpuilu, rimpuilu), Random.Range(-rimpuilu,rimpuilu) ) );
            //transform.Rotate(Vector3.forward * Time.deltaTime * 50);
            rimpuilu++;
        }
        else {
            rimpuilu = 0;
        }
    }
}
