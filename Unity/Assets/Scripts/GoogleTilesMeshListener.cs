using CesiumForUnity;
using UnityEngine;
using System;


public class GoogleTilesMeshListener : MonoBehaviour
{
    public Cesium3DTileset tileset;
    public float loadingTimeout = 5f; // seconds
    public GameObject player;

    private float timeSinceLastTile = 0f;
    private bool loadingComplete = false;
    private LevelManager _levelManager;

    void OnEnable()
    {
        loadingComplete = false;
        timeSinceLastTile = 0f;
        if (tileset != null)
            tileset.OnTileGameObjectCreated += OnTileLoaded;
    }

    void OnDisable()
    {
        if (tileset != null)
            tileset.OnTileGameObjectCreated -= OnTileLoaded;
    }

    private void Start()
    {
        _levelManager = LevelManager.Instance;
    }

    private void OnTileLoaded(GameObject tileGameObject)
    {
        Debug.Log("Google 3D tile mesh loaded: " + tileGameObject.name);
        timeSinceLastTile = 0f;
        loadingComplete = false;
    }

    void Update()
    {
        if (!loadingComplete)
        {
            timeSinceLastTile += Time.deltaTime;
            if (timeSinceLastTile >= loadingTimeout)
            {
                loadingComplete = true;
                Debug.Log("Level loading complete!");
               
                if(player != null)
                    player.SetActive(true);

                _levelManager.SetLoadingScreenState(false);
                Destroy(gameObject); 
            }
        }
    }
}