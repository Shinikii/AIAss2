using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//Bill Ko 100590491
public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Label;  //door label
    public Door target; //door obj
    public ParticleSystem Fire; //particles
    public ParticleSystem Noise;
    private SpriteRenderer spriteRenderer;  //sprite renderer used wen trying to get animation
    private Sprite[] sprites;
    public bool isSafe;     //these were used for debug
    public bool isHot;
    public bool isNoisy;
    public bool isOpen = false;
    public string doorText;

    public Door(bool hot, bool noisy, bool safe)
    {
        isSafe = safe;
        isHot = hot;
        isNoisy = noisy;
        doorText = "YYY";
        
    }

    public void setSafe(bool val)
    {
        isSafe = val;
        target.isSafe = val;
    }

    public bool getSafe()
    {
        return isSafe;
    }

    public void setHot(bool val)
    {
        isHot = val;
        target.isHot = val;
    }

    public bool getHot()
    {
        return isHot;
    }

    public void setNoisy(bool val)
    {
        isNoisy = val;
        target.isNoisy = val;
    }

    public bool getNoisy()
    {
        return isNoisy;
    }

    public void setText(string val)
    {
        doorText = val;
        Label.text = val;
    }

    public string getText()
    {
        return doorText;
    }

    public void setOpen(bool val)
    {
        isOpen = val;
        target.isOpen = val;
        Debug.Log("test");
        target.ChangeSprite();
    }

    public bool getOpen()
    {
        return isOpen;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        sprites = Resources.LoadAll<Sprite>("doorsprite");
    }

    void Update()
    {
        if (isHot && !Fire.isPlaying)
        {
            Fire.Play();
        }
        else if (!isHot && Fire.isPlaying)
        {
            Fire.Stop();
            Fire.Clear();
        }
        if (isNoisy && !Noise.isPlaying)
        {
            Noise.Play();
        }
        else if (!isNoisy && Noise.isPlaying)
        {
            Noise.Stop();
            Noise.Clear();
        }
    }

    void ChangeSprite()
    {
        Debug.Log("did not break");
    }

    void reset()
    {
        Fire.Stop();
        Noise.Stop();
    }
}

//Assets/bbbb.txt