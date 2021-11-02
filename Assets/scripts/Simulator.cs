using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Simulator : MonoBehaviour
{
    public GameObject objectGenerator, panel, playBtn;
    public Sprite playBtnImg, pauseBtnImg;
    private bool active=false;


    public void play() {
        if (!active) {
            for (int i = 0; i < objectGenerator.transform.childCount; i++)
            {
                Transform Children = objectGenerator.transform.GetChild(i);
                Children.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            active = true;
            objectGenerator.GetComponent<ObjectGenerator>().deactivate();

            playBtn.GetComponent<Image>().sprite = pauseBtnImg;
            playBtn.GetComponent<Button>().onClick.RemoveListener(play);
            playBtn.GetComponent<Button>().onClick.AddListener(pause);

        }
    }

    public void pause()
    {
        if (active)
        {
            for (int i = 0; i < objectGenerator.transform.childCount; i++)
            {
                Transform Children = objectGenerator.transform.GetChild(i);
                Children.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            active = false;
            objectGenerator.GetComponent<ObjectGenerator>().activate();

            playBtn.GetComponent<Image>().sprite = playBtnImg;
            playBtn.GetComponent<Button>().onClick.RemoveListener(pause);
            playBtn.GetComponent<Button>().onClick.AddListener(play);
        }
    }
}
