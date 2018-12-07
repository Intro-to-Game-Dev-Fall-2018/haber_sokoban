using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class LevelMenu : MonoBehaviour
{

	[SerializeField] private Transform _content;
	[SerializeField] private GameObject _buttonPrefab;
//	[SerializeField] private UI_InfiniteScroll _scroll;

	[SerializeField] private Button _backButton;
	
	private void Awake()
	{
		AddButtons();
//		if (_scroll!=null) _scroll.Init();
	}
	
	private void AddButtons()
	{
		if (_content==null) return;
		
		foreach (Set set in GameData.Levels.Sets)
		{
			GameObject newButton = Instantiate(_buttonPrefab,_content); 
			LevelSetButton sampleButton = newButton.GetComponent<LevelSetButton>();
			sampleButton.Setup(set);
		}
	}

}
