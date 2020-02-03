using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Label;
    public Door target;
    public ParticleSystem Fire;
    public ParticleSystem Noise;
    public bool isSafe;
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
    }

    public bool getOpen()
    {
        return isOpen;
    }

    void Start()
    {

    }

    void Update()
    {
        if (isHot && !Fire.isPlaying)
        {
            Fire.Play();
        }
        if (isNoisy && !Noise.isPlaying)
        {
            Noise.Play();
        }
    }
}
