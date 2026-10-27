using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_039_GameManager : MonoBehaviour
{
	[Header("씬")]
	[SerializeField] private string _titleSceneName;

	[SerializeField] private GameObject _deathPanel;

	private static GM_039_GameManager _instance;
	public static GM_039_GameManager Instance => _instance;

	private bool _isGameOver = false;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
	}

	private void Update()
	{
		if (_isGameOver)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				GoToTitle();
			}
		}
	}

	public void GameOver()
	{
		Time.timeScale = 0f;
		if (_deathPanel == null)
		{
			Debug.LogError("참조가 없습니다.");
			return;
		}
		_deathPanel.SetActive(true);
		_isGameOver = true;
	}

	public void GoToTitle()
	{
		if (string.IsNullOrEmpty(_titleSceneName))
		{
			Debug.LogError("씬 이름이 없습니다.");
			return;
		}
		SceneManager.LoadScene(_titleSceneName);
	}
}