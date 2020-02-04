using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Bill Ko 100590491
public class inputScript : MonoBehaviour
{
    public GameObject Controller;
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();          //takes input field
        se.AddListener(SubmitName);                 
        input.onEndEdit = se;
    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        Controller.SendMessage("reload", arg0);         //sends message to gameController to reload game with new probabilities
    }
}
