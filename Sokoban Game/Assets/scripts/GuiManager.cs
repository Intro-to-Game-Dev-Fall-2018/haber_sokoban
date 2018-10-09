using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _score;
	
	private void Update ()
	{
		_score.text = "Moves: " + GameManager.State.moves;
	}
}
