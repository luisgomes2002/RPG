using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float PlayerSpeed;

    // Stamina
    public float PlayerStamina;
    public float PlayerMaxStamina;
    public float PlayerStaminaRechargeRate;
    // Timer
    public float TimerToStamina;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, moveY, 0) * PlayerSpeed * Time.deltaTime);
    }
}
