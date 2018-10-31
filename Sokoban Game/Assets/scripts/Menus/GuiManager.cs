using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GuiManager : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _score;
	[SerializeField] private TextMeshProUGUI _level;
	[SerializeField] private TextMeshProUGUI _levelInfo;
	
	[Header("Options")]
	[SerializeField] private bool _showLevelInfo;

	private void Start()
	{
		LevelManager.onLevelUpdate.AddListener(LevelUpdate);
	}
		
	private void Update ()
	{
		_score.text = GameManager.Instance.State.moves.ToString("D4");
		_levelInfo.text = LevelInfo();
	}

	private string LevelInfo()
	{
		if (!_showLevelInfo) return "";
		return "Boxes: "+GameManager.Instance.State.boxCount+
		       "\nGoals: "+GameManager.Instance.State.goalCount+
		       "\nDone: "+GameManager.Instance.State.boxesOnGoals+
		       "\nTotal: "+GameManager.Instance.State.totalMoves;
	}

	private void LevelUpdate(LevelData data)
	{
		_level.text = data.LevelName;
	}

}
