using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class dragging : MonoBehaviour
{

    public float DoubleClickSecond = 0.25f;
    private bool OneClick = false;
    private double Timer = 0;



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
            try
            {
                selectedObject.GetComponent<outline>().OnEnable();
            }
            catch (Exception)
            {

            }
            if (selectedObject.transform.parent.tag == "body")
            {
                Debug.Log("body");
                gameObject.GetComponent<ObjectGenerator>().userPoint(selectedObject.transform);
                GameObject.Find("Simulator").GetComponent<Analyser>().select(selectedObject);


            }
            if (selectedObject.transform.parent.tag == "force")
            {
                Debug.Log("force");

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
        if (selectedObject != null)
        {
            try
            {
                selectedObject.GetComponent<outline>().OnDisable();
            }
            catch (Exception)
            {

            }
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            try
            {
                gameObject.transform.GetChild(i).GetChild(0).GetComponent<outline>().OnDisable();
            }
            catch(Exception)
            {

            }
            
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
                    Debug.Log("Object is selected.");
                    Vector3 parentPos = hit.transform.parent.transform.position;
                    offset = new Vector2(parentPos.x, parentPos.y) - ray;
                    if (multi)
                    {
                        select(hit.transform.gameObject);
                    }
                    else
                    {

                        select(hit.transform.gameObject);
                    Debug.Log(selectedObject.transform.rotation.z);
                        if (OneClick && (((double)System.DateTime.Now.Ticks / 10000000 - Timer) > DoubleClickSecond))
                        {
                            OneClick = false;
                        }
                        if (!OneClick)
                        {
                            Timer = (double)System.DateTime.Now.Ticks / 10000000;

                            OneClick = true;
                        }
                        else if (OneClick && (((double)System.DateTime.Now.Ticks /10000000 - Timer) < DoubleClickSecond))
                        {
                            OneClick = false;
                            if (selectedObject.transform.parent.tag == "body")
                            {
                                panelObj.GetComponent<panel>().selectionChange(selectedObject);
                            }
                            if (selectedObject.transform.parent.tag == "force")
                            {
                                forcePanelObj.GetComponent<panel>().selectionChange(selectedObject);
                            }
                        }
                    }

                }
                else
                {
                    // void is hit!
                    selected = false;
                    if (selectedObject != null)
                    {
                        try
                        {
                            selectedObject.GetComponent<outline>().OnDisable();
                        }
                        catch (Exception)
                        {

                        }
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
