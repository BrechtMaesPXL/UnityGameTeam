using UnityEngine;

public class WaveEndState : State
{
    public void OnEnter(GameManager gameManager)
    {
        gameManager.waveCanvas.gameObject.SetActive(true);

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
