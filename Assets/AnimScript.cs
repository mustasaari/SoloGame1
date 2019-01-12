using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {

    Animator animator;
    Rigidbody rb;
    int time;
    public GameObject book;
    public GameObject sword;
    bool spellCastRun;
    public GameObject spellParticle;
    bool playerHasDied;

    public GameObject Audio_Sword;
    public GameObject Audio_Spell;

	// Use this for initialization
	void Start () {
     
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody>();
        spellCastRun = false;
        playerHasDied = false;
        //book = GameObject.FindGameObjectWithTag("SpellBook");
        //sword = GameObject.FindGameObjectWithTag("Sword");
		
	}
	
	// Update is called once per frame
	void Update () {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Slash1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Spell")) {
            //Debug.Log("Nyyt soi attack tai spell");
            if ( animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f ) {
                //animator.SetBool("Attack", false);    //animator statemachine hoitaa nämä nykyään
                //animator.SetBool("Spell", false);     //animator statemachine hoitaa nämä nykyään
                book.GetComponent<Animator>().SetBool("Open", false);
                GetComponentInParent<playerScript>().enableControls(true);
                sword.GetComponent<SphereCollider>().enabled = false;
            }
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Spell")) {
            spellCastRun = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Spell") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && !spellCastRun) {
            spellCastRun = true;
            GetComponentInParent<playerScript>().spellCast();
        }

        if (Input.GetButton("Fire1") && !animator.GetBool("Spell") && !animator.GetBool("Attack")) {

            Instantiate(Audio_Sword, transform.position, transform.rotation);

            animator.SetBool("Attack", true);

            GetComponentInParent<playerScript>().stopMovement();
            GetComponentInParent<playerScript>().enableControls(false);
            sword.GetComponent<SphereCollider>().enabled = true;
        }
        if (Input.GetButtonDown("Fire2") && !animator.GetBool("Spell") && !animator.GetBool("Attack") ) {

            Instantiate(Audio_Spell, transform.position, transform.rotation);

            //if (!animator.GetBool("Spell")) {   //Run only once when spellcast starts
                
            //}

            animator.SetBool("Spell", true);
            GetComponentInParent<playerScript>().stopMovement();
            GetComponentInParent<playerScript>().enableControls(false);
            Instantiate(spellParticle, transform.position, transform.rotation);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Spell") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f) {
            book.GetComponent<Animator>().SetBool("Open", true);
            //Debug.Log("Kirja auki");
        }

        //if (Input.GetButton("Jump")) {
            //animator.SetBool("Jump", true);
            //GetComponentInParent<playerScript>().enableControls(false);
            //animator.SetBool("Death", true);
            //GetComponentInParent<playerScript>().stopMovement();
            //rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
        //}

        if (rb.velocity.y < 0) {
            //animator.SetBool("Jump", false);
            //animator.SetBool("Fall", true);
        }

        if (rb.velocity.magnitude > 0.2f) {
            animator.SetBool("Walk", true);
        }
        else {
            animator.SetBool("Walk", false);
        }

        //if (time > 0) {
        //    time--;
        //}

        //if (time <= 0) {
        //    animator.SetBool("Attack", false);
        //

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|damage") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f) {
            animator.SetBool("Damage", false);
        }

        if (GameManager.health <= 0) {
            Death();
        }

    }

    public void Death() {
        if (playerHasDied == false) {
            GetComponentInParent<playerScript>().enableControls(false);
            animator.SetBool("Death", true);
            GetComponentInParent<playerScript>().stopMovement();
            rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            playerHasDied = true;
            GetComponentInParent<Rigidbody>().isKinematic = true;
            GetComponentInParent<SphereCollider>().enabled = false;
        }
    }

    public bool playerDied() {
        return playerHasDied;
    }
}
