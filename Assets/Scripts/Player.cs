using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 movement = new Vector2();
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    private static Vector2 position;

    private void Start()
    {
        if (position != null)
        {
            this.transform.position = position;
        }
    }

    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb.velocity = movement * speed;
    }

    private void OnDestroy()
    {
        position = this.transform.position;
    }
}
