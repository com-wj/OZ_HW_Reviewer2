using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_039_TitleManager : MonoBehaviour
{
	[SerializeField] private string _gameSceneName;

	private void Awake()
	{
		Time.timeScale = 1.0f;
	}

	void Update()
	{
		if (Input.anyKeyDown)
		{
			if (string.IsNullOrEmpty(_gameSceneName)) return;

			SceneManager.LoadScene(_gameSceneName);
		}
	}
}