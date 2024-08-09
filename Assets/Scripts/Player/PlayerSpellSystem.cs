using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellSystem : MonoBehaviour
{
    public Spell Spell;
    private Camera mainCamera;
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private Transform spellSpaw;
    public float PlayerCurrentMana;
    public float PlayerMaxMana;
    public float PlayerManaRechargeRate;
    private float timer;


    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        SpellSpawPosition();
        Regeneration(PlayerMaxMana, ref PlayerCurrentMana, PlayerManaRechargeRate, ref timer);

        if (Input.GetButtonDown("Fire1") && PlayerCurrentMana >= Spell.SpellToCast.SpellManaCost) CastSpell();
    }

    void SpellSpawPosition()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }

    void CastSpell()
    {
        PlayerCurrentMana -= Spell.SpellToCast.SpellManaCost;

        GameObject newSpell = Instantiate(Spell.gameObject, spellSpaw.transform.position, Quaternion.identity);
        Vector3 direction = mousePosition - transform.position;
        newSpell.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * Spell.SpellToCast.SpellSpeed;

        Debug.Log("Spell Casted " + Spell.SpellToCast.SpellName);

    }

    void Regeneration(float max, ref float current, float regenerationRate, ref float timer)
    {
        if (current < max)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                current += regenerationRate;
                if (current > max) current = max;
                timer = 0;
            }
        }
    }

}
