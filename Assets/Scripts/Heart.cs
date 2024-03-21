using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{
    [SerializeField] float limitBottom = -1f;

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
            GameSession.Instance.PlayerLives++;
            GameSession.Instance.PlayerLives = Mathf.Clamp(GameSession.Instance.PlayerLives, -1, 5);
            DestroyItself();
        }

    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
