using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKey : MonoBehaviour
{
    private Simulator simulator;
    public dragging dragger;
    public delete deleter;
    public ObjectGenerator generator;
    void Start()
    {
        simulator = gameObject.GetComponent<Simulator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            simulator.toggle();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dragger.unsetMulti();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            deleter.toggle();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            generator.addForceObj();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            dragger.setMulti();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            generator.addRectangleObj();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            generator.addCircleObj();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            generator.addSlopeObj();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            generator.addStringObj();
        }
    }
}
