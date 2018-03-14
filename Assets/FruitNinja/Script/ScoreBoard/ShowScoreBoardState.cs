using UnityEngine;
using System.Collections;

public class ShowScoreBoardState : State
{
    private static ShowScoreBoardState instance;
    private GameOverListener gameOverListener;
    private ImageToUserMap imageToUserMap;

    void Awake()
    {
        instance = this;
        
    }

    public override void enter()
    {
        gameOverListener = GameOverListener.Instance;
        gameOverListener.scoreBoardPanel.SetActive(true);
        //imageToUserMap.kinectImg = ScoreBoardController.Instance.kinectImg;
        //base.enter();
    }

    public override void execute()
    {
        base.execute();
    }
    //
    public override void exit()
    {
        gameOverListener.scoreBoardPanel.SetActive(false);
        //imageToUserMap.kinectImg = gameOverListener.kinectImg;
    }

    public override bool onMessage(Message msg)
    {
        switch (msg.msg)
        {
            case MessageType.Msg_Right:
            case MessageType.Msg_SwipeRight:
                gameOverListener.changeState(GameOverMenuState.Instance);
                return true;
            default:
                return false;
        }
    }

    public static ShowScoreBoardState Instance
    {
        get
        {
            return instance;
        }
    }
}
