using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject PlayerGo;
    public GameObject EnemySpawnerRand;
    public GameObject GameOver;
    public GameObject scoreTextUIGO;
    public Text TextBestScore;
    public GameObject PausPanel;
    public GameObject MainFrame;
    public Text finalScoreText;
    GameObject score;
    int skor;
	public AudioClip sound;



    public enum GameManagerState
    {
        GamePlay,
        GameOver,
    }

    GameManagerState GMState;

    void Start()
    {
        Time.timeScale = 1;

        PlayerGo.GetComponent<PlayerController>().Init();


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (GMState)
            {
                case GameManagerState.GamePlay:
                    Time.timeScale = 0;
                    PausPanel.SetActive(true);
                    break;
                case GameManagerState.GameOver:
                    SceneManager.LoadScene(0);
                    break;

            }
        }
        score = GameObject.Find("ScoreTextUI");
        skor = score.GetComponent<GameScore>().Score;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
		case GameManagerState.GamePlay:
			PlayerGo.GetComponent<PlayerController>().Init();
			TextBestScore.text = PlayerPrefs.GetInt( "BestScore", 0 ).ToString( "0" );
			scoreTextUIGO.GetComponent<GameScore>().Score = 0;
			PlayerGo.SetActive( true );
			Time.timeScale = 1;
			GetComponent<AudioSource>().PlayOneShot(sound);
                break;
		case GameManagerState.GameOver:
                finalScoreText.text = skor.ToString();
                Debug.Log(skor);
                TextBestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString("0");
                GameOver.SetActive(true);
                MainFrame.SetActive(false);
                PlayerGo.SetActive(false);
			GetComponent<AudioSource>().Stop();
                break;

        }
    }
    public void SetGameManagerState(GameManagerState state )
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void StarGamePlay()
    {
        GMState = GameManagerState.GamePlay;
        skor = 0;
        UpdateGameManagerState();
        GameOver.SetActive(false);
        MainFrame.SetActive(true);
    }
    public void changeToScene(int ChangeScene)
    {
        SceneManager.LoadScene(ChangeScene);
    }
    public void onExit()
    {
        Application.Quit();
    }
}
