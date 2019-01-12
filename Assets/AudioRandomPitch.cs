using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPitch : MonoBehaviour {

    AudioSource audio;

    // Use this for initialization
    void Start() {
        audio = GetComponent<AudioSource>();
        audio.pitch = Random.Range(0.5f, 1.5f);


    }

    // Update is called once per frame
    void Update() {

        if (!audio.isPlaying) {
            Destroy(gameObject);
        }
    }
}
