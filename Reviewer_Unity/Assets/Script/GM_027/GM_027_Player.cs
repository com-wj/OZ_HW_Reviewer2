using UnityEngine;

public class GM_027_Player : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 10f;

	[SerializeField] private float _interactRange = 1f;
	[SerializeField] private LayerMask _interactMask;
	
	private Collider[] _hitCollider = new Collider[3];

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			PlayerMove(Vector3.forward);
		}
		if (Input.GetKey(KeyCode.A))
		{
			PlayerMove(Vector3.left);
		}
		if (Input.GetKey(KeyCode.S))
		{
			PlayerMove(Vector3.back);
		}
		if (Input.GetKey(KeyCode.D))
		{
			PlayerMove(Vector3.right);
		}
		if (Input.GetKeyDown(KeyCode.Space)) // 상호작용
		{
			Interact();
		}
	}

	void PlayerMove(Vector3 dir)
	{
		transform.Translate(dir * _moveSpeed * Time.deltaTime, Space.Self);
	}

	void Interact()
	{
		int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _interactRange, _hitCollider, _interactMask);

		if (hitCount <= 0) return;

		if (_hitCollider[0].TryGetComponent<IInteractable>(out IInteractable inter))
		{
			Debug.Log($"[{name}] {inter}에게 상호작용");
			inter.Interact(gameObject);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, _interactRange);
	}
}
