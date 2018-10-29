using UnityEngine;

public class LevelMenu : MonoBehaviour
{
	
	[SerializeField] private Levels _levels;
	[SerializeField] private GameObject _buttonPrefab;
	[SerializeField] private StartMenu _menu;

	private void Start()
	{
		AddButtons();
	}

	private void AddButtons()
	{
		foreach (var set in _levels.Sets)
		{
			var newButton = Instantiate(_buttonPrefab,transform);
			var sampleButton = newButton.GetComponent<LevelSetButton>();
			sampleButton.Setup(set,_levels);
		}
	}

}
