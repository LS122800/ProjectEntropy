using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, -90);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }
}
