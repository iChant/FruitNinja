using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreControl : MonoBehaviour {

	public Text scoreTxt;
	public int score = 0;

    private float lastScoreTime;
    private float currentTime;
    private static ScoreControl instance = null;

	void Awake(){
		instance = this;
	}

    void Start()
    {
        LastScoreTime = Time.time + 2.5f;
    }

	void Update () {
		scoreTxt.text = score + "";
        if (Time.time - LastScoreTime >= 5.0f && !ShowExitInGame.ifExitShowed)
        {
            MessageDispatcher.Instance.dispatchMessage(0.0f, Singleton.gameType, MessageType.Msg_ShowExitInGame, new Vector2(0, 0), 0);
            Debug.Log(LastScoreTime.ToString());
            LastScoreTime = Time.time;
        }
	}
	public static ScoreControl Instance{
		get{
			return instance;
		}
	}

    public float LastScoreTime
    {
        get
        {
            return lastScoreTime;
        }
        set
        {
            lastScoreTime = value;
        }
    }

    public float CurrentTime
    {
        get
        {
            return currentTime;
        }

        set
        {
            currentTime = value;
        }

    }
}
