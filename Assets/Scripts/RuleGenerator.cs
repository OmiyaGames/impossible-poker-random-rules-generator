using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RuleGenerator : MonoBehaviour
{
    public const int MaxNumberOfRules = 3;

    [System.Serializable]
    struct RuleSet
    {
        [SerializeField]
        public GameObject set;
        [SerializeField]
        public Text label;
    }

    [Header("Header Stuff")]
    [SerializeField]
    Button upButton;
    [SerializeField]
    Button downButton;
    [SerializeField]
    Text numberOfRulesLabel;

    [Header("Rules Stuff")]
    [SerializeField]
    RuleSet[] rules = new RuleSet[MaxNumberOfRules];

    int numberOfRules = 1;

	// Use this for initialization
	void Start ()
    {
        UpdateNumberOfRules();
	}

    public void ChangeNumberOfRules(bool up)
    {
        if(up == true)
        {
            ++numberOfRules;
            if(numberOfRules > MaxNumberOfRules)
            {
                numberOfRules = MaxNumberOfRules;
            }
        }
        else
        {
            --numberOfRules;
            if (numberOfRules < 1)
            {
                numberOfRules = 1;
            }
        }
        UpdateNumberOfRules();
    }
	
    void UpdateNumberOfRules()
    {
        upButton.interactable = true;
        downButton.interactable = true;
        if (numberOfRules <= 1)
        {
            numberOfRulesLabel.text = "1 Rule";
            downButton.interactable = false;
        }
        else
        {
            numberOfRulesLabel.text = numberOfRules + " Rules";
            if(numberOfRules >= MaxNumberOfRules)
            {
                upButton.interactable = false;
            }
        }
        for(int index = 0; index < MaxNumberOfRules; ++index)
        {
            rules[index].set.SetActive(index < numberOfRules);
        }
    }
}
