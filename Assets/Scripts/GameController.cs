using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//Bill Ko 100590491
public class GameController : MonoBehaviour
{

    public Door curDoor;    //current door
    List<Door> Doors = new List<Door>();    //list of doors
    public Text isHot;  //for debugging traits
    public Text isNoisy;
    public Text isSafe;
    public Text ProbNum;
    public Text DoorCheck;
    public Text KeyCheck;
    public Text LevelCount;
    public InputField input;    //filepath input field

    public Canvas Units;        //list of doors

    string filepath = "Assets/aaaa.txt";
    double prob;
    bool safe = true;       //traits
    bool hot = true;
    bool noisy = true;
    string combo;           //YYN traits
    List<double> probs = new List<double>();    //list of file-read data

    // Use this for initialization
    void Start()
    {
        InitializeGame(); //loads probability file and rolls door probabilities
    }

    // Update is called once per frame
    void Update()
    {
        // Hitting the spacebar always restarts the game
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            InitializeGame();
        }
    }

    private void InitializeGame()
    {
        BroadcastMessage("reset");
        Doors.Clear();
        probs.Clear();
        string path = filepath; //reads filepath

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] words = line.Split('\t');  //reads data from file, separating by tab

            foreach (var word in words)
            {
                //Debug.Log(word);
                double temp;
                var isNumeric = double.TryParse(word, out temp);
                if (isNumeric == true)
                {
                    probs.Add(temp);        //save probabilities into a list
                }
            }

        }

        foreach (var num in probs)
        {
            Debug.Log(num);
        }
        reader.Close();

        for (int i = 0; i < 20; i++)
        {
            rollDoor(i); //rolls door properties one at a time
        }
    }

    private void rollDoor(int index)
    {
        int rand = Random.Range(1, 100);    //roll a number from 1 to 100
        int buffer = 0;
        int oldbuffer;
        int key = 0;

        for (int i = 0; i < 8; i++)         //looping for each of the door combo possibilities
        {
            int tempNum = (int)(probs[i] * 100);
            oldbuffer = buffer;
            buffer += tempNum;
            if (oldbuffer < rand && rand <= buffer) //if rolled number is within the current proability bracket
            {
                key = i + 1;                         //assign door traits using switch key below
            }
           // Debug.Log(oldbuffer);
           // Debug.Log(", ");
           // Debug.Log(buffer);
        }
        switch (key)                                    //depending on rolled bracket, door attribute cases here
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
        Units.GetComponentsInChildren<Door>()[index].setText(combo);    //assign traits to Door object
        Units.GetComponentsInChildren<Door>()[index].setHot(hot);
        Units.GetComponentsInChildren<Door>()[index].setNoisy(noisy);
        Units.GetComponentsInChildren<Door>()[index].setSafe(safe);
    }

    private void reload(string newpath)             //reload game using new filepath
    {
        filepath = newpath;
        InitializeGame();
    }
}
