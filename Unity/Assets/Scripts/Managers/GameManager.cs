using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject optionsMenu;
    public delegate void GameStateChanged();
    public event GameStateChanged OnGameStateChanged;

    public enum GameState
    {
        SetingUp,
        Simulation,
        CameraView
    }

    private GameState _currentGameState = GameState.SetingUp;

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            if (_currentGameState != value)
            {
                _currentGameState = value;
                // Trigger the delegate when state changes
                OnGameStateChanged?.Invoke();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }

        if (optionsMenu.activeSelf)
        {
            Time.timeScale = 0f; // Pause the game when options menu is active
        }
        else
        {
            Time.timeScale = 1f; // Resume normal timescale when option menu is inactive
        }
    }

    public void GoToMainMenu()
    {
        // If the current level is MainMenu, do nothing
        if (SceneManager.GetActiveScene().name == "MainMenu")
            return;

        //Disable ui
        optionsMenu.SetActive(false);

        //Resume game time
        Time.timeScale = 1f;
		
		// Disable Agents Logic
		_currentGameState = GameState.SetingUp;
		
        //Load main menu
        LevelManager.Instance.LoadLevel("MainMenu");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}

