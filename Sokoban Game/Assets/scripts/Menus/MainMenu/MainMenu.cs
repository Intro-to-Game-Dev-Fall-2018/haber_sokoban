using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _levelSelectButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _instructionsButton;
    [SerializeField] private Button[] _mainMenuButtons;

    [Header("Menu")]
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _levelSelectMenu;
    [SerializeField] private CanvasGroup _optionsMenu;
    [SerializeField] private CanvasGroup _instructions;


    private void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _levelSelectButton.onClick.AddListener(() => Focus(_levelSelectMenu));
        _optionsButton.onClick.AddListener(() => Focus(_optionsMenu));
        _instructionsButton.onClick.AddListener(()=> Focus(_instructions));

        foreach (Button b in _mainMenuButtons)
            b.onClick.AddListener(() => Focus(_mainMenu));

        Focus(_mainMenu);
    }

    //Functions

    private void StartGame()
    {
        StartCoroutine(Loader.LoadGame());
    }

    private void Focus(CanvasGroup group)
    {
        HideAll();
        ShowCanvas(group);
    }

    private void HideAll()
    {
        HideCanvas(_mainMenu);
        HideCanvas(_levelSelectMenu);
        HideCanvas(_optionsMenu);
        HideCanvas(_instructions);
    }

    //Static Methods

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