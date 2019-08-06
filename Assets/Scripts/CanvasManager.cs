using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    
    public Image shotInterval, healthBar;
    public Text healthText, fireRateText, rotRateText, scoreText;

    GameManagerScript gms;
    PlayerHealthScript phs;

    // Use this for initialization
    void Start () {
        gms = GameObject.Find("Game Manager").GetComponent<GameManagerScript>();
        phs = GameObject.Find("Player1").GetComponent<PlayerHealthScript>();
	}
	
	// Update is called once per frame
	void Update () {
        //update shot interval ui
        float shotInt = gms.getShotIntervalPercent();
        shotInterval.transform.localScale = new Vector3(shotInt, 1f);

        //update healthbar ui
        float healthPercent = phs.getHealthPercent();
        healthBar.transform.localScale = new Vector3(healthPercent, 1f);
        healthText.text = phs.getCurrHealth() + " HP";

        //update rate ui
        fireRateText.text = "Fire Rate: " + (1 / gms.getShotCoolDown());
        rotRateText.text = "Rotation Rate: " + gms.getRotSpeed();

        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
	}
}
