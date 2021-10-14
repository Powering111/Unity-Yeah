using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject RectangleObject, CircleObject, SlopeObject, StringObject;
    private GameObject selected;
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
        Resolution resolution = Screen.resolutions[0];
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(resolution.width,resolution.height,0));
        pos.z = 0;
        GameObject obj = Instantiate(RectangleObject, pos ,Quaternion.identity);
        obj.transform.parent = gameObject.transform;
    
    }
    public void addCircleObj()
    {
        Resolution resolution = Screen.resolutions[0];
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(resolution.width,resolution.height,0));
        pos.z = 0;
        GameObject obj = Instantiate(CircleObject, pos ,Quaternion.identity);
        obj.transform.parent = gameObject.transform;
    
    }
    public void addSlopeObj()
    {
        Resolution resolution = Screen.resolutions[0];
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(resolution.width,resolution.height,0));
        pos.z = 0;
        GameObject obj = Instantiate(SlopeObject, pos ,Quaternion.identity);
        obj.transform.parent = gameObject.transform;
    
    }
    public void addStringObj()
    {
        Resolution resolution = Screen.resolutions[0];
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(resolution.width,resolution.height,0));
        pos.z = 0;
        GameObject obj = Instantiate(StringObject, pos ,Quaternion.identity);
        obj.transform.parent = gameObject.transform;
    
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
