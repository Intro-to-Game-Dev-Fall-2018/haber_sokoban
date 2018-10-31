using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

	[SerializeField] private CanvasGroup _pauseMenu;
	[SerializeField] private GameObject _defaultActive;
	
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
	}
	
	private void Update ()
	{
		if (Input.GetButton("Cancel"))
			Pause();
	}

	public void UnPause()
	{
		HideCanvas(_pauseMenu);
		EventSystem.current.SetSelectedGameObject(null);
		StartCoroutine(UnPauseDelay());
	}

	public void Pause()
	{
		OnPause.Invoke();
		ShowCanvas(_pauseMenu);
		EventSystem.current.SetSelectedGameObject(_defaultActive);
	}
	
	private static IEnumerator UnPauseDelay()
	{
		yield return new WaitForSecondsRealtime(.5f);
		OnUnPause.Invoke();
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
