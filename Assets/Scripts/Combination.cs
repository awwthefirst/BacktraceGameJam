using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combination")]
public class Combination : ScriptableObject
{
    public string item1;
    public string item2;
    public string result;

    public bool Matches(string item1, string item2)
    {
        if (item1 == this.item1)
        {
            if (item2 == this.item2)
            {
                return true;
            }
        } else if (item1 == this.item2)
        {
            if (item2 == this.item1)
            {
                return true;
            }
        }
        return false;
    }
}
