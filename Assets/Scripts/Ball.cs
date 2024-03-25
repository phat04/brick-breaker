using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // constants
    private const int MOUSE_PRIMARY_BUTTON = 0;

    // fields
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float bounceRandomnessFactor = 0.5f;
    [SerializeField] private AudioClip[] bumpAudioClips;
    
    [SerializeField] private Vector2 initialBallVelocity;
    private Paddle _paddle;
    private Vector2 _initialDistanceToTopOfPaddle;
    private Rigidbody2D _rigidBody2D;
    private AudioSource _audioSource;

    // properties
    //public Vector2 InitialBallSpeed { get; set; }
    public Paddle Paddle { get; set; }
    public bool HasBallBeenShot { get; set; } = false;

    [Header("BlueBottleBuff")]
    public float blueBottleEffectTime = 10f;
    public bool isBlueBottleEffectTime;
    public int maxQuantityGearBuff = 5;

    public List<float> currentQuantityBlueBottles = new List<float>();

    private void Awake()
    {
        _paddle = FindObjectOfType<Paddle>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();

        var ballPosition = transform.position;
        var paddlePosition = _paddle.transform.position;

        _initialDistanceToTopOfPaddle = ballPosition - paddlePosition;  // assumes ball always starts on TOP of the paddle
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        initialBallVelocity = new Vector2(Random.Range(-1, 1), Random.Range(0.1f, 1)).normalized * moveSpeed;
    }
    
    private void Update()
    {
        // if ball has been shot, no locking or shooting it again!
        if (HasBallBeenShot) return;
        
        var hasMouseClick = Input.GetMouseButtonDown(MOUSE_PRIMARY_BUTTON);
        var paddlePosition = _paddle.transform.position;
            
        FixBallOnTopOfPaddle(paddlePosition, _initialDistanceToTopOfPaddle);
        ShootBallOnClick(initialBallVelocity, hasMouseClick);

        if (isBlueBottleEffectTime)// Decrease buffTime of BlueBottle effect
        {
            if (currentQuantityBlueBottles[0] <= Time.time)
            {
                currentQuantityBlueBottles.RemoveAt(0);
                if (currentQuantityBlueBottles.Count <= 0)
                {
                    isBlueBottleEffectTime = false;
                    _rigidBody2D.velocity = initialBallVelocity;
                }
            }
        }
    }
    
    /**
     * Fixes the ball on top of the paddle before the first mouse click.
     */
    public void FixBallOnTopOfPaddle(Vector2 paddlePosition, Vector2 distanceToPaddle)
    {
        transform.position = paddlePosition + distanceToPaddle;
    }
    
    /**
     * Shoots the ball for the first time upon the first mouse click.
     */
    public void ShootBallOnClick(Vector2 initialBallSpeed, bool hasMouseClick)
    {
        if (!hasMouseClick) return;
        
        HasBallBeenShot = true;
        _rigidBody2D.velocity = initialBallSpeed;
    }

    /**
     * Computes a random vector to add to the ball's velocity vector in order to avoid
     * repetitive ball collisions throughout the game.
     */
    public Vector2 GetRandomVelocityBounce()
    {

        var randomVelocityX = Random.Range(0, this.bounceRandomnessFactor);
        var randomVelocityY = Random.Range(0, this.bounceRandomnessFactor);
        
        return new Vector2(randomVelocityX, randomVelocityY);
    }
    
    /**
     * Randomly plays ball collision sounds.
     */
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (!HasBallBeenShot) return;  // ball must have been shot first
        
        var randomBumpAudioIndex = Random.Range(0, bumpAudioClips.Length);
        var signVelocityY = Math.Sign(_rigidBody2D.velocity.y);
        var signVelocityX = Math.Sign(_rigidBody2D.velocity.x);
        
        var correctVelocityY = _rigidBody2D.velocity.y;
        var correctVelocityX = _rigidBody2D.velocity.x;
        
        var bumpAudio = bumpAudioClips[randomBumpAudioIndex];
            
        _audioSource.PlayOneShot(bumpAudio);
        // _rigidBody2D.velocity += GetRandomVelocityBounce();

        if (Math.Abs(_rigidBody2D.velocity.y) < 4f) correctVelocityY = 4f * signVelocityY;
        if (Math.Abs(_rigidBody2D.velocity.x) < 4f) correctVelocityX = 4f * signVelocityX;

        if (isBlueBottleEffectTime)// if pickup Blue bottle, active blue bottle effect
        {
            correctVelocityY = correctVelocityY - correctVelocityY * 5 / 100 * currentQuantityBlueBottles.Count;
            correctVelocityX = correctVelocityX - correctVelocityX * 5 / 100 * currentQuantityBlueBottles.Count;
        }

        _rigidBody2D.velocity = new Vector2(correctVelocityX, correctVelocityY);
    }
}
