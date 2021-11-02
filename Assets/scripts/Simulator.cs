using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Simulator : MonoBehaviour
{
    public GameObject objectGenerator, Panel, playBtn;
    public Sprite playBtnImg, pauseBtnImg;
    private bool active=false;

    public void toggle()
    {
        if (!active)
        {
            play();
        }
        else
        {
            pause();
        }
    }

    public void play() {
        if (!active) {
            for (int i = 0; i < objectGenerator.transform.childCount; i++)
            {
                Transform Children = objectGenerator.transform.GetChild(i).GetChild(0);
                
                Rigidbody2D rd = Children.gameObject.GetComponent<Rigidbody2D>();
                if (rd != null)
                { 
                    rd.bodyType = RigidbodyType2D.Dynamic; 
                }
                else
                {
                    Rope rope = Children.gameObject.GetComponent<Rope>();
                    if(rope != null)
                    {
                        rope.Activate();
                    }
                }
            }
            active = true;
            objectGenerator.GetComponent<ObjectGenerator>().Deactivate();
            objectGenerator.GetComponent<dragging>().Deactivate();

            playBtn.GetComponent<Image>().sprite = pauseBtnImg;
            playBtn.GetComponent<Button>().onClick.RemoveListener(play);
            playBtn.GetComponent<Button>().onClick.AddListener(pause);

            Panel.GetComponent<panel>().Deactivate();
        }
    }

    public void pause()
    {
        if (active)
        {
            for (int i = 0; i < objectGenerator.transform.childCount; i++)
            {
                Transform Children = objectGenerator.transform.GetChild(i).GetChild(0);
                Rigidbody2D rd = Children.gameObject.GetComponent<Rigidbody2D>();
                if (rd != null)
                {
                    rd.bodyType = RigidbodyType2D.Static;
                }
                else
                {
                    Rope rope = Children.gameObject.GetComponent<Rope>();
                    if (rope != null)
                    {
                        rope.Deactivate();
                    }
                }
            }
            active = false;
            objectGenerator.GetComponent<ObjectGenerator>().Activate();
            objectGenerator.GetComponent<dragging>().Activate();

            playBtn.GetComponent<Image>().sprite = playBtnImg;
            playBtn.GetComponent<Button>().onClick.RemoveListener(pause);
            playBtn.GetComponent<Button>().onClick.AddListener(play);

            Panel.GetComponent<panel>().Activate();
        }
    }
}
