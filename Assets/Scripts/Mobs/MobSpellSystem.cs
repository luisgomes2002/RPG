using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpellSystem : MonoBehaviour
{
    public Spell Spell;
    [SerializeField] private GameObject playerToFollow;
    [SerializeField] private float mobAttackDistance;
    [SerializeField] private Transform spellSpaw;
    private float distance;
    private float angle;
    private float timer;
    private bool castingSpell;
    private Vector2 direction;


    void Update()
    {
        SpellSpawPosition();

        if (!castingSpell)
        {
            timer += Time.deltaTime;
            if (timer > Spell.SpellToCast.SpellCooldown)
            {
                castingSpell = true;
                timer = 0;
            }
        }

        if (castingSpell) Attack();
    }

    void SpellSpawPosition()
    {
        distance = Vector2.Distance(transform.position, playerToFollow.transform.position);
        direction = playerToFollow.transform.position - transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    void Attack()
    {
        if (distance <= mobAttackDistance)
        {
            castingSpell = false;
            GameObject newSpell = Instantiate(Spell.gameObject, spellSpaw.transform.position, Quaternion.identity);
            newSpell.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * Spell.SpellToCast.SpellSpeed;
            Debug.Log("Spell Casted " + Spell.SpellToCast.SpellName);
        }
    }
}
