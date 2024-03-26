using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        Debug.Log("Element Qauntity: " + list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log("element " + i + ": " + list[i]);
        }
    }

    void ReadCSVFile(string index)
    {
        StreamReader strReader = new StreamReader("D:\\InternUnity\\brick-breaker\\Assets\\ContentFiles\\" + "level" + index + ".csv");
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
                instance.GetComponent<Block>().ResetSate();
                instance.GetComponent<Block>().SetPositionItself(new Vector2(15.5f - currentIndex, currentRow + 0.5f));
                instance.transform.SetParent(blocks);
            } 
            else
            {
                Instantiate(clonedRock, new Vector2(15.5f - currentIndex, currentRow + 0.5f), Quaternion.identity, blocks);
            }

            currentIndex++;
            if (currentIndex > 15)
            {
                currentIndex = 0;
                currentRow++;
            }
        }
    }
}
