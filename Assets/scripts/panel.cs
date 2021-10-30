using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel : MonoBehaviour
{
    private GameObject nameInput, massInput, selectedObject;
    void Start()
    {
        nameInput = GameObject.Find("nameInput");
        massInput = GameObject.Find("massInput");


    }

    public void selectionChange(GameObject obj)
    {
        selectedObject = obj;
        float mass = selectedObject.GetComponent<Rigidbody2D>().mass;
        massInput.GetComponent<InputField>().text = mass.ToString();

    }

    public void massChanged()
    {
        float mass;
        float.TryParse(massInput.GetComponent<InputField>().text, out mass);
        if(mass==0)mass=1;
        selectedObject.GetComponent<Rigidbody2D>().mass = mass;
    }

    public void hide(){
        gameObject.SetActive(false);
    }

    public void show(){
        gameObject.SetActive(true);
    }
}
