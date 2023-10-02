using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Sprite> sprites;
    
    static float timeBetweenShifts = 0.05f;
    private float timeOfLastShift;
    private int shiftCount = 0;
    private int numberOfSprites;

    private void Start()
    {
        numberOfSprites = sprites.Count;
    }

    void Update()
    {
        if (Time.time > timeOfLastShift + timeBetweenShifts)
        {
            Shift();
        }
    }

    private void Shift()
    {
        shiftCount++;
        if (shiftCount >= numberOfSprites)
        {
            shiftCount = 0;
        }

        _spriteRenderer.sprite = sprites[shiftCount];
        timeOfLastShift = Time.time;
    }
}
