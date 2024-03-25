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
        if (transform.GetChild(0 + 3).GetComponent<Text>().text == "Tutorial")
        {
            SceneManager.LoadScene(0);
            return;
        }
        int numberLevel = int.Parse(transform.GetChild(0 + 3).GetComponent<Text>().text);
        Debug.Log(PlayerPrefs.GetInt("CurrentCompleteStage") + 1);
        if (numberLevel > PlayerPrefs.GetInt("CurrentCompleteStage") + 1)
        {
            Debug.Log("Can not Play, Please complete before stage");
            return;
        }
        //SceneManager.LoadScene(numberLevel - 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
