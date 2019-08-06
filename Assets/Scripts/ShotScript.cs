using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    float shotSpeed = 70;
    Rigidbody body;

    float deathTime, currTime;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        deathTime = 5.0f;
        currTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("gameover") == 1)
        {
            return;
        }

        body.velocity = transform.right * shotSpeed;

        //bullet cleanup
        if(currTime >= deathTime)
        {
            Destroy(gameObject);
        }
        currTime += Time.deltaTime;
	}
}
