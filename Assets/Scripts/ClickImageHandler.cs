using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickImageHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click image");
        //Load Leve1
        if (transform.GetChild(0 + 3).GetComponent<Text>().text == "Tutorial")
        {
            SceneManager.LoadScene(0);
            return;
        }
        int choseLevelNumber = int.Parse(transform.GetChild(0 + 3).GetComponent<Text>().text);
        Debug.Log(PlayerPrefs.GetInt("CurrentCompleteStage") + 1);

        if (isLockStage(choseLevelNumber))
        {
            Debug.Log("Can not Play, Please complete before stage");
            return;
        }

        ObjectPool.Instace.currentlevel = choseLevelNumber;
        SceneManager.LoadScene(0);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isLockStage(int index)
    {
        return index > PlayerPrefs.GetInt("CurrentCompleteStage") + 1;
    }
}
