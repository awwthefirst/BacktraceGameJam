using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorReagentItem : Item
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            Combination combination = this.combinations.GetCombinationFromResult(item);
            if (combination != null)
            {
                GameObject item1 = this.combinations.GetItemPrefab(combination.item1), item2 = this.combinations.GetItemPrefab(combination.item2);
                Instantiate(item1, new Vector2(this.transform.position.x + 0.5F, this.transform.position.y), Quaternion.identity);
                Instantiate(item2, new Vector2(this.transform.position.x - 0.5F, this.transform.position.y), Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(item.gameObject);
            }
        }
    }
}
