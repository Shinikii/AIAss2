using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSafe;
    public bool isHot;
    public bool isNoisy;

    void setSafe(bool val)
    {
        isSafe = val;
    }

    bool getSafe()
    {
        return isSafe;
    }

    void setHot(bool val)
    {
        isHot = val;
    }

    bool getHot()
    {
        return isHot;
    }

    void setNoisy(bool val)
    {
        isNoisy = val;
    }

    bool getNoisy()
    {
        return isNoisy;
    }
}
