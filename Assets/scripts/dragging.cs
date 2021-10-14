using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dragging : MonoBehaviour
{
    private bool selected = false;
    private Vector2 offset;
    private GameObject selectedObject;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // mouse is clicked.
            Debug.Log("mouse down");
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit= Physics2D.Raycast(ray, Vector2.zero);
            if (hit.collider!=null)
            {

                // object is hit!
                if (selectedObject != null && !selectedObject.Equals(hit.transform.gameObject))
                {    
                    selectedObject.GetComponent<outline>().OnDisable();
                }
                selectedObject = hit.transform.gameObject;
                offset = new Vector2(hit.transform.position.x, hit.transform.position.y) - ray;
                selected = true;

                selectedObject.GetComponent<outline>().OnEnable();

                gameObject.GetComponent<ObjectGenerator>().userPoint(selectedObject.transform);
            }
            else
            {
                // void is hit!
                selected = false;
                if (selectedObject != null)
                {
                    selectedObject.GetComponent<outline>().OnDisable();
                }
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            // mouse up
            selected = false;
        }
        else if (selected && Input.GetMouseButton(0))
        {
            // mouse dragging...
            if (selected)
            {
                //object is selected
                // moving object to mouse position
                Vector2 mousePos = Input.mousePosition;
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                selectedObject.transform.position = worldPos + offset;

            }
        }
    }
}
