using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rule : MonoBehaviour
{
    public enum Suit
    {
        Spades,
        Clovers,
        Hearts,
        Diamonds,
        NumSuits
    }
    [TextArea]
    [SerializeField]
    string description = "Rules text";
    [Header("Random Number")]
    [SerializeField]
    int min = 1;
    [SerializeField]
    int max= 13;
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
        builder.AppendFormat(description, Random.Range(min, (max + 1)), (Suit)Random.Range(0, (int)Suit.NumSuits));
    }
}
