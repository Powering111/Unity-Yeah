using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userproperty : MonoBehaviour
{
    public float m_DoubleClickSecond = 0.25f;
    private bool m_IsOneClick = false;
    private double m_Timer = 0;
    public GameObject panel;
    public GameObject CreatedObject;
    public InputField_mass;
    public InputField_angle;
    public InputField_width;
    public InputField_height;
    public InputField_rotate;
    public GameObject_cancel;
    Ray ray = Camera.main.ScreenPointTo.Ray(Input.mousePosition);
    RaycastHit hit;



    void Update()
    {
        panel.SetActive(false);
        if (Physics.Raycast(ray, out hit))
        {
            if (m_IsOneClick && ((Time.time - m_Timer) > m_DoubleClickSecond))
            {
                m_IsOneClick = false;
            }

            if (hit.transform.gameObject.tag == "CreatedObject")
            {
                if (!m_IsOneClick)
                {
                    m_Timer = Time.time; m_IsOneClick = true;
                }
                else if (m_IsOneClick && ((Time.time - m_Timer) < m_DoubleClickSecond))
                {
                    m_IsOneClick = false;
                    panel.SetActive(true);
                    Instantiate(panel, new Vector3(-8, 11, 0), Quaternion.identity);





                }
            }
        }
        void execution()
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "InputField_width"|| " InputField_height")
                    size();
                else if (hit.transform.gameObject.tag == " InputField_mass")
                    mass();
                else if (hit.transform.gameObject.tag == "InputField_rotate")
                    rotate();
                else if (hit.transform.gameObject.tag == "InputField_angle")
                    angle();




            }
        }

        void width()
        { private float width;
            float.TryParse(widthInput.GetComponent<InputField>().text, out width);
    private float height = transform.localScale.y;
    CreatedObject.transform.localScale = new Vector3(width, height, 0);




}
void height()
{
    private float height;
float.TryParse(heightInput.GetComponent<InputField>().text, out height);
private float width = transform.localScale.x;
CreatedObject.transform.localScale = new Vector3(width, height, 0);

}

void mass()
{
   private float mass;
    float.TryParse(massInput.GetComponent<InputField>().text, out mass);
    CreatedObject.GetComponent<Rigidbody2D>().mass = mass;
}
        

        void rotate()
{
        private float rotate = inputField_rotate.text;

CreatedObject.transform.Rotate(0, 0, rotate); //입력 받은 각도 값을 호도법으로 변환 필요
   
}
        void angle()
{
        private float angle = inputField_angle.text * Mathf.PI / 180;
private float width = transform.localScale.x;
private float height = width * tan(angle);
CreatedObject.transform.localScale = new Vector3(width, height, 0);

       
        
        
        
}
    }
}
