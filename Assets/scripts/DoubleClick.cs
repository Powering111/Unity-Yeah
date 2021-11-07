using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{

    void Update()
    {
    public float DoubleClickSecond = 0.25f;
    private bool OneClick = false;
    private double Timer = 0; 

    if(OneClick && ((Time.time - Timer) > DoubleClickSecond)) 
        { 
        OneClick = false; 
        }

    if (selectedObject.transform.parent.tag == "body")
    {
        if (!OneClick)
        {
            Timer = Time.time; OneClick = true;
        }
        else if (OneClick && ((Time.time - Timer) < DoubleClickSecond))
        {
         OneClick = false;
        void()
        }
    }

    }
}
