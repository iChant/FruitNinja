using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaxScoreController : MonoBehaviour {

    private ScoreBoard scoreBoard;

    public Text maxScoreText;

    void Awake()
    {
        scoreBoard = ScoreBoard.Instance;
    }

	// Use this for initialization
	void Start () {
        if (scoreBoard.ScoreList.Count == 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            Debug.Log(scoreBoard.ScoreList.Count);
            maxScoreText.text = scoreBoard.ScoreList[0].Score.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
