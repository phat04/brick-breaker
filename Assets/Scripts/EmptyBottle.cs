using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBottle : Potion
{
    void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            other.GetComponent<Paddle>().EffectGearTime = 0;// Cancel gear buff effect

            var ball = FindObjectOfType<Ball>();
            if (ball != null)// Cancel blue bottle buff effect
            {
                ball.isBlueBottleEffectTime = false;
                ball.currentQuantityBlueBottles.Clear();
            }
            DestroyItself();
        }
    }
}
