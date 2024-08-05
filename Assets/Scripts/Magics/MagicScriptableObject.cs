using UnityEngine;

[CreateAssetMenu(fileName = "New Magic", menuName = "Magic")]
public class MagicScriptableObject : ScriptableObject
{
	public string magicName;
	public string magicType;
	public string magicRarity;
	[TextArea(4, 4)]
	public string magicDescription;
	public Sprite magicIcon;
	public int magicLevel;
	public float magicDamage;
	public float magicDamageAmount;
	public float magicManaCost;
	public float magicSpeed;
	public float magicCooldown;
	public float magicLifeTime;
	public float magicRadius;

	// Status effects
	// Thumbnail
	// Time Between casts
	// Magic elements
}