using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [Header("Menu")] [SerializeField] private Text _levelText;
    [SerializeField] private Text _skinText;
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _levelMenu;
    [SerializeField] private CanvasGroup _instructions;

    [Header("Data")] [SerializeField] private Levels _levels;
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
            HideCanvas(_levelMenu);
        else
            ShowCanvas(_levelMenu);
        _levelText.text = _levels.Set.Name;
    }

    public void MainMenu()
    {
        if (_mainMenu.blocksRaycasts)
            HideCanvas(_mainMenu);
        else
            ShowCanvas(_mainMenu);
    }

    public void ShowInstructions()
    {
        MainMenu();
        if (_instructions.blocksRaycasts)
            HideCanvas(_instructions);
        else
            ShowCanvas(_instructions); 
    }

    private void Start()
    {
        _skinText.text = _skins.CurrentSkin().SkinName;
        HideCanvas(_levelMenu);
        HideCanvas(_instructions);
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(.1f);
        var op = SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("menu");
        yield return op;
    }

    private void HideCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 0f;
        canvas.blocksRaycasts = false;
    }

    private void ShowCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 1f;
        canvas.blocksRaycasts = true;
    }
}