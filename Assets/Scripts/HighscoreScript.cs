using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighscoreScript : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
        GameData hs = LoadFile();
        if (hs != null)
        {
            string hsName = hs.name;
            int hsScore = hs.score;
            scoreText.text = hsName + ": " + hsScore;
        } else
        {
            scoreText.text = "No highscores found";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SaveFile(int newScore, string newName)
    {
        GameData old;
        string dest = Application.persistentDataPath + "/scores.dat";
        FileStream file = null;

        if (File.Exists(dest))
        {
            old = LoadFile();
            file = File.OpenWrite(dest);
        } else
        {
            file = File.Create(dest);
            old = null;
        }

        GameData data = new GameData(newScore, newName);

        if (old != null)
        {
            if (data.score < old.score)
            {
                data = old;
            }
        }

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public static GameData LoadFile()
    {
        string dest = Application.persistentDataPath + "/scores.dat";
        FileStream file;

        if (File.Exists(dest))
        {
            file = File.OpenRead(dest);
        } else
        {
            Debug.Log("File not found");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        return data;
    }
}

[System.Serializable]
public class GameData
{
    public int score;
    public string name;

    public GameData(int scoreInt, string nameStr)
    {
        score = scoreInt;
        name = nameStr;
    }
}
