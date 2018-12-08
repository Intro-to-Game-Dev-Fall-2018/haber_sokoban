using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

	[SerializeField] private Button _next;
	[SerializeField] private Button _prev;

	[SerializeField] private TextMeshProUGUI _title;
	[SerializeField] private TextMeshProUGUI _author;
	[SerializeField] private TextMeshProUGUI _progress;
	[SerializeField] private TextMeshProUGUI _description;

	
	private void Start () {
		_next.onClick.AddListener(()=>{Iterate(1);});
		_prev.onClick.AddListener(()=>{Iterate(-1);});

		UpdateInformation(GameData.Levels.Set);
	}

	private void Iterate(int amount)
	{
		Set current = GameData.Levels.Iterate(amount);
		UpdateInformation(current);
	}

	private void UpdateInformation(Set set)
	{
		_title.text = set.Name;
		_author.text = "by " + set.Author;
		_progress.text = set.Complete ? "complete" : set.Progress+" of "+set.GetSize();
		_description.text = set.Description;
	}
}
