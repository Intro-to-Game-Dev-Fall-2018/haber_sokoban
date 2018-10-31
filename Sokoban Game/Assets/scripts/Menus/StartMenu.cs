using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class StartMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private Text _skinText;
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _instructions;
    
    private Skins _skins;

    private void Start()
    {
        _skins = GameData.Skins;
        _skinText.text = _skins.CurrentSkin().SkinName;
        HideCanvas(_instructions);
    }

    private void Update()
    {
        if (Input.GetButton("Cancel"))
            MainMenu();
        
        if (EventSystem.current.currentSelectedGameObject==null) 
           EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
    }

    //public functions

    public void cycleSkins()
    {
        _skinText.text = _skins.NextSkin().SkinName;
    }
    
    public void MainMenu()
    {
        HideCanvas(_instructions);
        ShowCanvas(_mainMenu);
        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
    }

    public void ShowInstructions()
    {
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