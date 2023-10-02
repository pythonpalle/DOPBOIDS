using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid Rule Container")]
public class BoidRuleContainer : ScriptableObject
{
    [SerializeField] private List<BoidRuleConfiguration> ruleConfigurations;
    public List<BoidRuleConfiguration> RuleConfigurations => ruleConfigurations;
}

[Serializable]
public struct BoidRuleConfiguration
{
    public BoidRule rule;
    public bool active;
}