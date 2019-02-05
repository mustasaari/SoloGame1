using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSmash : MonoBehaviour {

    Vector3 entropy;
    public bool barrelLidCode;
    public GameObject enemyBug;
    public bool spawnBug;
    public GameObject cheese;
    public bool spawnCheese;
    GameObject Audio_Bum;

    private int hitPoints;

    private float MyDeltaTime;

	// Use this for initialization
	void Start () {
        entropy = new Vector3(Random.Range(-1, 1), 0, Random.Range(-3, 3));
        Audio_Bum = (GameObject) Resources.Load("Audio_Bum", typeof(GameObject));
        hitPoints = 50;
    }
	
	// Update is called once per frame
	void Update () {
        MyDeltaTime = Time.deltaTime * 60;
	}

    private void OnCollisionEnter(Collision collision) {
        playSound();
    }

    public void smashDoor(Vector3 directionVector) {
        GetComponent<Rigidbody>().isKinematic = false;
        if (barrelLidCode) {
            barrel();
        }
		GetComponent<Rigidbody>().AddForce((directionVector * Random.Range(0.5f , 1f) + (entropy * MyDeltaTime)) * MyDeltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Sword") { 
            if (barrelLidCode) {
                barrel();
            }
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce((transform.position - other.gameObject.transform.position) *2f * MyDeltaTime, ForceMode.Impulse);
            Instantiate(Audio_Bum, transform.position, transform.rotation);
            reduceHP();
        }
    }

    public void barrel() {
        GetComponent<BoxCollider>().size = new Vector3(0.015f, 0.015f, 0.05f);
        GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        if (spawnBug) {
            spawnB();
        }
        if (spawnCheese) {
            spawnC();
        }
    }

    public void spawnB() {
        Instantiate(enemyBug, transform.position, transform.rotation);
        spawnBug = false;
    }

    public void spawnC() {
        Instantiate(cheese, transform.position, transform.rotation);
        spawnCheese = false;
    }

    public void playSound() {
        Instantiate(Audio_Bum, transform.position, transform.rotation);
        reduceHP();
    }

    public void reduceHP() {
        hitPoints--;
        if (hitPoints < 1) {
            Destroy(gameObject);
        }
    }
}
