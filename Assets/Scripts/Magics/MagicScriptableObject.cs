using UnityEngine;

[CreateAssetMenu(fileName = "New Magic", menuName = "Magic")]
public class MagicScriptableObject : ScriptableObject
{
	public string MagicName;
	public string MagicType;
	public string MagicRarity;
	[TextArea(4, 4)]
	public string MagicDescription;
	public Sprite MagicIcon;
	public int MagicLevel;
	public float MagicDamage;
	public float MagicDamageAmount;
	public float MagicManaCost;
	public float MagicSpeed;
	public float MagicCooldown;
	public float MagicLifeTime;
	public float MagicRadius;

	// Status effects
	// Thumbnail
	// Time Between casts
	// Magic elements
}