using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlchemyTable : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnMouseDown()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance <= 1)
        {
            SceneManager.LoadScene("AlchemyScene");
        }
    }
}
