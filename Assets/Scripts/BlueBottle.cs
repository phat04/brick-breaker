using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBottle : MonoBehaviour
{
    [SerializeField] float limitBottom = -1f;// limit bottom which item can exist

    float effectime = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < limitBottom)
        {
            DestroyItself();
        }
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

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
