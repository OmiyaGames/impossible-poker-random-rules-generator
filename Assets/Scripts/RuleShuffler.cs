using UnityEngine;
using System.Collections;

public class RuleShuffler : MonoBehaviour
{
    [SerializeField]
    GameObject starterRules;
    [SerializeField]
    GameObject restOfTheRules;

    Rule[] allStarters;
    Rule[] allRules;

	// Use this for initialization
	void Awake()
    {
        allStarters = starterRules.GetComponentsInChildren<Rule>();
        allRules = restOfTheRules.GetComponentsInChildren<Rule>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
