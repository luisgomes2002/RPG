using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGeral : MonoBehaviour
{

    [SerializeField] private float mobHp;
    [SerializeField] private float mobMana;
    [SerializeField] private float mobStamina;
    [SerializeField] private float mobSpeed;
    [SerializeField] private bool mobIsAlive;
    [SerializeField] private GameObject playerToFollow;
    private float distance;
    [SerializeField] private float distanceBetween;

    void Update()
    {
        Move();
        Die();
    }

    void Move()
    {
        distance = Vector2.Distance(transform.position, playerToFollow.transform.position);
        Vector2 direction = playerToFollow.transform.position - transform.position;
        direction.Normalize();

        if (distance <= distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerToFollow.transform.position, mobSpeed * Time.deltaTime);
        }
    }


    void Die()
    {
        if (mobHp <= 0)
        {
            mobIsAlive = false;
            Destroy(this.gameObject);
        }
    }
}
