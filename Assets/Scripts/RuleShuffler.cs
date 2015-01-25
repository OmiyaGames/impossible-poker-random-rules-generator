using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuleShuffler : MonoBehaviour
{
    [SerializeField]
    GameObject starterRules;
    [SerializeField]
    GameObject restOfTheRules;

    readonly RandomList<Rule> allStarters = new RandomList<Rule>();
    readonly RandomList<Rule> allRules = new RandomList<Rule>();

	// Use this for initialization
	void Awake()
    {
        allStarters.Clear();
        allStarters.AddRange(starterRules.GetComponentsInChildren<Rule>());

        allRules.Clear();
        allRules.AddRange(restOfTheRules.GetComponentsInChildren<Rule>());
    }
	
    public Rule[] GetAllRules(int numRules)
    {
        Rule[] returnRules = new Rule[numRules];
        HashSet<string> excludeTags = new HashSet<string>();

        // Grab the first rules
        returnRules[0] = allStarters.RandomElement;
        foreach (string tag in returnRules[0].Exclude)
        {
            excludeTags.Add(tag);
        }

        // Add more rules
        for (int index = 1; index < numRules; ++index)
        {
            // Get the next rule
            returnRules[index] = allRules.RandomElement;

            // Check if this rule should be excluded
            while(returnRules[index].ContainsTag(excludeTags) == true)
            {
                // Grab the next random rule
                returnRules[index] = allRules.RandomElement;
            }

            // Upon success, add this rule's exclusion tags
            foreach (string tag in returnRules[index].Exclude)
            {
                excludeTags.Add(tag);
            }
        }
        return returnRules;
    }
}
