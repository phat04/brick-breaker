using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    [SerializeField] List<GameObject> typeOfRocks;
    [SerializeField] Transform blocks;
    [SerializeField] string fileName;

    public List<int> list = new List<int>();
    public static ReadCSV Instance;

    int currentIndex = 0, currentRow = 0;
    GameObject clonedRock;
    private float maxXAxis = 15.5f, minYAxis = 0.5f;
    private int maxIndexInRow = 15;

    void Awake()
    {
        Instance = this;
        if (ObjectPool.Instace != null)
        {
            ReadCSVFile(ObjectPool.Instace.currentlevel.ToString());
            Debug.Log("current Stage " + ObjectPool.Instace.currentlevel.ToString());
        }
        else
        {
            ReadCSVFile("1");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        UseBlock();
        /*Debug.Log("Element Qauntity: " + list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log("element " + i + ": " + list[i]);
        }*/
    }

    void ReadCSVFile(string index)
    {
        string needFileName = "";
        var curentFolder = Directory.GetCurrentDirectory();
        //Debug.LogError("curentFolder: " + curentFolder);
        var childFolder = Directory.GetDirectories(curentFolder);
        List<string> childFile = new List<string>();
        for (int i = 0; i < childFolder.Length; i++)
        {
            //Debug.LogError(childFolder[i]);
            if (childFolder[i].Contains("Assets"))
            {
                childFolder = Directory.GetDirectories(childFolder[i]);
                break;
            }
        }

        for (int i = 0; i < childFolder.Length; i++)
        {
            if (childFolder[i].Contains("ContentFiles"))
            {
                childFile = Directory.GetFiles(childFolder[i]).ToList();
                break;
            }
        }

        foreach (var file in childFile)
        {
            //Debug.LogError(Path.GetFileNameWithoutExtension(file));
            if (Path.GetFileNameWithoutExtension(file) == "level" + index)
            {
                needFileName = file;
                //Debug.LogError("file: " + needFileName);
                break;
            }
        }

        /*if (File.Exists(childFolder[i]))
        {

        }*/

        if (string.IsNullOrEmpty(needFileName))
        {
            Debug.LogError($"Can not find file with level{index}");
            return;
        }

        StreamReader strReader = new StreamReader(needFileName);
        bool endOfFile = false;

        while (!endOfFile)
        {
            string data_string = strReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }

            var data_values = data_string.Split(',');
            //Debug.Log(data_values.Length);
            int result;
            for (int i = 0; i < data_values.Length; i++)
            {
                if (int.TryParse(data_values[i], out result))
                {
                    list.Add(result);
                }
            }
            /*for (int i = 0;i < list.Count; i++)
            {
                Debug.Log("Value " + i.ToString() + ": " + list[i].ToString());
            }*/
        }
    }

    void UseBlock()
    {
        var instance = new GameObject();
        for (int i = list.Count - 1; i >= 2; i--)
        {
            switch (list[i])
            {
                case 0:
                    clonedRock = typeOfRocks[0];
                    break;
                case 1:
                    clonedRock = typeOfRocks[1];
                    break;
                case 2:
                    clonedRock = typeOfRocks[2];
                    break;
                case -1:
                    clonedRock = typeOfRocks[3];
                    break;
                default:
                    clonedRock = typeOfRocks[0];
                    ;
                    break;
            }

            instance = ObjectPool.Instace ? ObjectPool.Instace.GetObjectFromPool(clonedRock) : null;
            if (instance != null && instance.GetComponent<Block>() != null)
            {
                instance.GetComponent<Block>().ResetState();
                instance.GetComponent<Block>().SetPositionItself(new Vector2(maxXAxis - currentIndex, currentRow + minYAxis));
                instance.transform.SetParent(blocks);
            } 
            else
            {
                Instantiate(clonedRock, new Vector2(maxXAxis - currentIndex, currentRow + minYAxis), Quaternion.identity, blocks);
            }

            currentIndex++;
            if (currentIndex > maxIndexInRow)
            {
                currentIndex = 0;
                currentRow++;
            }
        }
    }
}
