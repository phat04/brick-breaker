using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSpawnController : MonoBehaviour
{
    [SerializeField] Image stageImage;
    [SerializeField] int maxNumberSpawn = 40;

    List<Image> stages = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        Image intance;
        for (int i = 0; i < maxNumberSpawn; i++)
        {
            intance = Instantiate(stageImage, transform);
            stages.Add(intance);
        }

        var currentStageInRown = 1;
        var currentRown = 0;
        stages[0].transform.GetChild(0).GetComponent<Text>().text = "Tutorial";
        for (int i = 1;i < stages.Count; i++) 
        {
            if (currentRown % 2 == 0)
            {
                stages[i].transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            }
            else
            {
                stages[i].transform.GetChild(0).GetComponent<Text>().text = (i + 4 - currentStageInRown * 2).ToString();
            }
            currentStageInRown++;
            if (currentStageInRown > 3)
            {
                currentRown++;
                currentStageInRown = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
