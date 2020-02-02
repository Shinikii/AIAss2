using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
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
    }

    public bool getSafe()
    {
        return isSafe;
    }

    public void setHot(bool val)
    {
        isHot = val;
    }

    public bool getHot()
    {
        return isHot;
    }

    public void setNoisy(bool val)
    {
        isNoisy = val;
    }

    public bool getNoisy()
    {
        return isNoisy;
    }

    public void setText(string val)
    {
        doorText = val;
    }

    public string getText()
    {
        return doorText;
    }

    public void setOpen(bool val)
    {
        isOpen = val;
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

    }
}
