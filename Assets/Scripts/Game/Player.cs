using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int team;
    public int points;
    public int rebounds;
    public int assists;
    public int blocks;
    public int steals;
    public int threes;
    public int misses;
    public int clutchbuckets;
    public int clutchmisses; 
    public int buckets;
    public int turnovers;
    public int fouls; 
    public int threemissed;
    public string playername;
    

    public Player(string name)
    {
        playername = name;
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
