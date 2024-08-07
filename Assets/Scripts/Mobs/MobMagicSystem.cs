using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMagicSystem : MonoBehaviour
{
    public Magic magic;
    [SerializeField] private GameObject playerToFollow;
    [SerializeField] private float mobAttackDistance;
    [SerializeField] private Transform magicSpaw;
    private float distance;
    private float angle;
    private float timer;
    private bool castingMagic;
    Vector2 direction;


    void Update()
    {
        MagicSpawPosition();

        Debug.Log(timer);

        if (!castingMagic)
        {
            timer += Time.deltaTime;
            if (timer > magic.magicScriptableObject.magicCooldown)
            {
                castingMagic = true;
                timer = 0;
            }
        }

        if (castingMagic) Attack();
    }

    void MagicSpawPosition()
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
            castingMagic = false;
            GameObject newMagic = Instantiate(magic.gameObject, magicSpaw.transform.position, Quaternion.identity);
            newMagic.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * magic.magicScriptableObject.magicSpeed;
            Debug.Log("Magic Casted " + magic.magicScriptableObject.magicName);
        }
    }
}
