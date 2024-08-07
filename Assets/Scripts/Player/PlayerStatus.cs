using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // HP
    public float playerHp;
    // Mana
    public float playerMana;
    public float playerMaxMana;
    public float playerManaRechargeRate;
    // Stamina
    public float playerStamina;
    public float playerMaxStamina;
    public float playerStaminaRechargeRate;
    //
    public bool playerIsAlive;
    public float playerSpeed;
    // Timer
    public float timerToMana;
    public float timerToStamina;


    void Start()
    {

    }

    void Update()
    {
        Regeneration(playerMaxMana, playerMana, playerManaRechargeRate, timerToMana);
        Regeneration(playerMaxStamina, playerStamina, playerStaminaRechargeRate, timerToStamina);

        Move();
        Die();
    }

    void Regeneration(float max, float current, float regenerationRate, float timer)
    {
        if (current < max)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                current += regenerationRate;
                timer = 0;
            }
        }
    }

    void TakeDamage(float damage)
    {
        playerHp -= damage;
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, moveY, 0) * playerSpeed * Time.deltaTime);
    }

    void Die()
    {
        if (playerHp <= 0)
        {
            playerIsAlive = false;
            Destroy(this.gameObject);
        }
    }
}
