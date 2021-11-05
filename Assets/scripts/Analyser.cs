using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Analyser : MonoBehaviour
{

    private Vector3 lastVelocity;
    private GameObject selectedObject;
    public Text equation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void select(GameObject obj)
    {
        this.selectedObject = obj;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity=selectedObject.GetComponent<Rigidbody2D>().velocity;
        Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;
        float mass = selectedObject.GetComponent<Rigidbody2D>().mass;
        lastVelocity = velocity;
        equation.text = $"F = {mass} × ({acceleration.x}î + {acceleration.y}ĵ)";
    }
}
