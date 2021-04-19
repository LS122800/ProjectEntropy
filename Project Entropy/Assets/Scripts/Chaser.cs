using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public GameObject target;
    public GameObject sword;
    private int maxRange;
    private float moveSpeed;
    private int minRange;
    private float timer;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        maxRange = 8;
        timer = .5f;
        moveSpeed = 4.5f;
        minRange = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Math.Abs(transform.rotation.eulerAngles.z) > 90 && Math.Abs(transform.rotation.eulerAngles.z) < 270)
            spriteRenderer.flipY = true;

        else
            spriteRenderer.flipY = false;

        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //transform.LookAt(target.transform);
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance < maxRange && distance > minRange )
        {
            print(Vector3.Distance(transform.position, target.transform.position));
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        timer += Time.deltaTime;

        if (distance < 1.5 && timer > 2)
        {
            attack();
            timer = 0;
        }
    }


    public void attack()
    {
        target.GetComponent<PlayerVitals>().takeDamage(5);
    }
    
}
