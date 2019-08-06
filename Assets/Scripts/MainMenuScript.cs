using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void highscoreScreen()
    {
        SceneManager.LoadScene("Highscores");
    }

    public void gameDetails()
    {
        SceneManager.LoadScene("Details");
    }
}
