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
    public Canvas Units;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(Input.GetKey(KeyCode.F))
        {
            if (col.transform.parent.gameObject.tag == "Door")
            {
                col.transform.parent.gameObject.SendMessage("setOpen", true);
            }
        }
    }
}
