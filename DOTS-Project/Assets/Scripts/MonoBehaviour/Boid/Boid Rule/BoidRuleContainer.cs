using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid Rule Container")]
public class BoidRuleContainer : ScriptableObject
{
    //public int ActiveRuleCount => ruleConfigurations.Count(con => con.active);
    [SerializeField] private List<BoidRuleConfiguration> ruleConfigurations;
    public List<BoidRuleConfiguration> RuleConfigurations => ruleConfigurations;
}

[Serializable]
public struct BoidRuleConfiguration
{
    public BoidRule rule;
    public bool active;
}