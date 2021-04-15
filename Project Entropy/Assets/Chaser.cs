using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public GameObject target;
    private int maxRange;
    private int moveSpeed;
    private int minRange;
    // Start is called before the first frame update
    void Start()
    {
        maxRange = 6;
        moveSpeed = 5;
        minRange = 1;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
