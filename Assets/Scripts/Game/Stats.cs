using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int team;
    public int index;
    public int stat;
    public string lastplay;

    public Stats(int a, int b, int c, string d)
    {
        team = a;
        index = b;
        stat = c;
        lastplay = d;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
