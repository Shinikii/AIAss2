using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour
{

    public Text isHot;
    public Text isNoisy;
    public Text isSafe;
    public Text ProbNum;
    public Text DoorCheck;
    public Text KeyCheck;
    public Text LevelCount;

    double prob;
    bool safe = true;
    bool hot = true;
    bool noisy = true;
    string combo;
    int doorCount;
    List<double> probs = new List<double>();

    // Use this for initialization
    void Start()
    {
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Hitting the spacebar always restarts the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitializeGame();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            if (safe == true)
            {
                nextLevel();
                doorCount++;
                LevelCount.text = doorCount.ToString();
}
            else
            {
                Debug.Log("Failed, restarting");
                InitializeGame();
                nextLevel();
                LevelCount.text = doorCount.ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            
            Debug.Log("Failed, restarting");
            InitializeGame();
            nextLevel();
            LevelCount.text = doorCount.ToString();
            
        }
    }

    private void InitializeGame()
    {
        doorCount = 0;

        string path = "Assets/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] words = line.Split('\t');

            foreach (var word in words)
            {
                //Debug.Log(word);
                double temp;
                var isNumeric = double.TryParse(word, out temp);
                if (isNumeric == true)
                {
                    probs.Add(temp);
                }
            }

        }

        foreach (var num in probs)
        {
            Debug.Log(num);
        }
        reader.Close();

    }

    private void nextLevel()
    {
        int rand = Random.Range(1, 100);
        int buffer = 0;
        int oldbuffer;
        int key = 0;

        for (int i = 0; i < 8; i++)
        {
            int tempNum = (int)(probs[i] * 100);
            oldbuffer = buffer;
            buffer += tempNum;
            if (oldbuffer < rand && rand <= buffer)
            {
                key = i + 1;
            }
            Debug.Log(oldbuffer);
            Debug.Log(", ");
            Debug.Log(buffer);
        }
        switch (key)
        {
            case 1:
                hot = true;
                noisy = true;
                safe = true;
                combo = "YYY";
                prob = probs[0];
                break;
            case 2:
                hot = true;
                noisy = true;
                safe = false;
                combo = "YYN";
                prob = probs[1];
                break;
            case 3:
                hot = true;
                noisy = false;
                safe = true;
                combo = "YNY";
                prob = probs[2];
                break;
            case 4:
                hot = true;
                noisy = false;
                safe = false;
                combo = "YNN";
                prob = probs[3];
                break;
            case 5:
                hot = false;
                noisy = true;
                safe = true;
                combo = "NYY";
                prob = probs[4];
                break;
            case 6:
                hot = false;
                noisy = true;
                safe = false;
                combo = "NYN";
                prob = probs[5];
                break;
            case 7:
                hot = false;
                noisy = false;
                safe = true;
                combo = "NNY";
                prob = probs[6];
                break;
            case 8:
                hot = false;
                noisy = false;
                safe = false;
                combo = "NNN";
                prob = probs[7];
                break;
            default:
                hot = true;
                noisy = true;
                safe = true;
                combo = "DEF";
                prob = 0;
                break;
        }
        if (hot == true)
        {
            isHot.text = "true";
        }
        else
        {
            isHot.text = "false";
        }
        if (noisy == true)
        {
            isNoisy.text = "true";
        }
        else
        {
            isNoisy.text = "false";
        }
        if (safe == true)
        {
            isSafe.text = "true";
        }
        else
        {
            isSafe.text = "false";
        }
        ProbNum.text = rand.ToString();
        DoorCheck.text = combo;
        KeyCheck.text = key.ToString();
        LevelCount.text = doorCount.ToString();


    }
}
