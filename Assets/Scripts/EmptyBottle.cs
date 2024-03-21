using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBottle : MonoBehaviour
{
    [SerializeField] float limitBottom = -1f;// limit bottom which item can exist

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

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
