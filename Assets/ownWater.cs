using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ownWater : MonoBehaviour {

    public float speedx;
    public float speedy;
    private float curx;
    private float cury;
    public float laineSpeed;

    Vector3 laine;

	// Use this for initialization
	void Start () {
        curx = GetComponent<Renderer>().material.mainTextureOffset.x;
        curx = GetComponent<Renderer>().material.mainTextureOffset.y;
        laine = new Vector3(0.05f, 0.05f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        curx += Time.deltaTime * speedx;
        cury += Time.deltaTime * speedy;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(laine.x/30 +curx, laine.y/30 +cury));

        laine = Quaternion.Euler(laineSpeed, laineSpeed, 0) * laine;
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(3 + laine.x/20, 3 + laine.y/20));
    }
}
