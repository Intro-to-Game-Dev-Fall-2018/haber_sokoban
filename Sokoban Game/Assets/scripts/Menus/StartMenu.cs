using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

	[SerializeField] private Text _levelText;
	[SerializeField] private Text _skinText;
	[SerializeField] private Levels _levels;
	[SerializeField] private Skins _skins;


	public void startGame()
	{
		StartCoroutine(LoadGame());
	}

	public void cycleLevelSets()
	{
		_levelText.text = _levels.nextLevelSet().name;
	}

	public void cycleSkins()
	{
		_skinText.text = _skins.NextSkin().SkinName;
	}
	
	private void Start()
	{
		_levelText.text = _levels.getLevelSet().name;
		_skinText.text = _skins.CurrentSkin().SkinName;
	}
	
	private IEnumerator LoadGame()
	{
		yield return new WaitForSeconds(.1f);
		var op = SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("menu");
		yield return op;
	}

}

