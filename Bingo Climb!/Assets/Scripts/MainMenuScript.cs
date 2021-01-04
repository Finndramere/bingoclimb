using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private GameObject canvas;
    private GameObject mainmenu;
    //public Button Lbutton;
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    // Start is called before the first frame update

    //void Start()
    //{
    //    canvas = GameObject.Find("HighscoresCanvas");
    //    canvas.SetActive(false);
    //}
    //void Update()
    //{
    //    canvas = GameObject.Find("HighscoresCanvas");
    //    mainmenu = GameObject.Find("MainMenu");
    //    //Lbutton = GameObject.Find("Leaderboards Btn").GetComponent<Button>();
    //    //Lbutton.onClick.AddListener(TaskOnClick);
    //}

    


    
    //void TaskOnClick()
    //{
    //    canvas.SetActive(true);
    //    mainmenu.SetActive(false);
    //}
}
