using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StatsManager : MonoBehaviour
{
    public GameObject gamename;
    public GameObject gametime;
    public GameObject gamedate;

    public string path;
    public GameObject content;
    public GameObject statsPrefab;
    public string JsonString;
    public GameObject Master;

    public string t1;
    public string t2;
    public string t3;
    public string t4;

    public GameObject deleteCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        path = Application.persistentDataPath;
        Master = GameObject.Find("Master");

        if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json"))
        {
            string[] allLines = System.IO.File.ReadAllText(Application.persistentDataPath + "/GamesSaved.json").Split('\n');
            JsonString = allLines[Master.GetComponent<Master>().GameNum];
            CreatePlayersStats();
        }

       

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreatePlayersStats()
    {
        int playercount = 0;
        path = JsonString;
        SaveData x = JsonUtility.FromJson<SaveData>(JsonString);

        gamename.GetComponent<TextMeshProUGUI>().text = x.GameName;
        gamedate.GetComponent<TextMeshProUGUI>().text = x.GameDate;
        gametime.GetComponent<TextMeshProUGUI>().text = x.GameTime;


        if (x.P1team != 0)
        {
            GameObject go = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go.transform.parent = content.transform;

            go.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P1name;
            go.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P1fgs;
            go.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P1fgpercent;
            go.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P1threes;
            go.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P1threepercent;
            go.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text =""+ x.P1assists;
            go.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = ""+x.P1rebounds;
            go.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P1steals;
            go.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P1blocks;
            go.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P1fouls;
            go.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P1turnovers;
            go.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P1clutchpts;
            go.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P1clutchpercent;
            go.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P1points;
        }

        if (x.P2team != 0)
        {
            GameObject go2 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go2.transform.parent = content.transform;

            go2.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P2name;
            go2.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P2fgs;
            go2.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P2fgpercent;
            go2.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P2threes;
            go2.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P2threepercent;
            go2.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2assists;
            go2.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2rebounds;
            go2.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2steals;
            go2.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2blocks;
            go2.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2fouls;
            go2.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2turnovers;
            go2.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2clutchpts;
            go2.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2clutchpercent;
            go2.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P2points;
        }

        if (x.P3team != 0)
        {
            GameObject go3 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go3.transform.parent = content.transform;

            go3.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P3name;
            go3.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P3fgs;
            go3.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P3fgpercent;
            go3.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P3threes;
            go3.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P3threepercent;
            go3.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3assists;
            go3.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3rebounds;
            go3.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3steals;
            go3.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3blocks;
            go3.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3fouls;
            go3.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3turnovers;
            go3.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3clutchpts;
            go3.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3clutchpercent;
            go3.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P3points;
        }

        if (x.P4team != 0)
        {
            GameObject go4 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go4.transform.parent = content.transform;

            go4.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P4name;
            go4.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P4fgs;
            go4.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P4fgpercent;
            go4.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P4threes;
            go4.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P4threepercent;
            go4.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4assists;
            go4.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4rebounds;
            go4.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4steals;
            go4.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4blocks;
            go4.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4fouls;
            go4.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4turnovers;
            go4.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4clutchpts;
            go4.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4clutchpercent;
            go4.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P4points;
        }

        if (x.P5team != 0)
        {
            GameObject go5 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go5.transform.parent = content.transform;

            go5.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P5name;
            go5.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P5fgs;
            go5.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P5fgpercent;
            go5.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P5threes;
            go5.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P5threepercent;
            go5.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5assists;
            go5.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5rebounds;
            go5.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5steals;
            go5.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5blocks;
            go5.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5fouls;
            go5.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5turnovers;
            go5.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5clutchpts;
            go5.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5clutchpercent;
            go5.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P5points;
        }

        if (x.P6team != 0)
        {
            GameObject go6 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go6.transform.parent = content.transform;

            go6.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P6name;
            go6.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P6fgs;
            go6.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P6fgpercent;
            go6.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P6threes;
            go6.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P6threepercent;
            go6.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6assists;
            go6.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6rebounds;
            go6.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6steals;
            go6.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6blocks;
            go6.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6fouls;
            go6.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6turnovers;
            go6.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6clutchpts;
            go6.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6clutchpercent;
            go6.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P6points;
        }

        if (x.P7team != 0)
        {
            GameObject go7 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go7.transform.parent = content.transform;

            go7.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P7name;
            go7.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P7fgs;
            go7.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P7fgpercent;
            go7.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P7threes;
            go7.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P7threepercent;
            go7.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7assists;
            go7.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7rebounds;
            go7.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7steals;
            go7.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7blocks;
            go7.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7fouls;
            go7.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7turnovers;
            go7.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7clutchpts;
            go7.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7clutchpercent;
            go7.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P7points;
        }
        if (x.P8team != 0)
        {
            GameObject go8 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go8.transform.parent = content.transform;

            go8.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P8name;
            go8.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P8fgs;
            go8.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P8fgpercent;
            go8.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P8threes;
            go8.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P8threepercent;
            go8.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8assists;
            go8.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8rebounds;
            go8.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8steals;
            go8.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8blocks;
            go8.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8fouls;
            go8.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8turnovers;
            go8.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8clutchpts;
            go8.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8clutchpercent;
            go8.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P8points;
        }

        if (x.P9team != 0)
        {
            GameObject go9 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go9.transform.parent = content.transform;

            go9.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P9name;
            go9.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P9fgs;
            go9.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P9fgpercent;
            go9.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P9threes;
            go9.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P9threepercent;
            go9.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9assists;
            go9.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9rebounds;
            go9.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9steals;
            go9.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9blocks;
            go9.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9fouls;
            go9.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9turnovers;
            go9.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9clutchpts;
            go9.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9clutchpercent;
            go9.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P9points;
        }

        if (x.P10team != 0)
        {
            GameObject go10 = Instantiate(statsPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go10.transform.parent = content.transform;

            go10.transform.Find("a").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P10name;
            go10.transform.Find("b").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P10fgs;
            go10.transform.Find("c").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P10fgpercent;
            go10.transform.Find("d").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P10threes;
            go10.transform.Find("e").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = x.P10threepercent;
            go10.transform.Find("f").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10assists;
            go10.transform.Find("g").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10rebounds;
            go10.transform.Find("h").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10steals;
            go10.transform.Find("i").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10blocks;
            go10.transform.Find("j").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10fouls;
            go10.transform.Find("k").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10turnovers;
            go10.transform.Find("l").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10clutchpts;
            go10.transform.Find("m").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10clutchpercent;
            go10.transform.Find("n").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "" + x.P10points;
        }

    }


    public void homeButton()
    {
        SceneManager.LoadScene("OpenScreen");
    }

    public void deleteButton()
    {
        deleteCanvas.SetActive(true);
    }

    public void cancelDelete()
    {
        deleteCanvas.SetActive(false);
    }

    public void confirmDelete()
    {
        List<string> GamesList = new List<string>();
        if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json"))
        {
            string[] allLines = System.IO.File.ReadAllText(Application.persistentDataPath + "/GamesSaved.json").Split('\n');
            JsonString = allLines[Master.GetComponent<Master>().GameNum];


            foreach (string gamestr in allLines)
            {
                if(gamestr!=JsonString)
                    GamesList.Add(gamestr);  
            }
            if (Master.GetComponent<Master>().GameNum != 0)
                Master.GetComponent<Master>().GameNum--;
            System.IO.File.Delete(Application.persistentDataPath + "/GamesSaved.json");

        
           if(System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json") == false)
            {
                foreach(string gamestr in GamesList)
                {
                    if(gamestr == GamesList[0])
                        System.IO.File.AppendAllText(Application.persistentDataPath + "/GamesSaved.json", gamestr);
                    else
                        System.IO.File.AppendAllText(Application.persistentDataPath + "/GamesSaved.json", "\n" + gamestr);

                }
            
            }
          

            SceneManager.LoadScene("OpenScreen");


        }


    }
    public void gotoSavedGames()
    {
        SceneManager.LoadScene("SavedGames");
    }
}

