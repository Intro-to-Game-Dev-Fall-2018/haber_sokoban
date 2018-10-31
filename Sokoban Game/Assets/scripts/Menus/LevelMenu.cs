using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

public class LevelMenu : MonoBehaviour
{

	[SerializeField] private Transform _content;
	[SerializeField] private GameObject _buttonPrefab;
	[SerializeField] private UI_InfiniteScroll _scroll;
	[SerializeField] private HorizontalScrollSnap _snap;
	
	private Levels _levels;

	private void Awake()
	{
		_levels = GameData.Levels;
		AddButtons();
		if (_scroll!=null) _scroll.Init();
		if (_content == null) _content = transform;
	}
	
	private void AddButtons()
	{
		foreach (var set in _levels.Sets)
		{
			var newButton = Instantiate(_buttonPrefab,_content);
			var sampleButton = newButton.GetComponent<LevelSetButton>();
			sampleButton.Setup(set);
			
		}
	}

	public void SelectCurrent()
	{
		Loader.LoadGame();
	}

}
