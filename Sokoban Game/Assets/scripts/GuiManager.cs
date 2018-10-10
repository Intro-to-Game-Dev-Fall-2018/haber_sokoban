using System;
using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _score;
	[SerializeField] private TextMeshProUGUI _level;
	[SerializeField] private TextMeshProUGUI _levelInfo;
	
	private void Update ()
	{
		_score.text = "Moves: " + GameManager.Instance.State.moves;
		_level.text = GameManager.Instance.State.levelName;
		_levelInfo.text = 
			"Boxes: "+GameManager.Instance.State.boxCount+
			"\nGoals: "+GameManager.Instance.State.goalCount+
		    "\nComplete: "+GameManager.Instance.State.boxesOnGoals;
	}
}
