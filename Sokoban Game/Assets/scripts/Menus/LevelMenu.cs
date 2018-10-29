using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
	
	[SerializeField] private Levels _levels;
	[SerializeField] private GameObject _buttonPrefab;
	
	private GameObject _first;

	private void Start()
	{
		AddButtons();
	}
	
	private void AddButtons()
	{
		Button up = null;
		Button down = null;
		foreach (var set in _levels.Sets)
		{
			var newButton = Instantiate(_buttonPrefab,transform);
			var sampleButton = newButton.GetComponent<LevelSetButton>();
			sampleButton.Setup(set,_levels);
			
			var button = newButton.GetComponent<Button>();
			var nav = button.navigation;


			if (_first == null) _first = newButton;
		}
	}

	public void setActive()
	{
		EventSystem.current.SetSelectedGameObject(_first);
	}

}
