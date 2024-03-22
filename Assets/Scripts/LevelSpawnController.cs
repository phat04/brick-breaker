using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSpawnController : MonoBehaviour
{
    [SerializeField] Image stageImage;
    [SerializeField] int maxNumberSpawn = 40;

    public List<Image> stages = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        Image intance;
        for (int i = 0; i < maxNumberSpawn; i++)
        {
            intance = Instantiate(stageImage, transform);
            stages.Add(intance);
            if (i != 0)
            {
                DefaultStateStage(intance);
            }
        }


        var currentStageInRown = 1;
        var currentRown = 0;
        stages[0].transform.GetChild(0).GetComponent<Text>().text = "Tutorial";
        for (int i = 1;i < stages.Count; i++) 
        {
            if (currentRown % 2 == 0)
            {
                stages[i].transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();// Pass level number for Stage Number Txt
            }
            else
            {
                stages[i].transform.GetChild(0).GetComponent<Text>().text = (i + 4 - currentStageInRown * 2).ToString();// Pass level number for Stage Number Txt
            }

            currentStageInRown++;
            if (currentStageInRown > 3)
            {
                currentRown++;
                currentStageInRown = 0;
            }
        }

        if (PlayerPrefs.HasKey("CurrentCompleteStage"))
        {
            for (int i = 1; i < stages.Count; i++)
            {
                if (int.Parse(stages[i].transform.GetChild(0).GetComponent<Text>().text) <= PlayerPrefs.GetInt("CurrentCompleteStage"))
                {
                    WinStateStage(stages[i]);
                }
            }

            UnLocksStateStage(stages[PlayerPrefs.GetInt("CurrentCompleteStage") + 1]);
        }
        else
        {
            UnLocksStateStage(stages[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinStateStage(Image stage)
    {
        stage.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        stage.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        stage.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        stage.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void DefaultStateStage(Image stage)
    {
        stage.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        stage.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        stage.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        stage.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    public void UnLocksStateStage(Image stage)
    {
        stage.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        stage.transform.GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        stage.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        stage.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
