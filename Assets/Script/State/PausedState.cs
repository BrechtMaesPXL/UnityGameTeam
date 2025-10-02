using UnityEngine;

public class PausedState : State
{
    public void OnEnter(GameManager gameManager)
    {
        gameManager.gameStatusText.text = "Need a sec to recover, no problem.";
        Debug.Log("Game Paused");
    }

    public void OnExit(GameManager gameManager)
    {
        Debug.Log("Resuming game");
    }

    public void OnUpdate(GameManager gameManager)
    {
    }
}
