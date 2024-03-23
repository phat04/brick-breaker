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
        if (transform.GetChild(0).GetComponent<Text>().text == "Tutorial")
        {
            SceneManager.LoadScene(0);
            return;
        }
        int indexScene = int.Parse(transform.GetChild(0).GetComponent<Text>().text) - 1;
        Debug.Log(PlayerPrefs.GetInt("CurrentCompleteStage") + 1);
        if (indexScene > PlayerPrefs.GetInt("CurrentCompleteStage") + 1)
        {
            Debug.Log("Can not Play, Please complete before stage");
            return;
        }
        SceneManager.LoadScene(indexScene);
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
