using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    public float pickUpRadios = 1f;
    public InventoryItemData itemData;

    private CircleCollider2D circleCollider2D;

    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.isTrigger = true;
        circleCollider2D.radius = pickUpRadios;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();

        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(itemData, 1))
        {
            Destroy(this.gameObject);
        }
    }

}
