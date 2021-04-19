using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfire : MonoBehaviour
{
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 2)
        {
            timer = Time.time;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2);
            foreach (Collider2D c in colliders)
            {
                if (c.GetComponent<PlayerVitals>() != null)
                {
                    c.GetComponent<PlayerVitals>().changeTemp(-1);
                }
            }
        }
    }
}
