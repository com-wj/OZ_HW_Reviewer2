using UnityEngine;

public class GM_025_Portal : MonoBehaviour
{
	[SerializeField] private Transform _teleportPoint;
	private void OnTriggerEnter(Collider other)
	{
		if (_teleportPoint == null) return;

		if (other.CompareTag("Player"))
		{
			other.transform.position = _teleportPoint.position;
		}
	}
}