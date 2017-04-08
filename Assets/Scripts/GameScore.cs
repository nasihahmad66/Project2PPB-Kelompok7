using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour {

    public Text ScoreTextUI;
    public Text bestScore;

	public int score;

	public int Score{
		get{ 
		
			return this.score;
		}
		set
		{
            this.score = value;
            UpdateScoreTextUI();
		
		}
	
	}
	// Use this for initialization
	void Start () {


        ScoreTextUI = GetComponent<Text>();
        

    }

	void UpdateScoreTextUI()
	{
        int BestScore = PlayerPrefs.GetInt("BestScore", 0);
        string scoreStr = string.Format("{0:0}", score);
        ScoreTextUI.text = scoreStr;
        if(score > BestScore)
        {
            PlayerPrefs.SetInt("BestScore",score);
        }
	}
}
