using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
// PlayerScript requires the GameObject to have a Rigidbody2D component

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{


    public float playerSpeed = 50f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;

        /*if (Input.GetKeyDown(KeyCode.F))
        { 
            if (safe == true)
            {
                doorCount++;
                LevelCount.text = doorCount.ToString();
            }
            else
            {
                Debug.Log("Failed, restarting");
                InitializeGame();
                LevelCount.text = doorCount.ToString();
            }
        }*/
    }
}
