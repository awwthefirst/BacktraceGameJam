using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string ItemName;
    [SerializeField] private Rigidbody2D rb;
    protected Combinations combinations;
    private bool destroyed = false;
    [HideInInspector] public TextMeshProUGUI nameText;
    [SerializeField] protected AudioClip successSound, errorSound;
    public AudioSource AudioSource;

    private void Start()
    {
        combinations = GameObject.Find("Combinations").GetComponent<Combinations>();
        this.nameText = GameObject.Find("Canvas").GetComponentInChildren<TextMeshProUGUI>();
        if (this.ItemName == Master.requestedItem)
        {
            Master.requestFulfilled = true;
            GameObject.Find("Canvas").GetComponentInChildren<Toggle>().isOn = true;
        } 
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            if (item is DestructorReagentItem)
            {
                return;
            }
            if (!item.destroyed)
            {
                GameObject result = combinations.GetCombinationResult(this, item);
                if (result != null)
                {
                    Destroy(item.gameObject);
                    Destroy(this.gameObject);
                    Item resultItem = Instantiate(result, this.transform.position, Quaternion.identity).GetComponent<Item>();
                    this.destroyed = true;

                    resultItem.AudioSource.clip = this.successSound;
                    resultItem.AudioSource.Play();
                    resultItem.nameText = this.nameText;
                } else
                {
                    this.AudioSource.clip = this.errorSound;
                    this.AudioSource.Play();
                }
            }
        }
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.position = new Vector2(mousePos.x, mousePos.y);
    }

    private void OnMouseOver()
    {
        if (this.nameText != null)
        {
            this.nameText.text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.ItemName);
        }
    }
}
