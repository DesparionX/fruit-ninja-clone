using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hovering : MonoBehaviour
{
    
    public void HoverOff()
    {
        GetComponentInChildren<Outline>().enabled = false;
    }
    public void HoverOn()
    {
        GetComponentInChildren<Outline>().enabled = true;
    }
}
