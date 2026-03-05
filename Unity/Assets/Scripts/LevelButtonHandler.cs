using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonHandler : MonoBehaviour
{
    [SerializeField] private string levelName;
    
    
    // We need to subscribe to the LevelManager manully 
    // because LevelManager will be on the DontDestroyOnLoad scene
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            LevelManager.Instance.LoadLevel(levelName);
        });
    }
}
