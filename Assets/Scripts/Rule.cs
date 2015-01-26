using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rule : MonoBehaviour
{
    [TextArea]
    [SerializeField]
    string description = "Rules text";
    [Header("Random Number")]
    [SerializeField]
    int min = 1;
    [SerializeField]
    int max= 13;
    [Header("Random String")]
    [SerializeField]
    string[] allStrings = new string[] { "spades", "clovers", "hearts", "diamonds" };
    [Header("Tags")]
    [SerializeField]
    string[] thisRulesTags = null;
    [SerializeField]
    string[] excludeTags = null;

    HashSet<string> thisRulesTagsSet = null;

    public string[] Exclude
    {
        get
        {
            return excludeTags;
        }
    }

    public bool ContainsTag(ICollection<string> tags)
    {
        bool returnFlag = false;
        if (thisRulesTagsSet == null)
        {
            thisRulesTagsSet = new HashSet<string>();
            foreach(string tag in thisRulesTags)
            {
                thisRulesTagsSet.Add(tag);
            }
        }
        foreach(string tag in tags)
        {
            if(thisRulesTagsSet.Contains(tag) == true)
            {
                returnFlag = true;
                break;
            }
        }
        return returnFlag;
    }

    public void AppendRule(System.Text.StringBuilder builder)
    {
        int randomNumber = Random.Range(min, (max + 1));
        int randomStringIndex = Random.Range(0, allStrings.Length);
        builder.AppendFormat(description, randomNumber, allStrings[randomStringIndex]);
    }
}
