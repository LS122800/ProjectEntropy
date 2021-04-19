using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    public GameObject target;
    private float timer;
    private int waitingTime;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        timer = .5f;
        waitingTime = 3;
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

        float distance = Vector2.Distance(transform.position, target.transform.position);
        timer += Time.deltaTime;
        if (timer > waitingTime && distance < 15)
        {
            GameObject arrowSpawn = Instantiate(arrow, transform.position, transform.rotation);
            timer = 1;
        }
        
    }


}
