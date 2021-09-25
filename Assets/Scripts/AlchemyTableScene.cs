using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class AlchemyTableScene : MonoBehaviour
{

    public static string[] ItemsToLoad;
    [SerializeField] private TextMeshProUGUI tasksText;
    [SerializeField] Toggle toggle;

    private void Start()
    {
        if (ItemsToLoad != null)
        {
            Combinations combinations = GameObject.Find("Combinations").GetComponent<Combinations>();
            int index = 0;
            foreach (string s in ItemsToLoad)
            {
                GameObject prefab = combinations.GetItemPrefab(s);
                Instantiate(prefab, new Vector2(-6 + index * 1.2F, 3), Quaternion.identity);
                index++;
            }
        }

        tasksText.text = Master.currentTask;
        toggle.isOn = Master.requestFulfilled;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ResetItems()
    {
        SceneManager.LoadScene("AlchemyScene");
    }
}
