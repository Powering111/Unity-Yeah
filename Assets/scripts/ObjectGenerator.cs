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

    public void addRectangleObj()
    {
        if (active)
        {
            Resolution resolution = Screen.resolutions[0];
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(resolution.width, resolution.height, 0));
            pos.z = 0;
            GameObject obj = Instantiate(RectangleObject, pos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
        }
    }
    public void addCircleObj()
    {
        if (active)
        {
            Resolution resolution = Screen.resolutions[0];
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(resolution.width, resolution.height, 0));
            pos.z = 0;
            GameObject obj = Instantiate(CircleObject, pos, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
        }
    }
    public void addSlopeObj()
    {
        if (active)
        {
            Resolution resolution = Screen.resolutions[0];
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(resolution.width, resolution.height, 0));
            pos.z = 0;
            GameObject obj = Instantiate(SlopeObject, pos, Quaternion.identity);
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

            Resolution resolution = Screen.resolutions[0];
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(resolution.width, resolution.height, 0));

            pos.z = 0;
            GameObject obj = Instantiate(StringObject, pos, Quaternion.identity);
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
    }
}
