using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variables
    public float moveSpeed = 4f;
    public float blinkSpeed = 3f;
    public Animator anim;
    public bool isDashing = false;
    public Rigidbody2D rb;
    private bool canDash = true;
    private float lastDash;
    public float dashCooldown = 2f;
    public int spell_equipped = 0;
    public int dashCost = 10;

    Vector2 movement;
    #endregion

    void Start()
    {
        changeSpell(spell_equipped);
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
            lastDash = Time.time;
        }

        if (dashCooldown < (Time.time - lastDash))
        {
            canDash = true;
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
            if (i == spell_equipped || i == 2)
                spell.gameObject.SetActive(true);
            else
                spell.gameObject.SetActive(false);
            i++;
        }
    }
    #endregion
}