using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variables
    public float moveSpeed = 4f;
    public float blinkSpeed = 7f;
    public Animator anim;
    public bool isDashing = false;
    public Rigidbody2D rb;
    private bool canDash = true;
    private float lastDash;
    public float dashCooldown = 1f;
    public int spell_equipped = 0;
    public int dashCost = 10;
    public PlayerVitals vitals;
    private Vector3 markLocation;

    Vector2 movement;
    #endregion

    void Start()
    {
        changeSpell(spell_equipped);
    }
    void OnDrawGizmos()
    {
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(rb.position, 3);
    }
    void Update()
    {
        handleMovementAnim();
        handleDashTrigger();
        handleSpellChanging();
    }

    void FixedUpdate()
    {
        handlePlayerMovement();
    }

    #region Update Methods
    public void handlePlayerMovement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (isDashing)
        {
            GameObject.Find("Player").GetComponent<PlayerVitals>().changeStamina(dashCost);
            rb.MovePosition(rb.position + movement * blinkSpeed);
            isDashing = false;
        }
    }

    public void handleMovementAnim()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        int dirX = (int)Mathf.Ceil(movement.x) + 1;
        int dirY = (int)Mathf.Ceil(movement.y) + 1;
        anim.SetInteger("RunningInt", dirX * 3 + dirY);
    }

    public void handleDashTrigger()
    {
        if (Input.GetKeyDown("left shift") && GameObject.Find("Player").GetComponent<PlayerVitals>().stamina > 0 && canDash)
        {
            isDashing = true;
            canDash = false;
            vitals.setInvulnerable();
            lastDash = Time.time;
        }

        if (dashCooldown < (Time.time - lastDash))
        {
            canDash = true;
            vitals.setVulnerable();
        }
    }

    public void handleSpellChanging()
    {
        int prev_spell_equipped = spell_equipped;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spell_equipped = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spell_equipped = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spell_equipped = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spell_equipped = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            spell_equipped = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            spell_equipped = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            spell_equipped = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            spell_equipped = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            spell_equipped = 8;
        }
        if (spell_equipped != prev_spell_equipped)
        {
            changeSpell(spell_equipped);
        }
    }

    public void changeSpell(int spell_equipped)
    {
        Debug.Log("In changeSpell Method");
        int i = 0;
        foreach (Transform spell in transform)
        {
            if (i == spell_equipped || i == 9)
                spell.gameObject.SetActive(true);
            else
                spell.gameObject.SetActive(false);
            i++;
        }
    }
    #endregion

    #region Mark and Recall
    public void mark()
    {
        markLocation = rb.position;
    }

    public void recall()
    {
        rb.position = markLocation;
    }
    #endregion
}