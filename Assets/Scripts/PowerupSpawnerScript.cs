using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnerScript : MonoBehaviour {

    public GameObject health, fireRate, rotRate;
    List<GameObject> list;
    float spawnDelay, spawnTimer;

	// Use this for initialization
	void Start () {
        list = new List<GameObject>();
        list.Add(health);
        list.Add(fireRate);
        list.Add(rotRate);

        spawnDelay = 30f;
        spawnTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(spawnTimer >= spawnDelay)
        {
            spawnPowerup();
            spawnTimer = 0.0f;
        }
        spawnTimer += Time.deltaTime;
	}

    GameObject choosePowerup()
    {
        return list[Random.Range(0, list.Count)];
    }

    Vector3 randomPoint()
    {
        return new Vector3(Random.Range(-70f, 70f), Random.Range(-50f, 50f), 0.0f);
    }

    void spawnPowerup()
    {
        GameObject powerup = choosePowerup();
        Instantiate(powerup, randomPoint(), powerup.transform.rotation);
    }
}
