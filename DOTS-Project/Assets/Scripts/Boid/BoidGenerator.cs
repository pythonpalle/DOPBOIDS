using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoidGenerator : MonoBehaviour
{
    [SerializeField] private BoidEntitySet boidEntitySet;
    [SerializeField] private int agentsToGenerateCount = 10;

    private void Start()
    {
        GenerateAgents();
    }

    private void GenerateAgents()
    {
        boidEntitySet.ClearAgents();

        for (int i = 0; i < agentsToGenerateCount; i++)
        {
            BoidEntity boidEntity = Instantiate(boidEntitySet.BoidEntityPrefab, GetRandomPosition(), GetRandomRotation());
            boidEntitySet.AddAgent(boidEntity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3
        {
            x = 0, //ScreenManager.Instance.BottomLeft.x - 1,
            y = ScreenManager.Instance.BottomLeft.y + Random.Range(0, ScreenManager.Instance.Height),
            z = 0,
        };
    }
    
    private Quaternion GetRandomRotation()
    {
        float randomRotation = Random.Range(0, 360);
        return Quaternion.Euler(0f, 0f, randomRotation);
    }
}
