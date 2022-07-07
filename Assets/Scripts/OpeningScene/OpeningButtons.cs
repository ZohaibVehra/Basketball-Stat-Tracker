using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OpeningButtons : MonoBehaviour
{
    public Button NewGame;
    public Button SavedGames;
    public bool Newhold;
    public bool Savedhold;
    public Canvas NewGameCanvas;
    public GameObject NewGameCanvasGO;
    public GameObject NewGameButtonGO;
    public GameObject SavedGamesButtonGO;

    Color held;
    Color letgo;
    // Start is called before the first frame update
    void Start()
    {
        Newhold = false;
        Savedhold = false;
        held = NewGame.image.color;
        letgo = held;
        held.r = 56;
        held.g = 56;
        held.b = 56;

    }

    // Update is called once per frame
    void Update()
    {

        if(Newhold)
        {
            NewGame.image.color = held;
        }
        else
        {
            NewGame.image.color = letgo;
        }
        if (Savedhold)
        {
            SavedGames.image.color = held;
        }
        else
        {
            SavedGames.image.color = letgo;
        }
    }

    public void NewButtonHeld()
    {
        Newhold = true;
    }
    public void NewButtonLetGo()
    {
        Newhold = false;
    }
    public void SavedButtonHeld()
    {
        Savedhold = true;
    }
    public void SavedButtonLetGo()
    {
        Savedhold = false;
    }

    
    public void SetNewGameCanvasActive()
    {
        NewGameCanvasGO.SetActive(true);
        NewGameButtonGO.SetActive(false);
        SavedGamesButtonGO.SetActive(false);
    }

    public void CancelNewGames()
    {
        NewGameCanvasGO.SetActive(false);
        NewGameButtonGO.SetActive(true);
        SavedGamesButtonGO.SetActive(true);
    }

    public void RunThrees()
    {
        GameObject.Find("Master").GetComponent<Master>().PlayerNums = 3;
        SceneManager.LoadScene("SetPlayers");
    }
    public void RunFours()
    {
        GameObject.Find("Master").GetComponent<Master>().PlayerNums = 4;
        SceneManager.LoadScene("SetPlayers");
    }
    public void RunFives()
    {
        GameObject.Find("Master").GetComponent<Master>().PlayerNums = 5;
        SceneManager.LoadScene("SetPlayers");
    }

}
