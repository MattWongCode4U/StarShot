using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour {

    float maxHealth, health;
    GameManagerScript gms;

	// Use this for initialization
	void Start () {
        maxHealth = health = 50f;
        gms = GameObject.Find("Game Manager").GetComponent<GameManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            gms.gameOver();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            gms.playPlayerDamagedSFX();
            health -= 10f;
            Destroy(other.gameObject);
        }
        if(other.tag == "Health")
        {
            gms.playHealSFX();
            health += 10f;
            if(health >= maxHealth)
            {
                health = maxHealth;
            }
            Destroy(other.gameObject);
        }
        if(other.tag == "FireRate")
        {
            gms.fireRatePowerup();
            Destroy(other.gameObject);
        }
        if(other.tag == "RotRate")
        {
            gms.rotRatePowerup();
            Destroy(other.gameObject);
        }

        if(other.tag == "Wall")
        {
            gms.playPlayerDamagedSFX();
            health = 0f;
        }
    }

    public float getHealthPercent()
    {
        if(health <= 0)
        {
            return 0f;
        }
        return health / maxHealth;
    }

    public float getCurrHealth()
    {
        return health;
    }
}
