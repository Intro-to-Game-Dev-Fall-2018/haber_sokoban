using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private Text _skinText;
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _levelMenu;
    [SerializeField] private CanvasGroup _instructions;

    [Header("Data")]
    [SerializeField] private Skins _skins;

    private void Start()
    {
        _skinText.text = _skins.CurrentSkin().SkinName;
        HideCanvas(_levelMenu);
        HideCanvas(_instructions);
    }

    private void Update()
    {
        if (Input.GetButton("Cancel"))
            MainMenu();
    }

    //public functions

    public void cycleSkins()
    {
        _skinText.text = _skins.NextSkin().SkinName;
    }

    public void LevelMenu()
    {
        HideCanvas(_mainMenu);
        HideCanvas(_instructions);
        ShowCanvas(_levelMenu);
    }

    public void MainMenu()
    {
        HideCanvas(_levelMenu);
        HideCanvas(_instructions);
        ShowCanvas(_mainMenu);
        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
    }

    public void ShowInstructions()
    {
        HideCanvas(_levelMenu);
        HideCanvas(_mainMenu);
        ShowCanvas(_instructions); 
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