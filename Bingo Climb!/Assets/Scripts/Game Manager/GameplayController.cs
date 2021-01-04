using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    
    // Start is called before the first frame update
    //[SerializeField] private HighscoreTable highscoreTable;

    private Text scoreText;
    private Text scoreSubmitted;
    private InputField textInput;
    private Button submitbutton;
    private int score;
    private string playername;

    public GameObject scorePanel;

    public Text endScore;
    public Animator endPanelAnim;
    
    void Awake()
    {
        MakeInstance();
        
    }

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();   
        textInput = GameObject.Find("NameInputField").GetComponent<InputField>();
        submitbutton = GameObject.Find("Submit").GetComponent<Button>();
        StartCoroutine(CountScore());
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.1f);
        score++;
        scoreText.text = score.ToString();

        StartCoroutine(CountScore());
    }

    public void GameOver()
    {
        scorePanel.SetActive(false);
        endScore.text = "Score: " + score;
        endPanelAnim.Play("EndPanel");
    }

    public void Again()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void AddScore(int addscore)
    {
        score += addscore;
    }

    public void SubmitScore()
    {
        playername = textInput.text;
        OnlineHighscores.AddNewHighscore(playername, score);
        Debug.Log("OnlineScore Recorded");

        submitbutton.interactable = false;

        textInput.interactable = false;

    }
}
