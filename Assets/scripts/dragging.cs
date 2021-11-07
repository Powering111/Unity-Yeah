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
    private bool multi = false;
    public GameObject panelObj, forcePanelObj, Simulator;

    public void Activate()
    {
        active = true;
    }
    public void Deactivate()
    {
        active = false;
    }

    public void setMulti()
    {
        Simulator.GetComponent<Analyser>().setMulti();

        multi = true;
    }
    public void unsetMulti()
    {
        Simulator.GetComponent<Analyser>().unsetMulti();
        multi = false;
    }

    public void select(GameObject selection)
    {
        if (!multi)
        {
            deselect();
            selectedObject = selection;

            selectedObject.GetComponent<outline>().OnEnable();
            if (selection.gameObject.transform.parent.tag == "body")
            {
                Debug.Log("body");
                gameObject.GetComponent<ObjectGenerator>().userPoint(selectedObject.transform);


                panelObj.GetComponent<panel>().selectionChange(selectedObject);
                GameObject.Find("Simulator").GetComponent<Analyser>().select(selectedObject);
            }
            if (selection.gameObject.transform.parent.tag == "force")
            {
                Debug.Log("force");

                forcePanelObj.GetComponent<panel>().selectionChange(selectedObject);
            }

            this.selected = true;
        }
        else
        {
            Debug.Log("selecting Multiple Object");
            hidePanel();
            this.selectedObject = selection;
            this.selected = true;
            if (selection.gameObject.transform.parent.tag == "body")
            {
                selectedObject.GetComponent<outline>().OnEnable();
                Simulator.GetComponent<Analyser>().select(selectedObject);

            }

        }

    }

    public void deselect()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetChild(0).GetComponent<outline>().OnDisable();
            
        }
        hidePanel();
        selected = false;
    }
    void hidePanel()
    {
        panelObj.GetComponent<panel>().deselect();
        forcePanelObj.GetComponent<panel>().deselect();


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit.collider != null)
            {
                hit.transform.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            // UI is hit!
            if (EventSystem.current.IsPointerOverGameObject())
            {
            }
            else {
                // mouse is clicked.
                Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

                if (hit.collider != null)
                {
                    // object is hit!
                    //Debug.Log("Object is selected.");
                    select(hit.transform.gameObject);
                    Vector3 parentPos = hit.transform.parent.transform.position;
                    offset = new Vector2(parentPos.x, parentPos.y) - ray;

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
                Vector2 mousePos = Input.mousePosition;
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                //object is selected
                if (selectedObject.transform.parent.tag == "force")
                {
                    // rotating force to mouse position
                    Vector3 forcePosition = selectedObject.transform.parent.transform.position;
                    Vector3 worldPos3 = worldPos;
                    worldPos3.z = 0;
                    selectedObject.transform.parent.GetComponent<force>().setRotation((worldPos3 - forcePosition));
                }
                else
                {
                    // moving object to mouse position
                    selectedObject.transform.parent.transform.position = worldPos + offset;
                }
            }
        }
    }
}
