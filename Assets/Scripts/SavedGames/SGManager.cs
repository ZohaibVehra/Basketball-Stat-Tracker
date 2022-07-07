using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SGManager : MonoBehaviour
{
    public GameObject Master;
    public string path;
    public GameObject DeleteImage;
    public GameObject GamesButtonPrefab;
    public GameObject Content;

    public GameObject Prefab2;
    public int currentDel;

    void Start()
    {

        Application.targetFrameRate = 30;
        path = Application.persistentDataPath;
        Master = GameObject.Find("Master");

        PopulateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DelClicked()
    {
        currentDel = this.transform.parent.GetComponent<GameButton>().GameID;
        DeleteImage.SetActive(true);
    }

    public void DelCancel()
    {
        Master.GetComponent<Master>().setGameNumtoNew();
        DeleteImage.SetActive(false);
    }


    public void PopulateButtons()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json"))
        {
            string[] allLines = System.IO.File.ReadAllText(Application.persistentDataPath + "/GamesSaved.json").Split('\n');
            int counter = 0;
            foreach (string gamestr in allLines)
            {
                SaveData x = JsonUtility.FromJson<SaveData>(gamestr);

                GameObject go;
                if (x.GameName.Length<2)
                    go = Instantiate(Prefab2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                else
                    go = Instantiate(GamesButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                go.transform.parent = Content.transform;
                go.GetComponent<GameButton>().GameID = counter;

                if(!(x.GameName.Length<2))
                go.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = x.GameName;
                else if (go.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text == "" || go.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text.Length < 2 || x.GameName == "" || x.GameName==null)
                    go.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = "No Name Set";

                else
                    go.transform.Find("TimeText").GetComponent<Text>().text = x.GameTime;


                go.transform.Find("ScoreText").GetComponent<Text>().text = GetScore(x);
                go.transform.Find("DateText").GetComponent<Text>().text = x.GameDate;

                path = go.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text;
                counter++;
            }
        }

    }

    public string GetScore(SaveData x)
    {
        string score = "";

        int t1score = 0;
        int t2score = 0;

        t1score += x.P1points;
        t1score += x.P2points;
        t1score += x.P3points;

        if(x.P4team == 1)
            t1score += x.P4points;
        else
            t2score += x.P4points;
        if (x.P5team == 1)
            t1score += x.P5points;
        else
            t2score += x.P5points;

        t2score += x.P6points;
        t2score += x.P7points;
        t2score += x.P8points;
        t2score += x.P9points;
        t2score += x.P10points;

        score += t1score + " - " + t2score;



        return score;
    }

    public void Home()
    {
        SceneManager.LoadScene("OpenScreen");
    }


    public void confirmDelete()
    {
        string JsonString = "";
        List<string> GamesList = new List<string>();
        if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json"))
        {
            string[] allLines = System.IO.File.ReadAllText(Application.persistentDataPath + "/GamesSaved.json").Split('\n');
            JsonString = allLines[currentDel];


            foreach (string gamestr in allLines)
            {
                if (gamestr != JsonString)
                    GamesList.Add(gamestr);
            }
            if (Master.GetComponent<Master>().GameNum != 0)
                Master.GetComponent<Master>().setGameNumtoNew();
            System.IO.File.Delete(Application.persistentDataPath + "/GamesSaved.json");


            if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json") == false)
            {
                foreach (string gamestr in GamesList)
                {
                    if (gamestr == GamesList[0])
                        System.IO.File.AppendAllText(Application.persistentDataPath + "/GamesSaved.json", gamestr);
                    else
                        System.IO.File.AppendAllText(Application.persistentDataPath + "/GamesSaved.json", "\n" + gamestr);

                }

            }


            SceneManager.LoadScene("SavedGames");


        }


    }
}
