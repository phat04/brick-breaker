using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBottle : Potion
{
    void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            var ball = FindObjectOfType<Ball>();
            if (ball != null)
            {
                ball.isBlueBottleEffectTime = true;

                if (ball.currentQuantityBlueBottles.Count < ball.maxQuantityGearBuff)// Add bluebuff if  Acount BuleBuff < 5
                {
                    ball.currentQuantityBlueBottles.Add(Time.time + 10f);
                }
            }
            DestroyItself();
        }
    }
}
