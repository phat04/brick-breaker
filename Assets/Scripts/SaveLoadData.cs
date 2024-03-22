using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    LevelsConfig _levelsConfig;
    LevelSpawnController _levelSpawnController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData(int index, bool complete = true)
    {
        _levelsConfig.levelDatas[index] = complete;
        var json = JsonUtility.ToJson(_levelsConfig);

        PlayerPrefs.SetString("SaveData", json);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("SaveData"))
        {
            var json = PlayerPrefs.GetString("SaveData");
            _levelsConfig = JsonUtility.FromJson<LevelsConfig>(json);
            for (int i = 0; i < _levelSpawnController.stages.Count; i++)
            {
                if (_levelsConfig.levelDatas[i])
                {
                    //_levelSpawnController.UpdateStateStage(_levelSpawnController.stages[i]);
                }
                //_levelSpawnController.stages[i]_levelsConfig.levelDatas
            }
            
        }
    }
}
