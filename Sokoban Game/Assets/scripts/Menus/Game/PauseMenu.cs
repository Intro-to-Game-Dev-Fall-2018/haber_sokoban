using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	[Header("Components")]
	[SerializeField] private CanvasGroup _pauseMenu;
	[SerializeField] private LevelManager _levelManager;

	[Header("Buttons")]
	[SerializeField] private Button _continue;
	[SerializeField] private Button _reset;
	[SerializeField] private Button _quit;

	public static UnityEvent OnPause;
	public static UnityEvent OnUnPause;
	
	private void Awake()
	{
		if (OnPause==null) OnPause = new UnityEvent();
		if (OnUnPause==null) OnUnPause = new UnityEvent();
	}

	private void Start()
	{
		UnPause();
		_continue.onClick.AddListener(UnPause);
		_reset.onClick.AddListener(ResetLevel);
		_quit.onClick.AddListener(() => { StartCoroutine(Loader.LoadMenu());});
	}

	private void Update ()
	{
		if (Input.GetButton("Cancel"))
			Pause();
	}
	
	private void ResetLevel()
	{
		_levelManager.ResetLevel();	
		UnPause();
	}

	public void UnPause()
	{
		HideCanvas(_pauseMenu);
		EventSystem.current.SetSelectedGameObject(null);
		OnUnPause.Invoke();
	}

	public void Pause()
	{
		OnPause.Invoke();
		ShowCanvas(_pauseMenu);
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

//	
//	private static IEnumerator UnPauseDelay()
//	{
//		yield return new WaitForSecondsRealtime(.5f);
//		OnUnPause.Invoke();
//	}
