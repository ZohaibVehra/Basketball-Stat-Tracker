using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatButton : MonoBehaviour
{
    public GameManager Manager;
    public int stat;
    public string statstr;
    public bool clicked;
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        clicked = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        if (Manager.highlighter.stat == stat)
        {
            Manager.highlighter.stat = 0;
            Manager.highlighter.statstr = "";
        }
        else
        {
            Manager.highlighter.stat = stat;
            Manager.highlighter.statstr = statstr;
        }
            

    }

}
