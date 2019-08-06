using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public GameObject p1, shotSpawn;
    public GameObject shotPrefab;
    public GameObject enemyPrefab;
    public List<Transform> enemySpawns;
    public GameObject gameoverCanvas;
    public AudioSource music, healSFX, fireRateSFX, turnRateSFX, enemyDiesSFX, playerDamagedSFX;

    float moveSpeed, rotSpeed; //speed constants
    Vector3 vertSpeed, horzSpeed; //move speed vectors
    bool cw; //clockwise rotation

    float shotCoolDown, shotCurrTime;

    float enemySpawnCoolDown, enemySpawnCurrTime;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("score", 0);
        gameoverCanvas.SetActive(false);

        moveSpeed = 1.5f;
        rotSpeed = 2.0f;
        vertSpeed = new Vector3(0, moveSpeed, 0);
        horzSpeed = new Vector3(moveSpeed, 0, 0);
        cw = true;

        shotCoolDown = 2.0f;
        shotCurrTime = 1.5f;

        enemySpawnCoolDown = 4.0f;
        enemySpawnCurrTime = 3.0f;

        PlayerPrefs.SetInt("gameover", 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerPrefs.GetInt("gameover") == 1)
        {
            gameoverCanvas.SetActive(true);
            return;
        }

        #region player movement
        //p1 movement
        if (Input.GetKey("w"))
        {
            p1.transform.position += vertSpeed;
        }
        if (Input.GetKey("a"))
        {
            p1.transform.position += -horzSpeed;
        }
        if (Input.GetKey("s"))
        {
            p1.transform.position += -vertSpeed;
        }
        if (Input.GetKey("d"))
        {
            p1.transform.position += horzSpeed;
        }

        p1.transform.position += Input.GetAxisRaw("Vertical") * vertSpeed;
        p1.transform.position += Input.GetAxisRaw("Horizontal") * horzSpeed;
        #endregion

        #region toggle rotation direction
        //switch rotation
        if (Input.GetKeyDown("space"))
        {
            cw = !cw;
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button0) 
            || Input.GetKeyDown(KeyCode.Joystick1Button1)
            || Input.GetKeyDown(KeyCode.Joystick1Button2)
            || Input.GetKeyDown(KeyCode.Joystick1Button3)
            || Input.GetKeyDown(KeyCode.Joystick1Button4)
            || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            cw = !cw;
        }
        #endregion

        #region rotate the player
        //perform rotation
        if (cw)
        {
            p1.transform.Rotate(0, 0, -rotSpeed, Space.World);
        } else
        {
            p1.transform.Rotate(0, 0, rotSpeed, Space.World);
        }
        #endregion

        #region shot timer
        if (shotCurrTime >= shotCoolDown)
        {
            GameObject.Instantiate(shotPrefab, shotSpawn.transform.position, p1.transform.rotation);
            shotCurrTime = 0;
        }
        shotCurrTime += Time.deltaTime;
        #endregion

        #region spawn enemy
        if(enemySpawnCurrTime >= enemySpawnCoolDown)
        {
            Transform chosenSpawn = enemySpawns[Random.Range(0, enemySpawns.Count)];
            Instantiate(enemyPrefab, chosenSpawn.position, enemyPrefab.transform.rotation);
            enemySpawnCurrTime = 0;
        }
        enemySpawnCurrTime += Time.deltaTime;
        #endregion
    }

    public float getShotIntervalPercent()
    {
        return shotCurrTime / shotCoolDown;
    }

    public float getShotCoolDown()
    {
        return shotCoolDown;
    }

    public float getRotSpeed()
    {
        return rotSpeed;
    }

    public void gameOver()
    {
        PlayerPrefs.SetInt("gameover", 1);
        gameoverCanvas.GetComponent<GameOverCanvasScript>().updateText();
    }

    #region powerups
    public void fireRatePowerup()
    {
        shotCoolDown *= 0.75f;
        playFireRateSFX();
    }

    public void rotRatePowerup()
    {
        rotSpeed *= 1.3f;
        playTurnRateSFX();
    }
    #endregion

    public void playHealSFX()
    {
        healSFX.Play();
    }

    public void playFireRateSFX()
    {
        fireRateSFX.Play();
    }
    public void playTurnRateSFX()
    {
        turnRateSFX.Play();
    }
    public void playEnemyDieSFX()
    {
        enemyDiesSFX.Play();
    }
    public void playPlayerDamagedSFX()
    {
        playerDamagedSFX.Play();
    }
}
