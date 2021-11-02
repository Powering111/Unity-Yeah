using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel : MonoBehaviour
{
    private GameObject selectedObject;
    public GameObject nameInput, massInput;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void selectionChange(GameObject obj)
    {
        selectedObject = obj;
        float mass = selectedObject.GetComponent<Rigidbody2D>().mass;
        string name = selectedObject.name;
        massInput.GetComponent<InputField>().text = mass.ToString();
        nameInput.GetComponent<InputField>().text = name;

        gameObject.SetActive(true);
    }

    public void deselect()
    {
        selectedObject = null;
        gameObject.SetActive(false);
    }

    public void massChanged()
    {
        float mass;
        float.TryParse(massInput.GetComponent<InputField>().text, out mass);
        if(mass==0)mass=1;
        selectedObject.GetComponent<Rigidbody2D>().mass = mass;
    }

    public void nameChanged()
    {
        string name=nameInput.GetComponent<InputField>().text;
        if (name.Length > 0)
        {
            selectedObject.name = name;
        }
    }

    public void hide(){
        gameObject.SetActive(false);
    }

    public void show(){
        gameObject.SetActive(true);
    }
}
