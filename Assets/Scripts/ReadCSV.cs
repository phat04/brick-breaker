using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    [SerializeField] List<GameObject> typeOfRocks;
    [SerializeField] Transform blocks;

    public List<int> list = new List<int>();
    public static ReadCSV Instance;

    int currentIndex = 0, currentRow = 0;
    GameObject clonedRock;

    void Awake()
    {
        Instance = this;
        ReadCSVFile();

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = list.Count - 1; i >= 2; i--)
        {
            switch (list[i])
            {
                case 0:
                    clonedRock = typeOfRocks[0];
                    break;
                case 1:
                    clonedRock = typeOfRocks[1];
                    Instantiate(typeOfRocks[1], new Vector2(currentIndex + 0.5f, currentRow + 0), Quaternion.identity, blocks);
                    break;
                case 2:
                    clonedRock = typeOfRocks[2];
                    break;
                case 3:
                    clonedRock = typeOfRocks[3];
                    break;
                default:
                    clonedRock = typeOfRocks[0];
                    break;
            }
            Instantiate(clonedRock, new Vector2(currentIndex + 0.5f, currentRow + 0), Quaternion.identity, blocks);
            currentIndex++;
            if (currentIndex > 15)
            {
                currentIndex = 0;
                currentRow++;
            }
        }

       

    }

    void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("D:\\InternUnity\\brick-breaker\\Assets\\ContentFiles\\level1.csv");
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
                //Debug.Log("Value " + i.ToString() + ": " + data_values[i].ToString());
            }
            /*for (int i = 0;i < list.Count; i++)
            {
                Debug.Log("Value " + i.ToString() + ": " + list[i].ToString());
            }*/
        }
    }
}
