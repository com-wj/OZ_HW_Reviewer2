using UnityEngine;

public class GM_028_Bullet : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 20f;
	private float _lifeTime = 0.5f;

	void Update()
	{
		_lifeTime -= Time.deltaTime;
		transform.Translate(transform.forward * _moveSpeed * Time.deltaTime, Space.Self);

		if (_lifeTime < 0)
		{
			Destroy(gameObject);
		}
	}
}