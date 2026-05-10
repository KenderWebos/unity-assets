using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        MainMenu,
        Loading,
        Playing,
        Paused,
        GameOver
    }

    [Header("Game State")]
    public GameState CurrentState { get; private set; }
    public UnityEvent<GameState> OnGameStateChanged;

    [Header("Game Settings")]
    public bool isRunning = true;
    public float gameTimeScale = 1f;
    public bool autoSaveEnabled = true;
    public float autoSaveInterval = 300f; // 5 minutos

    [Header("References")]
    public SaveSystem saveSystem;
    public EventSystem eventSystem;

    private float lastAutoSaveTime;

    private void Awake()
    {
        MakeSingleton();
        InitializeManagers();
    }

    private void Start()
    {
        SetGameState(GameState.MainMenu);
        lastAutoSaveTime = Time.time;
    }

    private void Update()
    {
        if (autoSaveEnabled && Time.time - lastAutoSaveTime >= autoSaveInterval)
        {
            AutoSave();
        }
    }

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeManagers()
    {
        if (saveSystem == null) saveSystem = GetComponent<SaveSystem>();
        if (eventSystem == null) eventSystem = GetComponent<EventSystem>();
    }

    public void SetGameState(GameState newState)
    {
        if (CurrentState == newState) return;

        GameState previousState = CurrentState;
        CurrentState = newState;

        switch (newState)
        {
            case GameState.Playing:
                Time.timeScale = gameTimeScale;
                isRunning = true;
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                isRunning = false;
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                isRunning = false;
                break;
        }

        OnGameStateChanged?.Invoke(newState);
        Debug.Log($"Game State changed from {previousState} to {newState}");
    }

    public void PauseGame()
    {
        SetGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        SetGameState(GameState.Playing);
    }

    public void GameOver()
    {
        SetGameState(GameState.GameOver);
    }

    private void AutoSave()
    {
        if (saveSystem != null)
        {
            saveSystem.SaveGame();
            lastAutoSaveTime = Time.time;
            Debug.Log("Game auto-saved");
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void OnApplicationQuit()
    {
        if (autoSaveEnabled)
        {
            AutoSave();
        }
    }
}
