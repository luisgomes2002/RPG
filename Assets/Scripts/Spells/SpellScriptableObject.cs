using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class SpellScriptableObject : ScriptableObject
{
	public string SpellName;
	public string SpellType;
	public string SpellRarity;
	[TextArea(4, 4)]
	public string SpellDescription;
	public Sprite SpellIcon;
	public int SpellLevel;
	public float SpellDamage;
	public float SpellDamageAmount;
	public float SpellManaCost;
	public float SpellSpeed;
	public float SpellCooldown;
	public float SpellLifeTime;
	public float SpellRadius;

	// Status effects
	// Thumbnail
	// Time Between casts
	// Spell elements
}