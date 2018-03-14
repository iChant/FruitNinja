using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreBoardController : MonoBehaviour
{

    //private StateMachine stateMachine;
    private static ScoreBoardController instance = null;
    private List<ScoreElem> scoreList;
    private int currentScoreId;

    public RawImage kinectImg;
    public List<Text> indice;
    public List<Text> scores;
    public List<Text> dates;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        scoreList = ScoreBoard.Instance.ScoreList;
        if (scoreList.Count > 1)
            for (int i = 0; i < scoreList.Count - 1; ++i)
            {
                indice[i].gameObject.SetActive(true);
                scores[i].gameObject.SetActive(true);
                scores[i].text = scoreList[i].Score.ToString();
                dates[i].gameObject.SetActive(true);
                dates[i].text = scoreList[i].Date.ToString();
            }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static ScoreBoardController Instance
    {
        get
        {
            return instance;
        }
    }

}
