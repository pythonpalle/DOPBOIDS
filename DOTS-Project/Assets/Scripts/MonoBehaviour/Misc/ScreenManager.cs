using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance { get; private set; }
    
    private Camera _camera;
    
    public Vector2 BottomLeft { get; private set; }
    public Vector2 TopRight { get; private set; }
    public Vector2 Mid { get; private set; }

    public float Width { get; private set; }
    public float Height { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        
        _camera = Camera.main;
        UpdateData();
    } 

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(BottomLeft, TopRight);
    }

    private void UpdateData()
    {
        BottomLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        TopRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, _camera.nearClipPlane));
        var diagonal = TopRight - BottomLeft;
        Width = diagonal.x;
        Height = diagonal.y;

        Mid = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, _camera.nearClipPlane));
    }
}
