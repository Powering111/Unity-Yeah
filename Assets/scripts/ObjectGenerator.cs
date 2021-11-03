using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject RectangleObject, CircleObject, SlopeObject, StringObject, ForceObject;
    private GameObject selected;
    private bool active = true;

    Vector3 startPos = new Vector3(0,0,0);
    public void addRectangleObj()
    {
        if (active)
        {
            GameObject obj = Instantiate(RectangleObject, startPos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
            obj.name = "Rect";

            obj.transform.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    public void addCircleObj()
    {
        if (active)
        {
            GameObject obj = Instantiate(CircleObject, startPos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
            obj.name = "Circle";

            obj.transform.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    public void addSlopeObj()
    {
        if (active)
        {
            GameObject obj = Instantiate(SlopeObject, startPos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
            obj.name = "Slope";

            obj.transform.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }


    private int stringAddingState = 0;
    private int forceAddingState = 0;
    private Transform stringStartPoint,stringEndPoint;
    public void addForceObj()
    {
        if (active)
        {
            forceAddingState = 1;
        }
    }

    public void addStringObj()
    {
        if (active)
        {
            stringAddingState = 1;
        }
    }
    public void userPoint(Transform point)
    {
        if (forceAddingState == 1)
        {
            GameObject obj = Instantiate(ForceObject, startPos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
            obj.GetComponent<force>().setTarget(point);
            forceAddingState = 0;
        }
        if (stringAddingState == 1)
        {
            stringAddingState++;
            stringStartPoint = point;
        }
        else if (stringAddingState == 2)
        {
            stringEndPoint = point;

            GameObject obj = Instantiate(StringObject, startPos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
            obj.GetComponent<Rope>().StartPoint = stringStartPoint;
            obj.GetComponent<Rope>().EndPoint = stringEndPoint;

            obj.name = "Rope";

            stringAddingState=0;
        }
    }

    public void Deactivate()
    {
        this.active = false;

    }
    public void Activate()
    {
        this.active = true;
    }
}
