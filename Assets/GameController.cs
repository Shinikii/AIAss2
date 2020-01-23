using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour {

    public Text isHot;
    public Text isNoisy;
    public Text isSafe;
    public Text ProbNum;
    int prob;
    bool safe = true;
    bool hot = true;
    bool noisy = true;
    int doorCount;

	// Use this for initialization
	void Start () {
        InitializeGame();
	}
	
	// Update is called once per frame
	void Update () {
        // Hitting the spacebar always restarts the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitializeGame();
        }
        if (Input.anyKeyDown)
        {
           if (safe == true)
            {
                nextLevel();
                doorCount++;
            }
        }
    }

    private void InitializeGame()
    {
        doorCount = 0;
        // Pick a random number
        prob = Random.Range(1, 10);

        // Set the text to start the game
        ProbNum.text = "Guess a number between 1 and 10";
    }

    private void nextLevel()
    {
    
        string path = "Assets/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Debug.Log(line);
        }
        reader.Close();
    
    }
}
