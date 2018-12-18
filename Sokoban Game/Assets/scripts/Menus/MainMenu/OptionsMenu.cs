using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Button _skinButton;
    [SerializeField] private Button _cameraZoomButton;

    private void Start()
    {
        _skinButton.onClick.AddListener(() =>
        {
            GameData.i.Skins.NextSkin();
            Refresh();
        });
        
        _cameraZoomButton.onClick.AddListener(() =>
        {
            GameData.i.Settings.ZoomOnLevelChange ^= true;
            Refresh();
        });

        Refresh();
    }


    private void Refresh()
    {
        _cameraZoomButton.GetComponentInChildren<Text>().text =
            GameData.i.Settings.ZoomOnLevelChange ? "Zoom Camera" : "Static Camera";
        _skinButton.GetComponentInChildren<Text>().text =
            "skin: " + GameData.i.Skins.CurrentSkin().SkinName;
    }
}