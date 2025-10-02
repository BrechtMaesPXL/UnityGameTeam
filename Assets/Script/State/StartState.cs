using UnityEngine;

public class StartState : State
{
    public void OnEnter(GameManager gameManager)
    {
        gameManager.gameStatusText.text = "Clock in for your shift";
        Debug.Log("Entered Start State");
    }

    public void OnExit(GameManager gameManager)
    {
        gameManager.gameStatusText.text = "";
        GameManager.Instance.NextWave();
        GameManager.Instance.UpdateWave();
        Debug.Log("exeted Start State");
    }

    public void OnUpdate(GameManager gameManager)
    {
    }
}
