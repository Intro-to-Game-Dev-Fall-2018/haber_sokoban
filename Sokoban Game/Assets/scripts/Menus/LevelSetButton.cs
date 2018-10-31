using UnityEngine;
using UnityEngine.UI;

public class LevelSetButton : MonoBehaviour {

	public Button buttonComponent;
	public Text nameLabel;
	public Text progress;
	public Text author;
	
	public Image iconImage;
	
	private Set _set;
	private static Levels _levels;

	private void OnEnable()
	{
		_levels = GameData.Levels;
		buttonComponent.onClick.AddListener(HandleClick);
	}

	public void Setup(Set set)
	{
		_set = set;
		nameLabel.text = set.Name;
		author.text = "by " + set.Author;
		progress.text = set.Complete ? "complete" : set.Progress+" of "+set.GetSize();
	}
    
	public void HandleClick()
	{
		_levels.Set = _set;
		print(_set.Name);
		StartCoroutine(Loader.LoadGame());
	}

}
