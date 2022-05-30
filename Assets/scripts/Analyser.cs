using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Analyser : MonoBehaviour
{

    private GameObject selectedObject;
    public Text equation;
    List<GameObject> objectList;
    private Vector3 lastVelocity;
    private Vector3 lastPosition;
    private double recordTime;
    public GameObject recordBtn;
    public Sprite recordOn, recordOff;
    public bool multi = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
        if (selectedObject != null)
        {
            if (!multi)
            {
                Vector3 velocity = selectedObject.GetComponent<Rigidbody2D>().velocity;
                Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;
                float mass = selectedObject.GetComponent<Rigidbody2D>().mass;
                lastVelocity = velocity;

                Vector3 force = mass * acceleration;
                equation.text = string.Format("F = {0:0.0000} × ( {1} {2:0.0000}i {3} {4:0.0000}j) = {5} {6:0.0000}i {7} {8:0.0000}j"
                    , mass
                    , (acceleration.x >= 0) ? '+' : '-'
                    , Mathf.Abs(acceleration.x)
                    , (acceleration.y >= 0) ? '+' : '-'
                    , Mathf.Abs(acceleration.y)
                    , (force.x >= 0) ? '+' : '-'
                    , Mathf.Abs(force.x)
                    , (force.y >= 0) ? '+' : '-'
                    , Mathf.Abs(force.y)
                );
                if (recording)
                {
                    recordTime += Time.deltaTime;
                    sw.Write(recordTime+", "+selectedObject.transform.position.x+", "+selectedObject.transform.position.y+", , "+velocity.x+", "+velocity.y+", , "+acceleration.x+", "+acceleration.y+" \n");
                    Debug.Log(":YEAH");
                }
            }
            else
            {
                float mass = 0;

                Vector3 com = new Vector3(0, 0, 0);

                Debug.Log("ACCUMULATING -----------------");
                for (int i = 0; i < objectList.Count; i++)
                {
                    float nowMass = objectList[i].GetComponent<Rigidbody2D>().mass;
                    mass += nowMass;
                    Vector2 CenterOfMass = objectList[i].transform.position;
                    com += new Vector3(CenterOfMass.x, CenterOfMass.y) * nowMass;

                    Debug.Log(com);
                }
                com /= mass;
                Debug.Log("ACCUMULATING ---------FINISHED");

                Vector3 velocity = (com - lastPosition) / Time.deltaTime;
                Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;

                Vector3 force = mass * acceleration;
                equation.text = string.Format("F = {0:0.0000} × ( {1} {2:0.0000}i {3} {4:0.0000}j) = {5} {6:0.0000}i {7} {8:0.0000}j"
                    , mass
                    , (acceleration.x >= 0) ? '+' : '-'
                    , Mathf.Abs(acceleration.x)
                    , (acceleration.y >= 0) ? '+' : '-'
                    , Mathf.Abs(acceleration.y)
                    , (force.x >= 0) ? '+' : '-'
                    , Mathf.Abs(force.x)
                    , (force.y >= 0) ? '+' : '-'
                    , Mathf.Abs(force.y)
                );

                lastVelocity = velocity;
                lastPosition = com;

                gameObject.transform.GetChild(0).GetComponent<arrow>().setPosition(com);
                gameObject.transform.GetChild(0).GetComponent<arrow>().setRotation(velocity);

            }
        }

    }

    public void setMulti()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.objectList = new List<GameObject>();
        multi = true;
    }
    public void unsetMulti()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("unsetting Multi ( analyser )");
        multi = false;
    }


    StreamWriter sw;
    bool recording = false;

    public void record()
    {
        if (!recording) {
            sw = new StreamWriter(System.DateTime.Now.ToString("yy-MM-dd-HH-mm-ss") + ".csv");
            sw.Write("time, position, , , velocity, , ,acceleration, , \n, x, y, s, x, y, s, x, y, s, \n");
            recordBtn.GetComponent<Image>().sprite = recordOn;
            recordBtn.GetComponent<Button>().onClick.RemoveListener(record);
            recordBtn.GetComponent<Button>().onClick.AddListener(stop);
            recording = true;
        }
    }
    public void stop()
    {
        if (recording)
        {
            recordBtn.GetComponent<Image>().sprite = recordOff;
            recordBtn.GetComponent<Button>().onClick.RemoveListener(stop);
            recordBtn.GetComponent<Button>().onClick.AddListener(record);
            sw.Close();
            recording = false;
        }
    }
}
