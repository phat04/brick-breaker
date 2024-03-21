using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    public float minRelativePosX = 1f;  // assumes paddle size of 1 relative unit
    
    [SerializeField]
    public float maxRelativePosX = 15f;  // assumes paddle size of 1 relative unit
    
    [SerializeField]
    public float fixedRelativePosY = .64f;  // paddle does not move on the Y directiob
    
    // Unity units of the WIDTH of the screen (e.g. 16)
    [SerializeField]
    public float screenWidthUnits = 16;

    [Header("GearBuff")]
    float effectGearTime;
    bool isGearEffectTime;

    // Start is called before the first frame update
    void Start()
    {
        float startPosX = ConvertPixelToRelativePosition(screenWidthUnits / 2, Screen.width);
        transform.position = GetUpdatedPaddlePosition(startPosX);
    } 

    // Update is called once per frame
    void Update()
    {
        var relativePosX = ConvertPixelToRelativePosition(pixelPosition: Input.mousePosition.x, Screen.width);
        transform.position = GetUpdatedPaddlePosition(relativePosX);

        if (isGearEffectTime) // // Decrease buffTime of Gear effect
        {
            effectGearTime -= Time.deltaTime;
            Debug.Log("iseffectGearTime");
            if (effectGearTime <= 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isGearEffectTime = false;
            }
        }
    }

    public Vector2 GetUpdatedPaddlePosition(float relativePosX)
    {
        // clamps the X position
        float clampedRelativePosX = Mathf.Clamp(relativePosX, minRelativePosX, maxRelativePosX);
        
        Vector2 newPaddlePosition = new Vector2(clampedRelativePosX, fixedRelativePosY);
        return newPaddlePosition;
    }
    
    public float ConvertPixelToRelativePosition(float pixelPosition, int screenWidth)
    { 
        var relativePosition = pixelPosition/screenWidth * screenWidthUnits;
        return relativePosition;
    }

    private void OnTriggerEnter2D(Collider2D other)// Gear Buff event
    {
        if (other.CompareTag("Gear"))
        {
            effectGearTime = 10f;
            isGearEffectTime = true;
        }
    }
}