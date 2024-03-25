using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> objectsPool;

    public static ObjectPool Instace;

    // Start is called before the first frame update
    void Start()
    {
        if (Instace == null)
        {
            Instace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectsPool.Add(obj);
    }

    public void GetObjectFromPool(GameObject obj)
    {
        objectsPool.FirstOrDefault(o => o == obj).SetActive(true);
    }
}
