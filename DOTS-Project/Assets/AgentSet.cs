using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AgentSet")]
public class AgentSet : ScriptableObject
{
    [SerializeField] private Agent agentPrefab;
    public Agent AgentPrefab => agentPrefab;
    private List<Agent> _agents = new List<Agent>();
    public List<Agent> Agents => _agents;

    public void ClearAgents()
    {
        _agents.Clear();
    }

    public void AddAgent(Agent agent)
    {
        _agents.Add(agent);
    }
}