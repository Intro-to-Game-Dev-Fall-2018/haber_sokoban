using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _score;
	[SerializeField] private TextMeshProUGUI _level;
	[SerializeField] private TextMeshProUGUI _levelInfo;
	[SerializeField] private CanvasGroup _pauseMenu;
	
	[Header("Options")]
	[SerializeField] private bool _showLevelInfo;

	private void Start()
	{
		LevelManager.onLevelUpdate.AddListener(LevelUpdate);
		UnPause();
	}
		
	private void Update ()
	{
		_score.text = GameManager.Instance.State.moves.ToString("D4");
		_levelInfo.text = LevelInfo();

		if (Input.GetButton("Cancel"))
			ShowCanvas(_pauseMenu);
	}

	public void UnPause()
	{
		HideCanvas(_pauseMenu);
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

	private static void HideCanvas(CanvasGroup canvas)
	{
		canvas.alpha = 0f;
		canvas.blocksRaycasts = false;
	}

	private static void ShowCanvas(CanvasGroup canvas)
	{
		canvas.alpha = 1f;
		canvas.blocksRaycasts = true;
	}
}
