using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCtrl : MonoBehaviour {


    private int Score = 0;
    public Text ScoreText = null;

	// Use this for initialization
	void Start () {
        ScoreUp(0);
	}
	
	// Update is called once per frame
	public void ScoreUp(int iScore) {
        Score += iScore;
        ScoreText.text = "점수 : " + Score.ToString();

    }
}
