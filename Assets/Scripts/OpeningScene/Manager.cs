using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{

    Color colour;
    public int Counter;
    public int CanvasCounter;
    public Canvas HomeCanvas;
    public GameObject Master;
    public string path;
    public GameObject masterprefab;

    // Start is called before the first frame update
    void Start()
    {

        path = Application.persistentDataPath;

        if (GameObject.Find("Master") == null)
        {
            GameObject masternew = (GameObject)Instantiate(masterprefab, new Vector3(0, 0, 0), Quaternion.identity); 
            masternew.name = "Master";
            Master = masternew;

        }

        HomeCanvas.GetComponent<CanvasGroup>().alpha = 0f;
        


        Application.targetFrameRate = 20;
        Counter = 15;
    }


    // Update is called once per frame
    void Update()
    {
        if (HomeCanvas.GetComponent<CanvasGroup>().alpha != 1)
        
        FadeCanvas();
    }

    //fade canvas
    void FadeCanvas()
    {
        CanvasCounter++;

        if (CanvasCounter > 20)
            HomeCanvas.GetComponent<CanvasGroup>().alpha += 0.07f;

    }

    //rotate wallpaper
   
    public void openstats()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/GamesSaved.json"))
            SceneManager.LoadScene("SavedGames");
    }

}
