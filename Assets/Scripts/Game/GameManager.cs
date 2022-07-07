using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject Master;
    public List<Player> Team1;
    public List<Player> Team2;
    public List<Stats> StatsList;

    public GameObject CancelCanvas;
    public GameObject CanvasGO;
    public GameObject GameOverCanvas;

    public GameObject T1;
    public GameObject T2;
    public GameObject PlayerButtonPrefab;
    public GameObject PlayerButtonPrefab4;
    public GameObject PlayerButtonPrefab3;

    public Highlights highlighter;
    public Color SelectedPlayer;
    public Color UnselectedPlayer;

    public GameObject StatTextGO;
    public GameObject playimage;

    public GameObject GPButton;
    public bool GamePoint = false;

    public bool onesandtwos = true;

    public GameObject clockGO;


    public GameObject setButton;
    public GameObject setnameImage;
    public GameObject nametextfield;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 20;
        Master = GameObject.Find("Master");
        onesandtwos = Master.GetComponent<Master>().onesandtwos;

        //set up player tabs
        InstantiatePlayerButtons();

        //set selected player color
        SelectedPlayer = T1.transform.Find("P1").GetComponent<Image>().color;
        UnselectedPlayer = T1.transform.Find("P1").GetComponent<Image>().color;
        SelectedPlayer.r = 56;
        SelectedPlayer.g = 56;
        SelectedPlayer.b = 56;

        StatTextGO.GetComponent<TextMeshProUGUI>().text = "Last Action: " ;



    }

    // Update is called once per frame
    void Update()
    {
        SetStatHighlights();
        SetPlayerHighlights();
        CheckStatChange();
        GetTime();
    }

    public void CreatePlayers()
    {
        int playernums = Master.GetComponent<Master>().PlayerNums;
        Master MasterS = Master.GetComponent<Master>();
        if (playernums == 3)
        {
            Player P1 = new Player(MasterS.Players[0]);
            Player P2 = new Player(MasterS.Players[1]);
            Player P3 = new Player(MasterS.Players[2]);

            Player P4 = new Player(MasterS.Players[3]);
            Player P5 = new Player(MasterS.Players[4]);
            Player P6 = new Player(MasterS.Players[5]);

            Team1.Add(P1);
            Team1.Add(P2);
            Team1.Add(P3);

            Team2.Add(P4);
            Team2.Add(P5);
            Team2.Add(P6);
        }
        else if (playernums == 4)
        {
            Player P1 = new Player(MasterS.Players[0]);
            Player P2 = new Player(MasterS.Players[1]);
            Player P3 = new Player(MasterS.Players[2]);
            Player P4 = new Player(MasterS.Players[3]);
            Player P5 = new Player(MasterS.Players[4]);
            Player P6 = new Player(MasterS.Players[5]);
            Player P7 = new Player(MasterS.Players[6]);
            Player P8 = new Player(MasterS.Players[7]);


            Team1.Add(P1);
            Team1.Add(P2);
            Team1.Add(P3);
            Team1.Add(P4);

            Team2.Add(P5);
            Team2.Add(P6);
            Team2.Add(P7);
            Team2.Add(P8);
        }
        else if (playernums == 5)
        {
            Player P1 = new Player(MasterS.Players[0]);
            Player P2 = new Player(MasterS.Players[1]);
            Player P3 = new Player(MasterS.Players[2]);
            Player P4 = new Player(MasterS.Players[3]);
            Player P5 = new Player(MasterS.Players[4]);
            Player P6 = new Player(MasterS.Players[5]);
            Player P7 = new Player(MasterS.Players[6]);
            Player P8 = new Player(MasterS.Players[7]);
            Player P9 = new Player(MasterS.Players[8]);
            Player P10 = new Player(MasterS.Players[9]);

            Team1.Add(P1);
            Team1.Add(P2);
            Team1.Add(P3);
            Team1.Add(P4);
            Team1.Add(P5);

            Team2.Add(P6);
            Team2.Add(P7);
            Team2.Add(P8);
            Team2.Add(P9);
            Team2.Add(P10);
        }
    }

    public void InstantiatePlayerButtons()
    {
        int playernum = Master.GetComponent<Master>().PlayerNums;

        if(playernum == 5)
        {
            for(int i=1; i<6; i++)
            {
                GameObject childObject = Instantiate(PlayerButtonPrefab) as GameObject;
                childObject.name = "P" + i;
                childObject.transform.parent = T1.transform;
                childObject.GetComponent<ButtonID>().buttonid = i;

                Vector3 changepos = new Vector3(0f, 0f, 0f);
                childObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
                changepos.x = 0f;
                changepos.y = 0f;
                
                float x = i;
                changepos.x += (x-1f)*(170f + 37.5f)-500f;
                childObject.GetComponent<RectTransform>().localPosition = changepos;

                //set player
                childObject.GetComponent<Player>().playername = Master.GetComponent<Master>().Players[i - 1];
                Team1.Add(childObject.GetComponent<Player>());
                childObject.transform.Find("PlayerText").GetComponent<TextMeshProUGUI>().text = childObject.GetComponent<Player>().playername;
            }

            for (int i = 6; i < 11; i++)
            {
                GameObject childObject = Instantiate(PlayerButtonPrefab) as GameObject;
                childObject.name = "P" + i;
                childObject.transform.parent = T2.transform;
                childObject.GetComponent<ButtonID>().buttonid = i;

                Vector3 changepos = new Vector3(0f, 0f, 0f);
                childObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
                changepos.x = 0f;
                changepos.y = 0f;

                float x = i;
                changepos.x += (x - 6f) * (170f + 37.5f) - 500f;
                changepos.y += 200f;
                childObject.GetComponent<RectTransform>().localPosition = changepos;

                //set player
                childObject.GetComponent<Player>().playername = Master.GetComponent<Master>().Players[i - 1];
                Team2.Add(childObject.GetComponent<Player>());
                childObject.transform.Find("PlayerText").GetComponent<TextMeshProUGUI>().text = childObject.GetComponent<Player>().playername;
            }

        }
        else if (playernum == 4)
        {
            for (int i = 1; i < 5; i++)
            {
                GameObject childObject = Instantiate(PlayerButtonPrefab4) as GameObject;
                childObject.name = "P" + i;
                childObject.transform.parent = T1.transform;
                childObject.GetComponent<ButtonID>().buttonid = i;

                Vector3 changepos = new Vector3(0f, 0f, 0f);
                childObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
                changepos.x = 0f;
                changepos.y = 0f;

                float x = i;
                changepos.x += (x - 1f) * (266f) - 500f;
                childObject.GetComponent<RectTransform>().localPosition = changepos;

                //set player
                childObject.GetComponent<Player>().playername = Master.GetComponent<Master>().Players[i - 1];
                Team1.Add(childObject.GetComponent<Player>());
                childObject.transform.Find("PlayerText").GetComponent<TextMeshProUGUI>().text = childObject.GetComponent<Player>().playername;
            }

            for (int i = 5; i < 9; i++)
            {
                GameObject childObject = Instantiate(PlayerButtonPrefab4) as GameObject;
                childObject.name = "P" + i;
                childObject.transform.parent = T2.transform;
                childObject.GetComponent<ButtonID>().buttonid = i;

                Vector3 changepos = new Vector3(0f, 0f, 0f);
                childObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
                changepos.x = 0f;
                changepos.y = 0f;

                float x = i;
                changepos.x += (x - 5f) * (266f) - 500f;
                changepos.y += 200f;
                childObject.GetComponent<RectTransform>().localPosition = changepos;

                //set player
                childObject.GetComponent<Player>().playername = Master.GetComponent<Master>().Players[i - 1];
                Team2.Add(childObject.GetComponent<Player>());
                childObject.transform.Find("PlayerText").GetComponent<TextMeshProUGUI>().text = childObject.GetComponent<Player>().playername;
            }

        }
        else if (playernum == 3)
        {
            for (int i = 1; i < 4; i++)
            {
                GameObject childObject = Instantiate(PlayerButtonPrefab3) as GameObject;
                childObject.name = "P" + i;
                childObject.transform.parent = T1.transform;
                childObject.GetComponent<ButtonID>().buttonid = i;

                Vector3 changepos = new Vector3(0f, 0f, 0f);
                childObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
                changepos.x = 0f;
                changepos.y = 0f;

                float x = i;
                changepos.x += (x - 1f) * (365f) - 500f;
                childObject.GetComponent<RectTransform>().localPosition = changepos;

                //set player
                childObject.GetComponent<Player>().playername = Master.GetComponent<Master>().Players[i - 1];
                Team1.Add(childObject.GetComponent<Player>());
                childObject.transform.Find("PlayerText").GetComponent<TextMeshProUGUI>().text = childObject.GetComponent<Player>().playername;
                childObject.GetComponent<Player>().team = 1;
            }

            for (int i = 4; i < 7; i++)
            {
                GameObject childObject = Instantiate(PlayerButtonPrefab3) as GameObject;
                childObject.name = "P" + i;
                childObject.transform.parent = T2.transform;
                childObject.GetComponent<ButtonID>().buttonid = i;

                Vector3 changepos = new Vector3(0f, 0f, 0f);
                childObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
                changepos.x = 0f;
                changepos.y = 0f;

                float x = i;
                changepos.x += (x - 4f) * (365f) - 500f;
                changepos.y += 200f;
                childObject.GetComponent<RectTransform>().localPosition = changepos;

                //set player
                childObject.GetComponent<Player>().playername = Master.GetComponent<Master>().Players[i - 1];
                Team2.Add(childObject.GetComponent<Player>());
                childObject.transform.Find("PlayerText").GetComponent<TextMeshProUGUI>().text = childObject.GetComponent<Player>().playername;
                childObject.GetComponent<Player>().team = 2;
            }

        }
    }

    public void CancelButton()
    {
        
        CanvasGO.SetActive(false);
        CancelCanvas.SetActive(true);



    }

    
    
    public void SetPlayerHighlights()
    {
        foreach (Transform child in T1.transform)
        {
            child.gameObject.GetComponent<Image>().color = UnselectedPlayer;
        }
        foreach (Transform child in T2.transform)
        {
            child.gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }

        if (highlighter.team == 1)
        {
            GameObject buttoncol = T1.transform.GetChild(highlighter.index - 1).gameObject;
            buttoncol.GetComponent<Image>().color = SelectedPlayer;
        }
        else if (highlighter.team == 2)
        {
            GameObject buttoncol = T2.transform.GetChild(highlighter.index - 1).gameObject;
            buttoncol.GetComponent<Image>().color = SelectedPlayer;
        }

    }

    public void SetStatHighlights()
    {
        if (highlighter.stat == 1)
        {
            playimage.transform.Find("3pt").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("3pt").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 2)
        {
            playimage.transform.Find("2pt").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("2pt").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 3)
        {
            playimage.transform.Find("Assist").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("Assist").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 4)
        {
            playimage.transform.Find("Block").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("Block").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 5)
        {
            playimage.transform.Find("Steal").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("Steal").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 6)
        {
            playimage.transform.Find("Foul").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("Foul").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 7)
        {
            playimage.transform.Find("TO").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("TO").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 8)
        {
            playimage.transform.Find("Miss").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("Miss").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 9)
        {
            playimage.transform.Find("Miss3").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("Miss3").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }
        if (highlighter.stat == 10)
        {
            playimage.transform.Find("Reb").gameObject.GetComponent<Image>().color = SelectedPlayer;
        }
        else
        {
            playimage.transform.Find("Reb").gameObject.GetComponent<Image>().color = UnselectedPlayer;

        }

    }


    public void CheckStatChange()
    {
        if(highlighter.index != 0 && highlighter.stat != 0)
        {
            Debug.Log("entered stat change");
            Stats newStat = new Stats(highlighter.team, highlighter.index, highlighter.stat, highlighter.statstr);
            StatsList.Add(newStat);

            giveStats(StatsList[StatsList.Count - 1].team, StatsList[StatsList.Count - 1].index, StatsList[StatsList.Count - 1].stat);

            RevaluateStatDisplay();

            highlighter.index = 0;
            highlighter.team = 0;
            highlighter.stat = 0;
            highlighter.statstr = "";
        }

        
    }

    public void RevaluateStatDisplay()
    {
        string displayStr = "";

        if (StatsList.Count > 0)
        {
            string TempPlayerName = "";
            if (StatsList[StatsList.Count - 1].team == 1)
                TempPlayerName = T1.transform.GetChild(StatsList[StatsList.Count-1].index-1).gameObject.GetComponent<Player>().playername;
            else
                TempPlayerName = T2.transform.GetChild(StatsList[StatsList.Count - 1].index-1).gameObject.GetComponent<Player>().playername;

             displayStr = TempPlayerName + "  " + StatsList[StatsList.Count - 1].lastplay;

        }
        StatTextGO.GetComponent<TextMeshProUGUI>().text = "Last Action: "+  displayStr;

    }
    
    public void UndoButton()
    {
        if (StatsList.Count > 0)
        {
            int index = StatsList[StatsList.Count - 1].index;
            int team = StatsList[StatsList.Count - 1].team;
            int stat = StatsList[StatsList.Count - 1].stat;

            if(team == 1)
            {
                if (stat == 1)
                {
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().threes--;
                    if (GamePoint)
                        T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchbuckets--;
                }
                else if (stat == 2)  
                {
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().buckets--;
                    if(GamePoint)
                        T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchbuckets--;
                }
                else if (stat == 3)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().assists--;
                else if(stat == 4)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().blocks--;
                else if(stat == 5)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().steals--;
                else if(stat == 6)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().fouls--;
                else if(stat == 7)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().turnovers--;
                else if(stat == 8)
                {
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().misses--;
                    if (GamePoint)
                        T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchmisses--;
                }
                else if(stat == 9)
                {
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().threemissed--;
                    if (GamePoint)
                        T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchmisses--;
                }
                else if (stat == 10)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().rebounds--;
            }
            else
            {
                if (stat == 1)
                {
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().threes--;
                    if (GamePoint)
                        T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchbuckets--;
                }
                else if(stat == 2)
                {
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().buckets--;
                    if (GamePoint)
                        T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchbuckets--;
                }
                else if(stat == 3)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().assists--;
                else if(stat == 4)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().blocks--;
                else if(stat == 5)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().steals--;
                else if(stat == 6)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().fouls--;
                else if(stat == 7)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().turnovers--;
                else if(stat == 8)
                {
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().misses--;
                    if (GamePoint)
                        T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchmisses--;
                }
                else if(stat == 9)
                {
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().threemissed--;
                    if (GamePoint)
                        T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchmisses--;
                }
                else if (stat == 10)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().rebounds--;
            }
            StatsList.RemoveAt(StatsList.Count - 1);
            RevaluateStatDisplay();
        }
    }

    public void GPButtonClicked()
    {


        Color redcolor = GPButton.GetComponent<Outline>().effectColor;
        Color blackcolor = GPButton.GetComponent<Outline>().effectColor;
        redcolor.r = 255f;
        redcolor.g = 0f;
        redcolor.a = 128f;
        redcolor.b = 0f;

        blackcolor.r = 0f;
        blackcolor.g = 0f;
        blackcolor.a = 128f;
        blackcolor.b = 0f;

        if (GamePoint)
            GPButton.GetComponent<Outline>().effectColor = blackcolor;
        else
            GPButton.GetComponent<Outline>().effectColor = redcolor;

        GamePoint = !GamePoint;
    }

    public void giveStats(int team, int index, int stat)
    {
        if(team ==1)
        {
            if (stat == 1)
            {
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().threes++;
                if (GamePoint)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchbuckets++ ;
            }
            else if(stat == 2)
            {
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().buckets++;
                if (GamePoint)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchbuckets++;
            }
            else if(stat == 3)
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().assists++;
            else if(stat == 4)
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().blocks++;
            else if(stat == 5)
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().steals++;
            else if(stat == 6)
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().fouls++;
            else if(stat == 7)
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().turnovers++;
            else if(stat == 8)
            {
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().misses++;
                if (GamePoint)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchmisses++;
            }
            else if(stat == 9)
            {
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().threemissed++;
                if (GamePoint)
                    T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchmisses++;
            }
            else if (stat == 10)
                T1.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().rebounds++;
        }
        else
        {
            if (team == 2)
            {
                if (stat == 1)
                {
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().threes++;
                    if (GamePoint)
                        T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchbuckets++;
                }
                else if(stat == 2)
                {
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().buckets++;
                    if (GamePoint)
                        T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchbuckets++;
                }
                else if(stat == 3)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().assists++;
                else if(stat == 4)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().blocks++;
                else if(stat == 5)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().steals++;
                else if(stat == 6)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().fouls++;
                else if(stat == 7)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().turnovers++;
                else if(stat == 8)
                {
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().misses++;
                    if (GamePoint)
                        T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchmisses++;
                }
                else if(stat == 9)
                {
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().threemissed++;
                    if (GamePoint)
                        T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().clutchmisses++;
                }
                else if (stat == 10)
                    T2.transform.GetChild(StatsList[StatsList.Count - 1].index - 1).gameObject.GetComponent<Player>().rebounds++;
            }
        }

    }

    public void GetTime()
    {
        int tme = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        int sec=0;
        int min=0;
        string secs;
        string mins;

        sec = tme % 60;
        if (tme >= 60)
        {
            min = tme / 60; 
        }
        if (min < 10)
            mins = "0" + min;
        else
            mins = "" + min;
        if (sec < 10)
            secs = "0" + sec;
        else
            secs = "" + sec;


        string timestr = mins + " : " + secs;
        clockGO.GetComponent<TextMeshProUGUI>().text = timestr;
        
    }

    public void cancelconfirm()
    {
        CancelCanvas.SetActive(false);
        CanvasGO.SetActive(true);
        SceneManager.LoadScene("OpenScreen");
    }
    public void cancelcancel()
    {
        CancelCanvas.SetActive(false);
        CanvasGO.SetActive(true);
    }

    public void GameOverButton()
    {
        CanvasGO.SetActive(false);
        GameOverCanvas.SetActive(true);
    }
    public void cancelGameOver()
    {
        GameOverCanvas.SetActive(false);
        CanvasGO.SetActive(true);
        setButton.SetActive(false);
        setnameImage.SetActive(false);
        nametextfield.SetActive(false);
    }

    public void ConfirmGameOver()
    {
        setButton.SetActive(true);
        setnameImage.SetActive(true);
        nametextfield.SetActive(true);
    }

    public SaveData creatingSaveData()
    {
        SaveData Save = new SaveData();

        Save.GameName = nametextfield.transform.Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().text;
        Save.GameTime = clockGO.GetComponent<TextMeshProUGUI>().text;
        Save.playersnum = Master.GetComponent<Master>().PlayerNums;
        int t1points = 0;
        int t2points =0;
        string finalscore;

        if(Save.playersnum == 5)
        {
            int totalthrees;
            string xthrees;
            float fthree;
            float ftotalthrees;
            float threepercent;
            int threepercentint;
            string threepercentstr;

            int totaltwos;
            string xtwos;
            float ftwo;
            float ftotaltwos;
            float twopercent;
            int twopercentint;
            string twopercentstr;

            int totalclutch;
            string xclutches;
            float fclutch;
            float ftotalclutch;
            float clutchpercent;
            int clutchpercentint;
            string clutchpercentstr;
            int xpoints;


            Player x = T1.transform.Find("P1").GetComponent<Player>();
            Save.P1name = x.playername;
            Save.P1team = 1;
            
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P1points = xpoints;
            Save.P1rebounds = x.rebounds;
            Save.P1assists = x.assists;
            Save.P1blocks = x.blocks;
            Save.P1steals = x.steals;
            Save.P1fouls = x.fouls;
            Save.P1turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P1threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P1threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P1fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P1fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P1clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P1clutchpercent = clutchpercentstr;

            if(x.buckets + x.misses == 0)
            {
                Save.P1fgs = "0/0";
                Save.P1fgpercent = "-";
            }
            if (x.threemissed + x.threes== 0)
            {
                Save.P1threes = "0/0";
                Save.P1threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses== 0)
            {
                Save.P1clutchpts = "0/0";
                Save.P1clutchpercent = "-";
            }
            t1points += x.points;


            //p2
            x = T1.transform.Find("P2").GetComponent<Player>();
            Save.P2name = x.playername;
            Save.P2team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P2points = xpoints;
            Save.P2rebounds = x.rebounds;
            Save.P2assists = x.assists;
            Save.P2blocks = x.blocks;
            Save.P2steals = x.steals;
            Save.P2fouls = x.fouls;
            Save.P2turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P2threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P2threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P2fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P2fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P2clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P2clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P2fgs = "0/0";
                Save.P2fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P2threes = "0/0";
                Save.P2threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P2clutchpts = "0/0";
                Save.P2clutchpercent = "-";
            }


            //P3
            x = T1.transform.Find("P3").GetComponent<Player>();
            Save.P3name = x.playername;
            Save.P3team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P3points = xpoints;
            Save.P3rebounds = x.rebounds;
            Save.P3assists = x.assists;
            Save.P3blocks = x.blocks;
            Save.P3steals = x.steals;
            Save.P3fouls = x.fouls;
            Save.P3turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P3threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P3threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P3fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P3fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P3clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P3clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P3fgs = "0/0";
                Save.P3fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P3threes = "0/0";
                Save.P3threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P3clutchpts = "0/0";
                Save.P3clutchpercent = "-";
            }



            //P4
            x = T1.transform.Find("P4").GetComponent<Player>();
            Save.P4name = x.playername;
            Save.P4team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P4points = xpoints;
            Save.P4rebounds = x.rebounds;
            Save.P4assists = x.assists;
            Save.P4blocks = x.blocks;
            Save.P4steals = x.steals;
            Save.P4fouls = x.fouls;
            Save.P4turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P4threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P4threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P4fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P4fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P4clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P4clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P4fgs = "0/0";
                Save.P4fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P4threes = "0/0";
                Save.P4threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P4clutchpts = "0/0";
                Save.P4clutchpercent = "-";
            }


            //P5
            x = T1.transform.Find("P5").GetComponent<Player>();
            Save.P5name = x.playername;
            Save.P5team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P5points = xpoints;
            Save.P5rebounds = x.rebounds;
            Save.P5assists = x.assists;
            Save.P5blocks = x.blocks;
            Save.P5steals = x.steals;
            Save.P5fouls = x.fouls;
            Save.P5turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P5threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P5threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P5fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P5fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P5clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P5clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P5fgs = "0/0";
                Save.P5fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P5threes = "0/0";
                Save.P5threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P5clutchpts = "0/0";
                Save.P5clutchpercent = "-";
            }



            //P6
            x = T2.transform.Find("P6").GetComponent<Player>();
            Save.P6name = x.playername;
            Save.P6team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P6points = xpoints;
            Save.P6rebounds = x.rebounds;
            Save.P6assists = x.assists;
            Save.P6blocks = x.blocks;
            Save.P6steals = x.steals;
            Save.P6fouls = x.fouls;
            Save.P6turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P6threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P6threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P6fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P6fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P6clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P6clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P6fgs = "0/0";
                Save.P6fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P6threes = "0/0";
                Save.P6threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P6clutchpts = "0/0";
                Save.P6clutchpercent = "-";
            }



            //P7
            x = T2.transform.Find("P7").GetComponent<Player>();
            Save.P7name = x.playername;
            Save.P7team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P7points = xpoints;
            Save.P7rebounds = x.rebounds;
            Save.P7assists = x.assists;
            Save.P7blocks = x.blocks;
            Save.P7steals = x.steals;
            Save.P7fouls = x.fouls;
            Save.P7turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P7threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P7threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P7fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P7fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P7clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P7clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P7fgs = "0/0";
                Save.P7fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P7threes = "0/0";
                Save.P7threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P7clutchpts = "0/0";
                Save.P7clutchpercent = "-";
            }


            //P8
            x = T2.transform.Find("P8").GetComponent<Player>();
            Save.P8name = x.playername;
            Save.P8team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P8points = xpoints;
            Save.P8rebounds = x.rebounds;
            Save.P8assists = x.assists;
            Save.P8blocks = x.blocks;
            Save.P8steals = x.steals;
            Save.P8fouls = x.fouls;
            Save.P8turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P8threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P8threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P8fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P8fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P8clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P8clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P8fgs = "0/0";
                Save.P8fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P8threes = "0/0";
                Save.P8threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P8clutchpts = "0/0";
                Save.P8clutchpercent = "-";
            }



            //P9
            x = T2.transform.Find("P9").GetComponent<Player>();
            Save.P9name = x.playername;
            Save.P9team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P9points = xpoints;
            Save.P9rebounds = x.rebounds;
            Save.P9assists = x.assists;
            Save.P9blocks = x.blocks;
            Save.P9steals = x.steals;
            Save.P9fouls = x.fouls;
            Save.P9turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P9threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P9threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P9fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P9fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P9clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P9clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P9fgs = "0/0";
                Save.P9fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P9threes = "0/0";
                Save.P9threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P9clutchpts = "0/0";
                Save.P9clutchpercent = "-";
            }


            //P10
            x = T2.transform.Find("P10").GetComponent<Player>();
            Save.P10name = x.playername;
            Save.P10team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P10points = xpoints;
            Save.P10rebounds = x.rebounds;
            Save.P10assists = x.assists;
            Save.P10blocks = x.blocks;
            Save.P10steals = x.steals;
            Save.P10fouls = x.fouls;
            Save.P10turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P10threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P10threepercent = threepercentstr;

            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P10fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P10fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P10clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P10clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P10fgs = "0/0";
                Save.P10fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P10threes = "0/0";
                Save.P10threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P10clutchpts = "0/0";
                Save.P10clutchpercent = "-";
            }

        }

        else if (Save.playersnum == 4)
        {
            int totalthrees;
            string xthrees;
            float fthree;
            float ftotalthrees;
            float threepercent;
            int threepercentint;
            string threepercentstr;

            int totaltwos;
            string xtwos;
            float ftwo;
            float ftotaltwos;
            float twopercent;
            int twopercentint;
            string twopercentstr;

            int totalclutch;
            string xclutches;
            float fclutch;
            float ftotalclutch;
            float clutchpercent;
            int clutchpercentint;
            string clutchpercentstr;
            int xpoints;


            Player x = T1.transform.Find("P1").GetComponent<Player>();
            Save.P1name = x.playername;
            Save.P1team = 1;

            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P1points = xpoints;
            Save.P1rebounds = x.rebounds;
            Save.P1assists = x.assists;
            Save.P1blocks = x.blocks;
            Save.P1steals = x.steals;
            Save.P1fouls = x.fouls;
            Save.P1turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P1threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P1threepercent = threepercentstr;


            totaltwos = x.buckets +x.threes+x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P1fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P1fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P1clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P1clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P1fgs = "0/0";
                Save.P1fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P1threes = "0/0";
                Save.P1threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P1clutchpts = "0/0";
                Save.P1clutchpercent = "-";
            }



            //p2
            x = T1.transform.Find("P2").GetComponent<Player>();
            Save.P2name = x.playername;
            Save.P2team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P2points = xpoints;
            Save.P2rebounds = x.rebounds;
            Save.P2assists = x.assists;
            Save.P2blocks = x.blocks;
            Save.P2steals = x.steals;
            Save.P2fouls = x.fouls;
            Save.P2turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P2threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P2threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P2fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P2fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P2clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P2clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P2fgs = "0/0";
                Save.P2fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P2threes = "0/0";
                Save.P2threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P2clutchpts = "0/0";
                Save.P2clutchpercent = "-";
            }


            //P3
            x = T1.transform.Find("P3").GetComponent<Player>();
            Save.P3name = x.playername;
            Save.P3team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P3points = xpoints;
            Save.P3rebounds = x.rebounds;
            Save.P3assists = x.assists;
            Save.P3blocks = x.blocks;
            Save.P3steals = x.steals;
            Save.P3fouls = x.fouls;
            Save.P3turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P3threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P3threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P3fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P3fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P3clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P3clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P3fgs = "0/0";
                Save.P3fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P3threes = "0/0";
                Save.P3threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P3clutchpts = "0/0";
                Save.P3clutchpercent = "-";
            }



            //P4
            x = T1.transform.Find("P4").GetComponent<Player>();
            Save.P4name = x.playername;
            Save.P4team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P4points = xpoints;
            Save.P4rebounds = x.rebounds;
            Save.P4assists = x.assists;
            Save.P4blocks = x.blocks;
            Save.P4steals = x.steals;
            Save.P4fouls = x.fouls;
            Save.P4turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P4threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P4threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P4fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P4fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P4clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P4clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P4fgs = "0/0";
                Save.P4fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P4threes = "0/0";
                Save.P4threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P4clutchpts = "0/0";
                Save.P4clutchpercent = "-";
            }


            //P5
            x = T2.transform.Find("P5").GetComponent<Player>();
            Save.P5name = x.playername;
            Save.P5team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P5points = xpoints;
            Save.P5rebounds = x.rebounds;
            Save.P5assists = x.assists;
            Save.P5blocks = x.blocks;
            Save.P5steals = x.steals;
            Save.P5fouls = x.fouls;
            Save.P5turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P5threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P5threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P5fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P5fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P5clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P5clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P5fgs = "0/0";
                Save.P5fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P5threes = "0/0";
                Save.P5threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P5clutchpts = "0/0";
                Save.P5clutchpercent = "-";
            }



            //P6
            x = T2.transform.Find("P6").GetComponent<Player>();
            Save.P6name = x.playername;
            Save.P6team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P6points = xpoints;
            Save.P6rebounds = x.rebounds;
            Save.P6assists = x.assists;
            Save.P6blocks = x.blocks;
            Save.P6steals = x.steals;
            Save.P6fouls = x.fouls;
            Save.P6turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P6threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P6threepercent = threepercentstr;

            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P6fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P6fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P6clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P6clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P6fgs = "0/0";
                Save.P6fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P6threes = "0/0";
                Save.P6threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P6clutchpts = "0/0";
                Save.P6clutchpercent = "-";
            }



            //P7
            x = T2.transform.Find("P7").GetComponent<Player>();
            Save.P7name = x.playername;
            Save.P7team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P7points = xpoints;
            Save.P7rebounds = x.rebounds;
            Save.P7assists = x.assists;
            Save.P7blocks = x.blocks;
            Save.P7steals = x.steals;
            Save.P7fouls = x.fouls;
            Save.P7turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P7threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P7threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P7fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P7fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P7clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P7clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P7fgs = "0/0";
                Save.P7fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P7threes = "0/0";
                Save.P7threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P7clutchpts = "0/0";
                Save.P7clutchpercent = "-";
            }


            //P8
            x = T2.transform.Find("P8").GetComponent<Player>();
            Save.P8name = x.playername;
            Save.P8team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P8points = xpoints;
            Save.P8rebounds = x.rebounds;
            Save.P8assists = x.assists;
            Save.P8blocks = x.blocks;
            Save.P8steals = x.steals;
            Save.P8fouls = x.fouls;
            Save.P8turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P8threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P8threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P8fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P8fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P8clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P8clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P8fgs = "0/0";
                Save.P8fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P8threes = "0/0";
                Save.P8threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P8clutchpts = "0/0";
                Save.P8clutchpercent = "-";
            }


        }

        else if (Save.playersnum == 3)
        {
            int totalthrees;
            string xthrees;
            float fthree;
            float ftotalthrees;
            float threepercent;
            int threepercentint;
            string threepercentstr;

            int totaltwos;
            string xtwos;
            float ftwo;
            float ftotaltwos;
            float twopercent;
            int twopercentint;
            string twopercentstr;

            int totalclutch;
            string xclutches;
            float fclutch;
            float ftotalclutch;
            float clutchpercent;
            int clutchpercentint;
            string clutchpercentstr;
            int xpoints;


            Player x = T1.transform.Find("P1").GetComponent<Player>();
            Save.P1name = x.playername;
            Save.P1team = 1;

            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P1points = xpoints;
            Save.P1rebounds = x.rebounds;
            Save.P1assists = x.assists;
            Save.P1blocks = x.blocks;
            Save.P1steals = x.steals;
            Save.P1fouls = x.fouls;
            Save.P1turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P1threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P1threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P1fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P1fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P1clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P1clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P1fgs = "0/0";
                Save.P1fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P1threes = "0/0";
                Save.P1threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P1clutchpts = "0/0";
                Save.P1clutchpercent = "-";
            }



            //p2
            x = T1.transform.Find("P2").GetComponent<Player>();
            Save.P2name = x.playername;
            Save.P2team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P2points = xpoints;
            Save.P2rebounds = x.rebounds;
            Save.P2assists = x.assists;
            Save.P2blocks = x.blocks;
            Save.P2steals = x.steals;
            Save.P2fouls = x.fouls;
            Save.P2turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P2threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P2threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P2fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P2fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P2clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P2clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P2fgs = "0/0";
                Save.P2fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P2threes = "0/0";
                Save.P2threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P2clutchpts = "0/0";
                Save.P2clutchpercent = "-";
            }


            //P3
            x = T1.transform.Find("P3").GetComponent<Player>();
            Save.P3name = x.playername;
            Save.P3team = 1;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P3points = xpoints;
            Save.P3rebounds = x.rebounds;
            Save.P3assists = x.assists;
            Save.P3blocks = x.blocks;
            Save.P3steals = x.steals;
            Save.P3fouls = x.fouls;
            Save.P3turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P3threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P3threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P3fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P3fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P3clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P3clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P3fgs = "0/0";
                Save.P3fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P3threes = "0/0";
                Save.P3threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P3clutchpts = "0/0";
                Save.P3clutchpercent = "-";
            }



            //P4
            x = T2.transform.Find("P4").GetComponent<Player>();
            Save.P4name = x.playername;
            Save.P4team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P4points = xpoints;
            Save.P4rebounds = x.rebounds;
            Save.P4assists = x.assists;
            Save.P4blocks = x.blocks;
            Save.P4steals = x.steals;
            Save.P4fouls = x.fouls;
            Save.P4turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P4threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P4threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P4fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P4fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P4clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P4clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P4fgs = "0/0";
                Save.P4fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P4threes = "0/0";
                Save.P4threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P4clutchpts = "0/0";
                Save.P4clutchpercent = "-";
            }


            //P5
            x = T2.transform.Find("P5").GetComponent<Player>();
            Save.P5name = x.playername;
            Save.P5team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P5points = xpoints;
            Save.P5rebounds = x.rebounds;
            Save.P5assists = x.assists;
            Save.P5blocks = x.blocks;
            Save.P5steals = x.steals;
            Save.P5fouls = x.fouls;
            Save.P5turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P5threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P5threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P5fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P5fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P5clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P5clutchpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P5fgs = "0/0";
                Save.P5fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P5threes = "0/0";
                Save.P5threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P5clutchpts = "0/0";
                Save.P5clutchpercent = "-";
            }



            //P6
            x = T2.transform.Find("P6").GetComponent<Player>();
            Save.P6name = x.playername;
            Save.P6team = 2;
            if (Master.GetComponent<Master>().onesandtwos)
                xpoints = x.buckets + x.threes * 2;
            else
                xpoints = x.buckets + x.threes;
            Save.P6points = xpoints;
            Save.P6rebounds = x.rebounds;
            Save.P6assists = x.assists;
            Save.P6blocks = x.blocks;
            Save.P6steals = x.steals;
            Save.P6fouls = x.fouls;
            Save.P6turnovers = x.turnovers;

            totalthrees = x.threes + x.threemissed;
            xthrees = "" + x.threes + "/" + totalthrees;
            Save.P6threes = xthrees;

            fthree = x.threes;
            ftotalthrees = totalthrees;
            threepercent = fthree / ftotalthrees;
            threepercent *= 100;
            threepercentint = Mathf.RoundToInt(threepercent);
            threepercentstr = "" + threepercentint + "%";
            Debug.Log("three pt % is = " + threepercentstr);
            Save.P6threepercent = threepercentstr;


            totaltwos = x.buckets + x.threes + x.threemissed + x.misses;
            ftwo = x.buckets + x.threes;
            xtwos = "" + ftwo + "/" + totaltwos;
            Save.P6fgs = xtwos;
            ftotaltwos = totaltwos;
            twopercent = ftwo / ftotaltwos;
            twopercent *= 100;
            twopercentint = Mathf.RoundToInt(twopercent);
            twopercentstr = "" + twopercentint + "%";
            Save.P6fgpercent = twopercentstr;

            totalclutch = x.clutchbuckets + x.clutchmisses;
            xclutches = "" + x.clutchbuckets + "/" + totalclutch;
            Save.P6clutchpts = xclutches;

            fclutch = x.clutchbuckets;
            ftotalclutch = totalclutch;
            clutchpercent = fclutch / ftotalclutch;
            clutchpercent *= 100;
            clutchpercentint = Mathf.RoundToInt(clutchpercent);
            clutchpercentstr = "" + clutchpercentint + "%";
            Debug.Log("clutch pt % is = " + clutchpercentstr);
            Save.P6fgpercent = clutchpercentstr;

            if (x.buckets + x.misses == 0)
            {
                Save.P6fgs = "0/0";
                Save.P6fgpercent = "-";
            }
            if (x.threemissed + x.threes == 0)
            {
                Save.P6threes = "0/0";
                Save.P6threepercent = "-";
            }
            if (x.clutchbuckets + x.clutchmisses == 0)
            {
                Save.P6clutchpts = "0/0";
                Save.P6clutchpercent = "-";
            }





        }
        return Save;
    }
    
    public void GameSetNameButtonClicked()
    {
        SaveData save =  creatingSaveData();
        SaveIntoJson(save);
        SceneManager.LoadScene("StatsScreen");

    }


    public void SaveIntoJson(SaveData x)
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json") == false)
        {
            string gamedatajson = JsonUtility.ToJson(x);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/GamesSaved.json", gamedatajson);
        }
        else
        {
            string gamedatajson = JsonUtility.ToJson(x);
            System.IO.File.AppendAllText(Application.persistentDataPath + "/GamesSaved.json", "\n" + gamedatajson);
        }

        Master.GetComponent<Master>().setGameNumtoNew();

    }

    public void DelFile()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json"))
            System.IO.File.Delete(Application.persistentDataPath + "/GamesSaved.json");
    }

}

