using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//Bill Ko 100590491
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{


    public float playerSpeed = 50f;
    public Canvas Units;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //input axis
        GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;                                //multiplied by speed to get movement
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Debug.Log("trigger hit");
        if(Input.GetKey(KeyCode.F))                                                                          //press F to open door
        {
            if (col.transform.parent.gameObject.tag == "Door")                                              //sends message to Door to open (doesn't work rn)
            {
                Debug.Log("test");
                col.transform.parent.gameObject.SendMessage("setOpen", true);
            }
        }
    }
}
