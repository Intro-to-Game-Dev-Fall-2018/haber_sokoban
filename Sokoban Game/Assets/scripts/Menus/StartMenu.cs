using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

	[Header("Menu")]
	[SerializeField] private Text _levelText;
	[SerializeField] private Text _skinText;
	[SerializeField] private CanvasGroup _mainMenu;
	[SerializeField] private CanvasGroup _levelMenu;
	
	[Header("Data")]
	[SerializeField] private Levels _levels;
	[SerializeField] private Skins _skins;

	public void startGame()
	{
		StartCoroutine(LoadGame());
	}

	public void cycleSkins()
	{
		_skinText.text = _skins.NextSkin().SkinName;
	}

	public void LevelMenu()
	{
		MainMenu();
		if (_levelMenu.blocksRaycasts)
		{
			_levelMenu.alpha = 0f;
			_levelMenu.blocksRaycasts = false;
		}
		else
		{
			_levelMenu.alpha = 1f;
			_levelMenu.blocksRaycasts = true;
		}
	}
	
	public void MainMenu()
	{
		if (_mainMenu.blocksRaycasts)
		{
			_mainMenu.alpha = 0f;
			_mainMenu.blocksRaycasts = false;
		}
		else
		{
			_mainMenu.alpha = 1f;
			_mainMenu.blocksRaycasts = true;
		}
	}
	
	private void Start()
	{
		_levelText.text = "level set";//_levels.Set.Name;
		_skinText.text = _skins.CurrentSkin().SkinName;
		LevelMenu();
		MainMenu();
	}
	
	private IEnumerator LoadGame()
	{
		yield return new WaitForSeconds(.1f);
		var op = SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("menu");
		yield return op;
	}

}

