using UnityEngine;
using System.Collections;

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

    public void AppendRule(System.Text.StringBuilder builder)
    {
        builder.AppendFormat(description, Random.Range(min, (max + 1)), (Suit)Random.Range(0, (int)Suit.NumSuits));
    }
}
