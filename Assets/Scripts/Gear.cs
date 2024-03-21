using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : Potion
{
    void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            other.transform.localScale = new Vector3(2, 1, 1);
            DestroyItself();
        }
    }
}
