using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ShowExitInGame : MonoBehaviour
{
    public GameObject exitTip;
    public Text timeText;

    private int showExitTime;
    private float currentTime = 0.0f;

    public static bool ifExitShowed = false;


    private static ShowExitInGame instance = null;

    // Use this for initialization
    void Start()
    {
        instance = this;
        exitTip.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (ifExitShowed)
        {
            timeText.text = showExitTime.ToString();
            //float currentTime = Time.time;
            if (Time.time - currentTime >= 1.0f)
            {
                showExitTime--;
                currentTime = Time.time;
                Debug.Log("CurrentTime " + showExitTime.ToString());
            }
            if (showExitTime == 0)
            {
                ifExitShowed = false;
                exitTip.SetActive(false);
                MessageDispatcher.Instance.dispatchMessage(0.0f, Singleton.gameType,
                    MessageType.Msg_GameOver, new Vector2(0, 0), ScoreControl.Instance.score);
            }
        }

    }

    public void ShowExitTip()
    {
        showExitTime = 5;
        exitTip.SetActive(true);
        ifExitShowed = true;
        currentTime = Time.time;
    }

    public float HideExitTip()
    {
        exitTip.SetActive(false);
        ifExitShowed = false;
        return Time.time;   // Return time to update `last score time'.
    }

    public static ShowExitInGame Instance
    {
        get
        {
            return instance;
        }
    }
}
