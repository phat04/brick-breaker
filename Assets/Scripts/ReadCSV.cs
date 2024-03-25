using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReadCSVFile();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("D:\\InternUnity\\brick-breaker\\Assets\\ContentFiles\\content.csv");
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
            Debug.Log(data_values.Length);
            for (int i = 0; i < data_values.Length; i++)
            {
                Debug.Log("Value " + i.ToString() + ": " + data_values[i].ToString());
            }
            //Debug.Log(data_values[0].ToString() + " " + data_values[1].ToString() + " " + data_values[2].ToString());
        }
    }
}
