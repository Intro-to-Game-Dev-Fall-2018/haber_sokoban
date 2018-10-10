using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _score;
	[SerializeField] private TextMeshProUGUI _level;
	
	private void Update ()
	{
		_score.text = "Moves: " + GameManager.Instance.State.moves;
		_level.text = GameManager.Instance.State.levelName;
	}
}
