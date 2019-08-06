using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvasScript : MonoBehaviour {

    public Text scoreText;
    public InputField input;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateText()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    public void saveHighscoreData()
    {
        string name;
        if(input.text.Length > 0)
        {
            name = input.text;
        } else
        {
            name = "Cool person";
        }
        HighscoreScript.SaveFile(PlayerPrefs.GetInt("score"), name);
    }
}
