using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    GameObject target;
    float speed;
    float step;
    float damage, maxhealth;

    int scoreWorth;

    int diff = 1;

    Material mat;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player1");
        speed = 5.0f;
        damage = 0f;
        maxhealth = 10f;

        scoreWorth = 5;

        int score = PlayerPrefs.GetInt("score");

        diff = (score / 25) + 1;
        if (score == 0)
        {
            diff = 1;
        }
        mat = transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        if(PlayerPrefs.GetInt("gameover") == 1)
        {
            return;
        }

        difficultyScale();

        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        if(maxhealth - damage <= 0)
        {
            GameObject.Find("Game Manager").GetComponent<GameManagerScript>().playEnemyDieSFX();
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + scoreWorth);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot")
        {
            Destroy(other.gameObject);
            damage += 10f;
        }
    }

    void difficultyScale()
    {
        int score = PlayerPrefs.GetInt("score");
        if (score % 25 == 0 && score != 0)
        {
            diff = (score / 25) + 1;
        } else if (score == 0)
        {
            diff = 1;
        }
        
        speed = diff * 5f;
        maxhealth = diff * 5;
        mat.color = Color.Lerp(Color.red, Color.blue, diff / 10f);
    }
}
