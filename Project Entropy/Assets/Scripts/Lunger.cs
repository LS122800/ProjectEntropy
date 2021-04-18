using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunger : MonoBehaviour
{
    public GameObject target;
    private int maxRange;
    private int moveSpeed;
    private int minRange;
    private Rigidbody2D rb;
    private bool hasLunged;
    // Start is called before the first frame update
    void Start()
    {
        maxRange = 6;
        rb = GetComponent<Rigidbody2D>();
        hasLunged = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector2 velocity = rb.velocity;
        //transform.LookAt(target.transform);
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance < maxRange && hasLunged)
        {
            rb.velocity = transform.up * 20;
            hasLunged = true;
        }
        else if (hasLunged && velocity.x > 0 && velocity.y > 0)
        {
        }
    }
}
