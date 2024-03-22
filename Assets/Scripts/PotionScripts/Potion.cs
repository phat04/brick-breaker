//DOCUMENT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] float limitBottom = -1f;// limit bottom which item can exist

    // Update is called once per frame
    public void Update()
    {
        if (transform.position.y < limitBottom)
        {
            DestroyItself();
        }
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }
}
