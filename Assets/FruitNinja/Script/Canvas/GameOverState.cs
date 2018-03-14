using UnityEngine;


public class GameOverState : State {
	private PanelCenter pc;
	private static GameOverState instance = null;
    //private ScoreBoard scoreBoard;

	public ScoreElem score;

	void Awake(){
		instance = this;
	}
	public override void enter(){
        Debug.Log("GameOverState enter!");
        pc = PanelCenter.Instance;
        //scoreBoard = ScoreBoard.Instance;
        //scoreBoard.SetScoreList(score);
		pc.showGameOverPanel();
	}
	public override void execute(){
	}
	public override void exit(){
        Debug.Log("GameOverState exited!");
		Destroy (EntityManager.Instance.getEntityFromId (EntityType.GameOverEntity));
		EntityManager.Instance.removeEntity (EntityType.GameOverEntity);
		GestureListener.ifDetectGesture = false;
	}
	public override bool onMessage(Message msg){
		switch (msg.msg) {
		case MessageType.Msg_GotoMenu:
			pc.changeState(FirstPanelState.Instance);
			return true;
		case MessageType.Msg_Revert:
			pc.revertToPreviousState();
			return true;
		}
		return false;
	}
	public static GameOverState Instance{
		get{
			return instance;
		}
	}
}
