using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private readonly string GAME_OVER_SCENE_NAME = "Scenes/GameOver";
    private readonly int NUMBER_OF_GAME_LEVELS = 3;
    
    // UI elements
    [SerializeField] int blocksCounter;

    // state
    private SceneLoader _sceneLoader;

    private SaveLoadData _saveLoadData;
    
    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void IncrementBlocksCounter()
    {
        blocksCounter++;
    }
    
    public void DecrementBlocksCounter()
    {
        blocksCounter--;

        if (blocksCounter <= 0)
        {
            var gameSession = GameSession.Instance;
            
            // check for game over
            /*if (gameSession.GameLevel >= NUMBER_OF_GAME_LEVELS)
            {
                _sceneLoader.LoadSceneByName(GAME_OVER_SCENE_NAME);
            }*/

            // increases game level
            gameSession.GameLevel++;

            PlayerPrefs.SetInt("CurrentCompleteStage", SceneManager.GetActiveScene().buildIndex + 1);// save current stage is complete

            _sceneLoader.LoadLevelMapScene();
        }
    }
    
}
