using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int GameID;
    public GameObject manager;
    void Start()
    {
        manager = GameObject.Find("SavedGamesManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Home()
    {
        SceneManager.LoadScene("OpenScreen");
    }
  
    public void LoadGame()
    {
        manager.GetComponent<SGManager>().Master.GetComponent<Master>().GameNum = this.GetComponent<GameButton>().GameID;
        SceneManager.LoadScene("StatsScreen");
    }

    public void DelClicked()
    {
        
       manager.GetComponent<SGManager>().currentDel = this.transform.GetComponent<GameButton>().GameID;
       manager.GetComponent<SGManager>().DeleteImage.SetActive(true);
    }

    

}
