using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ViewLeaderBoards()
    {
        SceneManager.LoadScene("LeaderBoards");
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
