using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
	public int id;
	public string itemName;
	[TextArea(4, 4)]
	public string itemDescription;
	public string itemType;
	public Sprite itemIcon;
	public int itemMaxStacksSize;

}
