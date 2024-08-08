using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Magic : MonoBehaviour
{
    public MagicScriptableObject MagicScriptableObject;
    private Rigidbody2D rigidbody2D;
    private CircleCollider2D circleCollider2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;

        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.isTrigger = true;

        Destroy(this.gameObject, MagicScriptableObject.MagicLifeTime);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Apply spell effects to whatever we hit.
        // Apply hi particle effects
        // Apply sound effects

        Destroy(this.gameObject);
    }
}
