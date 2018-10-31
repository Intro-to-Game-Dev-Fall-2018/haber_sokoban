using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private Text _skinText;
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _instructions;
    
    private Skins _skins;
    private bool _showInstructions;

    private void Start()
    {
        _skins = GameData.Skins;
        _skinText.text = _skins.CurrentSkin().SkinName;
        HideCanvas(_instructions);
    }

    private void Update()
    {
        if (_showInstructions && Input.anyKey)
            ShowMainMenu();
    }

    //public functions

    public void cycleSkins()
    {
        _skinText.text = _skins.NextSkin().SkinName;
    }
    
    public void ShowMainMenu()
    {
        _showInstructions = false;
        HideCanvas(_instructions);
        ShowCanvas(_mainMenu);
        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
    }

    public void ShowInstructions()
    {
        StartCoroutine(controlMenu());
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

    private IEnumerator controlMenu()
    {
        yield return new WaitForSecondsRealtime(.5f);
        _showInstructions = true;
    }
}