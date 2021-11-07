using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Analyser : MonoBehaviour
{

    private GameObject selectedObject;
    public Text equation;
    List<GameObject> objectList;
    private Vector3 lastVelocity;
    private Vector3 lastPosition;

    public bool multi = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void select(GameObject obj)
    {
        if (!multi)
        {
            this.selectedObject = obj;
        }
        else
        {
            if (!this.objectList.Contains(obj))
            {
                this.objectList.Add(obj);
                Debug.Log(this.objectList.Count);
            }
        }
    }

    void FixedUpdate()
    { 
        if (!multi)
        {
            Vector3 velocity = selectedObject.GetComponent<Rigidbody2D>().velocity;
            Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;
            float mass = selectedObject.GetComponent<Rigidbody2D>().mass;
            lastVelocity = velocity;

            equation.text = string.Format("F = {0:0.0000} × ( {1} {2:0.0000}î {3} {4:0.0000}ĵ)"
            , mass
            , (acceleration.x >= 0) ? '+' : '-'
            , Mathf.Abs(acceleration.x)
            , (acceleration.y >= 0) ? '+' : '-'
            , Mathf.Abs(acceleration.y)
        );
        }
        else
        {
            float mass = 0;

            Vector3 com=new Vector3(0,0,0);

            Debug.Log("ACCUMULATING -----------------");
            for (int i = 0; i < objectList.Count; i++)
            {
                mass += objectList[i].GetComponent<Rigidbody2D>().mass;
                Vector2 CenterOfMass = objectList[i].transform.position;
                com += new Vector3(CenterOfMass.x, CenterOfMass.y);

                Debug.Log(com);
            }
            com /= objectList.Count;
            Debug.Log("ACCUMULATING ---------FINISHED");

            Vector3 velocity = (com - lastPosition) / Time.deltaTime;
            Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;

            equation.text = string.Format("F = {0:0.0000} × ( {1} {2:0.0000}î {3} {4:0.0000}ĵ)"
                , mass
                , (acceleration.x >= 0) ? '+' : '-'
                , Mathf.Abs(acceleration.x)
                , (acceleration.y >= 0) ? '+' : '-'
                , Mathf.Abs(acceleration.y)
            );

            lastVelocity = velocity;
            lastPosition = com;
        }
        


    }

    public void setMulti()
    {
        this.objectList = new List<GameObject>();
        multi = true;
    }
    public void unsetMulti()
    {
        Debug.Log("unsetting Multi ( analyser )");
        multi = false;
    }
}
