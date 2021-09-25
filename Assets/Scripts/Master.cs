using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Master : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private Dialogue[] dialogues;
    private static int dialogueIndex = 0;
    public static string requestedItem = "";
    public static bool requestFulfilled = false;
    public static string currentTask;
    [SerializeField] private GameObject shareRecipeText;

    private void OnMouseDown()
    {
        float distance = Vector2.Distance(this.player.transform.position, this.transform.position);
        if (distance <= 1)
        {
            if (requestedItem.Length == 0 || requestFulfilled)
            {
                DisplayDialogue(dialogueIndex);
                dialogueIndex++;
            }
            else
            {
                DisplayDialogue(dialogueIndex - 1);
            }
        }
    }

    private void DisplayDialogue(int dialogueIndex)
    {
        Dialogue dialogue = this.dialogues[dialogueIndex];
        this.dialogueText.text = dialogue.text;
        this.dialogueImage.sprite = dialogue.image;
        AlchemyTableScene.ItemsToLoad = dialogue.items;
        requestedItem = dialogue.requestedItem;
        requestFulfilled = false;
        currentTask = dialogue.task;
    }

    [System.Serializable]
    public class Dialogue
    {
        public string text;
        public Sprite image;
        public string[] items;
        public string requestedItem;
        public string task;
    }

    private void OnMouseEnter()
    {
        if (requestFulfilled)
        {
           this.shareRecipeText.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        this.shareRecipeText.SetActive(false);
    }
}