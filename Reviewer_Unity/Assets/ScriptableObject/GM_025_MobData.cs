using UnityEngine;

[CreateAssetMenu(fileName = "GM_025_MobData", menuName = "SO/GM_025_MobData")]
public class GM_025_MobData : ScriptableObject
{
	[SerializeField] private float _hp;
	[SerializeField] private float _speed;
	[SerializeField] private float _attackDamage;
	[SerializeField] private float _size;

	public float Hp => _hp;
	public float Speed => _speed;
	public float AttackDamage => _attackDamage;
	public float Size => _size;
}
