using UnityEngine;

public class GameOverState : State
{
    public void OnEnter(GameManager gameManager)
    {
        gameManager.gameStatusText.text = "Game Over!";

        Debug.Log("Entered Game Over state");
    }

    public void OnExit(GameManager gameManager)
    {
        Debug.Log("Exiting Game Over state");
    }

    public void OnUpdate(GameManager gameManager)
    {
    }
}
