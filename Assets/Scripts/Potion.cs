//DOCUMENT

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] float limitBottom = -1f;
    [SerializeField] List<Sprite> itemSprite = new List<Sprite>();

    SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        var randomIndex = Random.Range(0, itemSprite.Count);
        mySpriteRenderer.sprite = itemSprite[randomIndex];
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
            switch (mySpriteRenderer.name)
            {
                case "heart":
                    GameSession.Instance.PlayerLives++;
                    GameSession.Instance.PlayerLives = Mathf.Clamp(GameSession.Instance.PlayerLives, -1, 5);
                    break;
                //case "gear":
            }
            if (mySpriteRenderer.name == "heart")
            {
                GameSession.Instance.PlayerLives++;
                GameSession.Instance.PlayerLives = Mathf.Clamp(GameSession.Instance.PlayerLives, -1, 5);
            }
            else if (true)
            {
                
            }
            DestroyItself();
        }

    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
*/