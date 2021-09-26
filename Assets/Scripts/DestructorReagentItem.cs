using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorReagentItem : Item
{

    [SerializeField] private AudioClip destructionSound;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            Combination combination = this.combinations.GetCombinationFromResult(item);
            if (combination != null)
            {
                GameObject item1Prefab = this.combinations.GetItemPrefab(combination.item1), item2Prefab = this.combinations.GetItemPrefab(combination.item2);
                Item item1 = Instantiate(item1Prefab, new Vector2(this.transform.position.x + 0.5F, this.transform.position.y), Quaternion.identity).GetComponent<Item>();
                Instantiate(item2Prefab, new Vector2(this.transform.position.x - 0.5F, this.transform.position.y), Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(item.gameObject);

                item1.AudioSource.clip = this.destructionSound;
                item1.AudioSource.Play();
                item1.nameText = this.nameText;
            } else
            {
                this.AudioSource.clip = this.errorSound;
                this.AudioSource.Play();
            }
        }
    }
}
