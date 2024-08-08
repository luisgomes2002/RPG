using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Mana
    public float PlayerMana;
    public float PlayerMaxMana;
    public float PlayerManaRechargeRate;
    // Stamina
    public float PlayerStamina;
    public float PlayerMaxStamina;
    public float PlayerStaminaRechargeRate;
    public float PlayerSpeed;
    // Timer
    public float TimerToMana;
    public float TimerToStamina;


    void Start()
    {

    }

    void Update()
    {
        Regeneration(PlayerMaxMana, PlayerMana, PlayerManaRechargeRate, TimerToMana);
        Regeneration(PlayerMaxStamina, PlayerStamina, PlayerStaminaRechargeRate, TimerToStamina);

        Move();
    }

    // Não esta funcionando!! o código tá um lixo.
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

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, moveY, 0) * PlayerSpeed * Time.deltaTime);
    }
}
