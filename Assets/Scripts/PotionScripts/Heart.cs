using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : Potion
{
    void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            GameSession.Instance.PlayerLives++;
            GameSession.Instance.PlayerLives = Mathf.Clamp(GameSession.Instance.PlayerLives, 0, 5);
            DestroyItself();
        }
    }
}
