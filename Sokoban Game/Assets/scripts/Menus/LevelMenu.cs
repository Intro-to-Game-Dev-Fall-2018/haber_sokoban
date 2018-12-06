using UnityEngine;
using UnityEngine.UI.Extensions;

public class LevelMenu : MonoBehaviour
{

	[SerializeField] private Transform _content;
	[SerializeField] private GameObject _buttonPrefab;
	[SerializeField] private UI_InfiniteScroll _scroll;
	
	private void Awake()
	{
		if (_content == null) _content = transform;
		AddButtons();
		if (_scroll!=null) _scroll.Init();
	}
	
	private void AddButtons()
	{
		foreach (Set set in GameData.Levels.Sets)
		{
			GameObject newButton = Instantiate(_buttonPrefab,_content);
			LevelSetButton sampleButton = newButton.GetComponent<LevelSetButton>();
			sampleButton.Setup(set);
		}
	}

}
