using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGeral : MonoBehaviour
{
    [SerializeField] private int mobHp;
    [SerializeField] private int mobMana;
    [SerializeField] private int mobStamina;
    [SerializeField] private bool mobIsAlive;

    void Start()
    {

    }

    void Update()
    {
        Move();
        Die();
    }

    void Move()
    {

    }

    void Die()
    {
        if (mobHp <= 0)
        {
            mobIsAlive = false;
            Destroy(gameObject);
        }
    }
}
