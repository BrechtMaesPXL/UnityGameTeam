using System;
using System.Collections.Generic;
using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputActionReference pauseReference;
    public TextMeshProUGUI gameStatusText;

    // public GameState CurrentState { get; set; } = GameState.Start;


    State currentState;
    public State CurrentState => currentState;


    [Header("GameStater")]

    private State startState = new StartState();
    private State playingState = new PlayingState();
    private State pausedState = new PausedState();
    private State gameOverState = new GameOverState();
    private static State waveEndState = new WaveEndState();

    [Header("Waves")]

    private int currentWave = 0;
    public TextMeshProUGUI waveText;
    public EnemyBaraks baraks;
    public UnityEngine.Canvas waveCanvas;




    void Awake()
    {
        waveCanvas.enabled = true; 
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Start the game in StartState
        SetState(startState);
    }

    void Update()
    {
        currentState?.OnUpdate(this);

        if (pauseReference.action.WasPressedThisFrame())
        {
            TogglePause();
        }
    }

    public void SetState(State newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }

    public void TogglePause()
    {
        if (currentState == playingState)
        {
            SetState(pausedState);
        }
        else if (currentState == pausedState)
        {
            SetState(playingState);
        }
    }

    // You can expose helpers
    public void StartGame() => SetState(playingState);
    public void GameOver() => SetState(gameOverState);
    public void WaveEnd() => SetState(waveEndState);

    public void NextWave()
    {
        currentWave++;
        UpdateWave();
    } 

    public void UpdateWave() => waveText.text = "Day " + currentWave;

    public int returnWave() => currentWave;

    internal void PauseGame() => SetState(pausedState);
}