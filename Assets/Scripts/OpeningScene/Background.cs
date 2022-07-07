using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Background : MonoBehaviour
{
    public Sprite a;
    public Sprite b;
    public Sprite c;
    public Sprite d;
    public Sprite aa;
    public Sprite bb;
    public Sprite cc;
    public Sprite dd;
    public Sprite aaa;
    public Sprite bbb;

    public Color colour;
    public int Counter;


    // Start is called before the first frame update
    void Start()
    {
        InitializeBackground();




        Application.targetFrameRate = 20;
        colour = this.GetComponent<SpriteRenderer>().color;
        colour.a = 1f;
        this.GetComponent<SpriteRenderer>().color = colour;
        Counter = 15;

    }

    // Update is called once per frame
    void Update()
    {
        RotateWallaper();

    }

    void RotateWallaper()
    {
        //show 5 sec, 0.7 sec in and out. 
        if (Counter > 0 && Counter <= 14)
        {
            colour.a += 0.0714f;
        }
        else if (Counter > 115 && Counter <= 129)
        {
            colour.a -= 0.0714f;
        }
        else if (Counter > 130)
        {




            Counter = 0;
            setToRandom();
        }

        this.GetComponent<SpriteRenderer>().color = colour;
        Counter++;
    }

    public void setToRandom()
    {
        int current = 0;
        int next = 0;

        if (this.GetComponent<SpriteRenderer>().sprite == a)
            current = 1;
        else if (this.GetComponent<SpriteRenderer>().sprite == b)
            current = 2;
        else if (this.GetComponent<SpriteRenderer>().sprite == c)
            current = 3;
        else if (this.GetComponent<SpriteRenderer>().sprite == d)
            current = 4;
        else if (this.GetComponent<SpriteRenderer>().sprite == aa)
            current = 5;
        else if (this.GetComponent<SpriteRenderer>().sprite == bb)
            current = 6;
        else if (this.GetComponent<SpriteRenderer>().sprite == cc)
            current = 7;
        else if (this.GetComponent<SpriteRenderer>().sprite == dd)
            current = 8;
        else if (this.GetComponent<SpriteRenderer>().sprite == aaa)
            current = 9;
        else if (this.GetComponent<SpriteRenderer>().sprite == bbb)
            current = 10;

        next = current;
        while (next == current)
        {
            next = Random.Range(1, 11);
        }
        if (next == 1)
            this.GetComponent<SpriteRenderer>().sprite = a;
        else if (next == 2)
            this.GetComponent<SpriteRenderer>().sprite = b;
        else if (next == 3)
            this.GetComponent<SpriteRenderer>().sprite = c;
        else if (next == 4)
            this.GetComponent<SpriteRenderer>().sprite = d;
        else if (next == 5)
            this.GetComponent<SpriteRenderer>().sprite = aa;
        else if (next == 6)
            this.GetComponent<SpriteRenderer>().sprite = bb;
        else if (next == 7)
            this.GetComponent<SpriteRenderer>().sprite = cc;
        else if (next == 8)
            this.GetComponent<SpriteRenderer>().sprite =dd;
        else if (next == 9)
            this.GetComponent<SpriteRenderer>().sprite =aaa;
        else if (next == 10)
            this.GetComponent<SpriteRenderer>().sprite = bbb;

        return;
    }
    public void InitializeBackground()
    {
        int next = Random.Range(1, 11);
        if (next == 1)
            this.GetComponent<SpriteRenderer>().sprite = a;
        else if (next == 2)
            this.GetComponent<SpriteRenderer>().sprite = b;
        else if (next == 3)
            this.GetComponent<SpriteRenderer>().sprite = c;
        else if (next == 4)
            this.GetComponent<SpriteRenderer>().sprite = d;
        else if (next == 5)
            this.GetComponent<SpriteRenderer>().sprite = aa;
        else if (next == 6)
            this.GetComponent<SpriteRenderer>().sprite = bb;
        else if (next == 7)
            this.GetComponent<SpriteRenderer>().sprite = cc;
        else if (next == 8)
            this.GetComponent<SpriteRenderer>().sprite = dd;
        else if (next == 9)
            this.GetComponent<SpriteRenderer>().sprite = aaa;
        else if (next == 10)
            this.GetComponent<SpriteRenderer>().sprite = bbb;
        return;
    }
    

}
