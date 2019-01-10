using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static int health = 100;
    private static bool gameStart = true;

    private void Start() {

        if (gameStart) {
            health = 100;
            gameStart = false;
        }


    }
}
