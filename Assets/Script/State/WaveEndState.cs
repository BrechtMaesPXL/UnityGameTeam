using UnityEngine;

public class WaveEndState : State
{
    public void OnEnter(GameManager gameManager)
    {

        gameManager.gameStatusText.text = "Wave Complete! Take a breather."; 
        gameManager.NextWave();   
        Debug.Log("Entered wave end state");
    }

    public void OnExit(GameManager gameManager)
    {
        Debug.Log("Exiting wave end state");
    }

    public void OnUpdate(GameManager gameManager)
    {
    }
}
