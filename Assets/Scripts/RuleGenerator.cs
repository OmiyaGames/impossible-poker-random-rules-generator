using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RuleGenerator : MonoBehaviour
{
    public const int MaxNumberOfRules = 3;
    readonly System.Text.StringBuilder Builder = new System.Text.StringBuilder();

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
        GenerateNewRule();
        UpdateNumberOfRules();
	}

    public void ChangeNumberOfRules(bool up)
    {
        if(up == true)
        {
            ++numberOfRules;
        }
        else
        {
            --numberOfRules;
        }
        numberOfRules = Mathf.Clamp(numberOfRules, 1, MaxNumberOfRules);
        UpdateNumberOfRules();
    }

    public void GenerateNewRule()
    {
        // Activate or deactivate rules
        for (int index = 0; index < MaxNumberOfRules; ++index)
        {
            // Generate a string
            Builder.Length = 0;
            Builder.Append("Rule #");
            Builder.Append(index + 1);
            Builder.Append('\n');

            // FIXME: append an actual rule
            Builder.Append(Random.Range(0, 10));

            // Awesome
            rules[index].label.text = Builder.ToString();
        }
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
            // Generate a string
            Builder.Length = 0;
            Builder.Append(numberOfRules);
            Builder.Append(" Rules");

            // Set the text
            numberOfRulesLabel.text = Builder.ToString();
            if(numberOfRules >= MaxNumberOfRules)
            {
                upButton.interactable = false;
            }
        }

        // Activate or deactivate rules
        for(int index = 0; index < MaxNumberOfRules; ++index)
        {
            rules[index].set.SetActive(index < numberOfRules);
        }
    }
}
