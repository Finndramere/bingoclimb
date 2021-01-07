using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineHighscores : MonoBehaviour
{
    // Start is called before the first frame update
    const string privateCode = "o5vFmoZzUUmOaGLNbjCPUA94LbLdrOVEa7g8ytNzsRfQ";
    const string publicCode = "5ff06bc30af2690f14bc7be4";
    const string webURL = "http://dreamlo.com/lb/";


	DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;
	static OnlineHighscores instance;
	//private static OnlineHighscores playerInstance;

	void Awake()
	{
		highscoreDisplay = GetComponent<DisplayHighscores>();
		instance = this;

        //AddNewHighscore("Robert", 1234);
        //AddNewHighscore("Robert1", 12345);
        //AddNewHighscore("Robert2", 12343);

        //if (instance != null)
        //{
        //    Destroy(transform.gameObject);
        //}
        //else
        //{
        //    instance = this;
        //    DontDestroyOnLoad(transform.gameObject);
        //}

        //DontDestroyOnLoad(transform.gameObject);

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

	public static void AddNewHighscore(string username, int score)
	{
		instance.StartCoroutine(instance.UploadNewHighscore(username, score));
	}

	IEnumerator UploadNewHighscore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			print("Upload Successful");
			DownloadHighscores();
		}
		else
		{
			print("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			FormatHighscores(www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else
		{
			print("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username, score);
			print(highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}
}
