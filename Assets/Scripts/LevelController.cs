using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private readonly string GAME_OVER_SCENE_NAME = "Scenes/GameOver";
    private readonly int NUMBER_OF_GAME_LEVELS = 3;

    public static LevelController Instance;

    // UI elements
    /*[SerializeField] *///int blocksCounter = 0;

    public int BlocksCounter;
    // state
    private SceneLoader _sceneLoader;

    [SerializeField] private ReadCSV readCSV;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        BlocksCounter = 0;
}

    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
        readCSV.UseBlock();
        Debug.Log("block quantity: " + BlocksCounter);
    }

    /*public void IncrementBlocksCounter()
    {
        BlocksCounter++;
    }*/
    
    public void DecrementBlocksCounter()
    {
        BlocksCounter--;
        Debug.LogError("Colider");

        if (BlocksCounter <= 0)
        {
            var gameSession = GameSession.Instance;
            
            // check for game over
            /*if (gameSession.GameLevel >= NUMBER_OF_GAME_LEVELS)
            {
                _sceneLoader.LoadSceneByName(GAME_OVER_SCENE_NAME);
            }*/

            // increases game level
            gameSession.GameLevel++;

            if (gameSession.GameLevel > PlayerPrefs.GetInt("CurrentCompleteStage") || !PlayerPrefs.HasKey("CurrentCompleteStage"))
            {
                PlayerPrefs.SetInt("CurrentCompleteStage", gameSession.GameLevel);// save current stage is completed
            }
            Debug.LogError("complee" + $" blockcounter: {BlocksCounter}");
            _sceneLoader.LoadLevelMapScene();
        }
    }
    
}
