using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    // Event to notify when a level is fully loaded (scene + assets)
    public event Action<string> OnLevelCompleted;

    private GameObject _loadingScreen;
	private GameManager _gameManager;
    private string _currentLevelName;
    private bool _sceneLoadingComplete = false;

    private void Start()
    {
		_gameManager = GameManager.Instance;
        _loadingScreen = transform.GetChild(0).gameObject;  
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel(string levelName)
    {
        // Enable agent logic
		if(levelName.Equals("CarSimulator"))
			_gameManager.CurrentGameState = GameManager.GameState.Simulation;
        
        _currentLevelName = levelName;
        _sceneLoadingComplete = false;
        Debug.Log($"Loading level: {levelName}");
        StartCoroutine(LoadLevelAsync(levelName));
    }

    public void ReloadCurrentLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);
        }
    }

    public void LoadPreviousLevel()
    {
        int prevSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (prevSceneIndex >= 0)
        {
            LoadLevel(SceneManager.GetSceneByBuildIndex(prevSceneIndex).name);
        }
    }

    public IEnumerator LoadLevelAsync(string levelName)
    {
        // Show loading screen
        if (_loadingScreen != null)
            _loadingScreen.SetActive(true);
        
        // Start async operation to load the scene
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName);
        
        // Wait until the scene fully loads
        while (!asyncOperation.isDone)
        {
            // You can access loading progress with asyncOperation.progress (0 to 1)
            yield return null;
        }
        
        _sceneLoadingComplete = true;
        
        // Hide loading screen when scene is done
        // Note: Google Tile loading may still be in progress
        //if (_loadingScreen != null)
        //    _loadingScreen.SetActive(false);
            
        // Trigger the event if no Google tile loading is expected
        NotifyLevelCompleted();
    }
    
    // Call this method when all loading is finished (scene + any additional assets)
    public void NotifyLevelCompleted()
    {
        if (!_sceneLoadingComplete)
            return;
            
        // Invoke the event
        OnLevelCompleted?.Invoke(_currentLevelName);
        Debug.Log($"Level completed: {_currentLevelName}");
    }

    public void SetLoadingScreenState(bool state)
    {
        if (_loadingScreen != null)
            _loadingScreen.SetActive(state);
    }
}
