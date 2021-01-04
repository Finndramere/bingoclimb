using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{
	public Text[] highscoreFields;
	OnlineHighscores highscoresManager;

    //private static DisplayHighscores playerInstance;


    void Awake()
    {
        //DontDestroyOnLoad(this);

        //if (playerInstance == null)
        //{
        //    playerInstance = this;
        //}
        //else
        //{
        //    Destroy(transform.gameObject);
        //}

       

    }

    void Start()
	{
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". Fetching...";
        }


        highscoresManager = GetComponent<OnlineHighscores>();
        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList) {
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
	}

	IEnumerator RefreshHighscores()
	{
		while (true)
		{
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}
}
