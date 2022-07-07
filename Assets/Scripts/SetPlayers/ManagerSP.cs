using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerSP : MonoBehaviour
{
    public GameObject Master;
    public GameObject SPCanvas;
    public GameObject fives;
    public GameObject fours;
    public GameObject threes;


    void Start()
    {
        Master = GameObject.Find("Master");

        Master.GetComponent<Master>().Players.Clear();

        if (Master.GetComponent<Master>().PlayerNums == 3)
        {
            threes.SetActive(true);
        }
        else if (Master.GetComponent<Master>().PlayerNums == 4)
        {
            fours.SetActive(true);
        }
        else if (Master.GetComponent<Master>().PlayerNums == 5)
        {
            fives.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CancelButton()
    {
        SceneManager.LoadScene("OpenScreen");
    }

    public void StartButton()
    {
        int players = Master.GetComponent<Master>().PlayerNums;

        if(players == 3)
        {
            Master.GetComponent<Master>().Players.Add(threes.transform.Find("ThreesP1").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(threes.transform.Find("ThreesP2").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(threes.transform.Find("ThreesP3").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(threes.transform.Find("ThreesP4").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(threes.transform.Find("ThreesP5").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(threes.transform.Find("ThreesP6").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
        }

        else if (players == 4)
        {
            Master.GetComponent<Master>().Players.Add(fours.transform.Find("FoursP1").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fours.transform.Find("FoursP2").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fours.transform.Find("FoursP3").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fours.transform.Find("FoursP4").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fours.transform.Find("FoursP5").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fours.transform.Find("FoursP6").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fours.transform.Find("FoursP7").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fours.transform.Find("FoursP8").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
        }

        else if (players == 5)
        {
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP1").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP2").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP3").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP4").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP5").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP6").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP7").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP8").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP9").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
            Master.GetComponent<Master>().Players.Add(fives.transform.Find("FivesP10").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text);
        }

        SceneManager.LoadScene("Game");
    }


}
