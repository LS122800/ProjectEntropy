using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerVitals>().takeDamage(5);
        }
        Destroy(gameObject);

    }
}
