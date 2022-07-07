using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{

    public int GameNum;
    public int PlayerNums;
    public List<string> Players;
    public bool onesandtwos = true;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
       if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json"))
        {
            string[] allLines = System.IO.File.ReadAllText(Application.persistentDataPath + "/GamesSaved.json").Split('\n');
            GameNum = allLines.Length - 1;
        }
        else
            GameNum = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGameNumtoNew()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json"))
        {
            string[] allLines = System.IO.File.ReadAllText(Application.persistentDataPath + "/GamesSaved.json").Split('\n');
            GameNum = allLines.Length-1;
        }
        else
            GameNum = 0;
    }
        

}
