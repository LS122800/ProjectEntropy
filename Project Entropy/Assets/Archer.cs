using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    public GameObject target;
    private float timer;
    private int waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = .5f;
        waitingTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            GameObject arrowSpawn = Instantiate(arrow, transform.position, transform.rotation);
            timer = 1;
        }
        
    }


}
