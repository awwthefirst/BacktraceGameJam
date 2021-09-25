using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinations : MonoBehaviour
{
    [SerializeField] private Combination[] combinations;
    [SerializeField] private Item[] items;

    public GameObject GetCombinationResult(Item item1, Item item2)
    {
        string item1Name = item1.ItemName, item2Name = item2.ItemName;
        foreach (Combination c in this.combinations)
        {
            if (c.Matches(item1Name, item2Name))
            {
                return GetItemPrefab(c.result);
            }
        }
        return null;
    }

    public GameObject GetItemPrefab(string name)
    {
        foreach (Item i in this.items)
        {
            if (i.ItemName == name)
            {
                return i.gameObject;
            }
        }
        return null;
    }

    public Combination GetCombinationFromResult(Item result)
    {
        foreach (Combination i in this.combinations)
        {
            if (i.result == result.ItemName)
            {
                return i;
            }
        } 
        return null;
    }
 }
