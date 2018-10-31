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
	[SerializeField] private CanvasGroup _pauseMenu;
	[SerializeField] private GameObject _defaultActive;
	
	[Header("Options")]
	[SerializeField] private bool _showLevelInfo;

	public static UnityEvent OnPause;
	public static UnityEvent OnUnPause;

	private void Awake()
	{
		if (OnPause==null) OnPause = new UnityEvent();
		if (OnUnPause==null) OnUnPause = new UnityEvent();
	}

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
			Pause();
	}

	public void UnPause()
	{
		HideCanvas(_pauseMenu);
		EventSystem.current.SetSelectedGameObject(null);
		StartCoroutine(unPauseDelay());
	}

	public void Pause()
	{
		OnPause.Invoke();
		ShowCanvas(_pauseMenu);
		EventSystem.current.SetSelectedGameObject(_defaultActive);
	}

	private string LevelInfo()
	{
		if (!_showLevelInfo) return "";
		return "Boxes: "+GameManager.Instance.State.boxCount+
		       "\nGoals: "+GameManager.Instance.State.goalCount+
		       "\nDone: "+GameManager.Instance.State.boxesOnGoals+
		       "\nTotal: "+GameManager.Instance.State.totalMoves;
	}

	private IEnumerator unPauseDelay()
	{
		yield return new WaitForSecondsRealtime(.5f);
		OnUnPause.Invoke();
	}

	private void LevelUpdate(LevelData data)
	{
		_level.text = data.LevelName;
	}

	private static void HideCanvas(CanvasGroup canvas)
	{
		canvas.alpha = 0f;
		canvas.blocksRaycasts = false;
		canvas.interactable = false;
	}

	private static void ShowCanvas(CanvasGroup canvas)
	{
		canvas.alpha = 1f;
		canvas.blocksRaycasts = true;
		canvas.interactable = true;
	}
}
