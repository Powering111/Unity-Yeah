using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class dragging : MonoBehaviour
{
    private bool selected = false;
    private Vector2 offset;
    private GameObject selectedObject;

    private bool active = true;
    public GameObject panelObj;

    public void Activate()
    {
        active = true;
    }
    public void Deactivate()
    {
        active = false;
    }

    public void select(GameObject selection)
    {

        selectedObject = selection;
        
        selectedObject.GetComponent<outline>().OnEnable();

        gameObject.GetComponent<ObjectGenerator>().userPoint(selectedObject.transform);

        panelObj.GetComponent<panel>().selectionChange(selectedObject);

        this.selected = true;

    }

    public void deselect()
    {
        if (selectedObject != null)
        {
            selectedObject.GetComponent<outline>().OnDisable();
            panelObj.GetComponent<panel>().deselect();
        }

        selected = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // mouse is clicked.
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit= Physics2D.Raycast(ray, Vector2.zero);
            if (hit.collider!=null)
            {

                // object is hit!
                if (selectedObject != null && !selectedObject.Equals(hit.transform.gameObject))
                {    
                    selectedObject.GetComponent<outline>().OnDisable();
                }
                select(hit.transform.gameObject);
                offset = new Vector2(hit.transform.position.x, hit.transform.position.y) - ray;

            }
            else
            {
                // UI is hit!
                if (EventSystem.current.IsPointerOverGameObject())
                {
                }
                else
                {
                    // void is hit!

                    selected = false;
                    if (selectedObject != null)
                    {
                        selectedObject.GetComponent<outline>().OnDisable();
                    }
                    deselect();
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
            if (selected && active)
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
