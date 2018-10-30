using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

public class LevelMenu : MonoBehaviour
{
	
	[SerializeField] private Levels _levels;
	[SerializeField] private GameObject _buttonPrefab;
	[SerializeField] private UIInfiniteScroll _scroll;
	
	private GameObject _first;

	private void Awake()
	{
		AddButtons();
		_scroll.Init();
	}
	
	private void AddButtons()
	{
		foreach (var set in _levels.Sets)
		{
			var newButton = Instantiate(_buttonPrefab,transform);
			var sampleButton = newButton.GetComponent<LevelSetButton>();
			sampleButton.Setup(set,_levels);
			
			if (_first == null) _first = newButton;
		}
	}

	public void setActive()
	{
		EventSystem.current.SetSelectedGameObject(_first);
	}

}
