using UnityEngine;
using UnityEngine.UI;

public class LevelSetButton : MonoBehaviour {

	public Button buttonComponent;
	public Text nameLabel;
	public Text progress;
	public Text author;
	
	public Image iconImage;
	
	private Set _set;
	private Levels _levels;
	
	private void Start () 
	{
		buttonComponent.onClick.AddListener(HandleClick);
	}

	public void Setup(Set set, Levels levels)
	{
		_set = set;
		nameLabel.text = set.Name;
		author.text = "by " + set.Author;
		progress.text = set.Complete ? "complete" : set.Progress+" of "+set.GetSize();
		_levels = levels;
	}
    
	public void HandleClick()
	{
		_levels.Set = _set;
	}

}
