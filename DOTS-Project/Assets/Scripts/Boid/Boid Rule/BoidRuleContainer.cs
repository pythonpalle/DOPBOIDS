using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid Rule Container")]
public class BoidRuleContainer : ScriptableObject
{
    [SerializeField] private List<BoidRule> rules;
    public List<BoidRule> Rules => rules;
}
