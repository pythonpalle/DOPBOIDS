using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGenerator : MonoBehaviour
{
    [SerializeField] private AgentSet _agentSet;
    [SerializeField] private int agentsToGenerateCount = 10;

    private void Awake()
    {
        GenerateAgents();
    }

    private void GenerateAgents()
    {
        _agentSet.ClearAgents();

        for (int i = 0; i < agentsToGenerateCount; i++)
        {
            Agent agent = Instantiate(_agentSet.AgentPrefab);
            _agentSet.AddAgent(agent);
        }
    }
}
