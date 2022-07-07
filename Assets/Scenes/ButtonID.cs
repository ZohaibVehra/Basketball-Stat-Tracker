using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonID : MonoBehaviour
{
    // Start is called before the first frame update
    public int buttonid;
    public GameManager Manager;
    public bool set = true;
 
    void Start()
    {
       Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        int myteam = 0;
        if (transform.parent.name == "T1")
            myteam = 1;
        else
            myteam = 2;
        if (myteam == 1)
        {
            if (Manager.highlighter.team == myteam && Manager.highlighter.index == buttonid)
            {
                Manager.highlighter.team = 0;
                Manager.highlighter.index = 0;
                set = false;
            }
        }
        if (myteam == 2)
        {
            if (Manager.highlighter.team == myteam && Manager.highlighter.index == buttonid - Manager.Master.GetComponent<Master>().PlayerNums)
            {
                Manager.highlighter.team = 0;
                Manager.highlighter.index = 0;
                set = false;
            }
        }

        if (set)
        {
            if (myteam == 1)
            {
                Manager.highlighter.team = 1;
                Manager.highlighter.index = buttonid;
            }
            if (myteam == 2)
            {
                Manager.highlighter.team = 2;
                Manager.highlighter.index = buttonid - Manager.Master.GetComponent<Master>().PlayerNums;
            }
        }

        set = true;

    }

}
