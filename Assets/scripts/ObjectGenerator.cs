using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject RectangleObject, CircleObject, SlopeObject, StringObject;
    private GameObject selected;
    private bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 startPos = new Vector3(0,0,0);
    public void addRectangleObj()
    {
        if (active)
        {
            GameObject obj = Instantiate(RectangleObject, startPos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
        }
    }
    public void addCircleObj()
    {
        if (active)
        {
            GameObject obj = Instantiate(CircleObject, startPos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
        }
    }
    public void addSlopeObj()
    {
        if (active)
        {
            GameObject obj = Instantiate(SlopeObject, startPos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
        }
    }
    private int stringAddingState = 0;
    private Transform stringStartPoint,stringEndPoint;

    public void addStringObj()
    {
        if (active)
        {
            stringAddingState = 1;
            

        }
    }
    public void userPoint(Transform point)
    {
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
            
            stringAddingState=0;
        }
    }

    public void play()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform Children = gameObject.transform.GetChild(i);
            Children.gameObject.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
        }
        this.active = false;
    }
    public void stop()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform Children = gameObject.transform.GetChild(i);
            Children.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        this.active = true;
    }
}
