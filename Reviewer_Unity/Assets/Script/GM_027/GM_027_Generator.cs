using UnityEngine;

public class GM_027_Generator : MonoBehaviour, IInteractable
{
	enum EPowerMultiplier
	{
		low = 1,
		middle = 2,
		high = 3,
	}

	[SerializeField] private EPowerMultiplier _powerMultiplier;
	[SerializeField] private bool _active = false;
	[SerializeField] private Renderer _renderer;

	public void Interact(GameObject interactor)
	{
		if (_active) return;

		if (interactor.TryGetComponent<GM_027_PlayerInventory>(out GM_027_PlayerInventory inventory))
		{
			_active = true;
			if (_renderer == null)
			{
				_renderer = GetComponent<Renderer>();
			}
			if (_renderer != null)
			{
				_renderer.material.color = Color.red;
			}

			Debug.Log($"{name} 활성화 됨.");

			float power = inventory.UseItem() * (float)_powerMultiplier;
			GM_027_MainCore.Instance.AddPower(power);
		}
	}
}