using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] float limitBottom = -1f;

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
            other.transform.localScale = new Vector3(2, 1, 1);
            DestroyItself();
        }

    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
