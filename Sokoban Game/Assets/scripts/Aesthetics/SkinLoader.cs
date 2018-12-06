using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinLoader : MonoBehaviour
{
    [Header("GameObjects")] 
    
    [SerializeField] private GameObject _menu;
    [SerializeField] private TextMeshProUGUI[] _titles;
    [SerializeField] private Image[] _bgColor;
    [SerializeField] private Image[] _textColor;

//    private static Skins _skins;
    
    private void Start()
    {
//        if (_skins == null) _skins = GameData.Skins;
        GameData.Skins.onChangeSkin.AddListener(ChangeSkin);
        ChangeSkin(GameData.Skins.CurrentSkin());
    }

    // ReSharper disable once InvertIf
    private void ChangeSkin(Skin skin)
    {
        if (Camera.main != null) 
            Camera.main.backgroundColor = skin.Background;

        if (_menu != null)
        {
            foreach (var text in _menu.GetComponentsInChildren<Text>())
                text.color = skin.TextColor;
            foreach (var g in _menu.GetComponentsInChildren<Button>())
            {
                var block = g.colors;
                block.highlightedColor = new Color(.3f,.3f,.3f,1f);
                g.colors = block;
                g.gameObject.GetComponent<Graphic>().color = skin.ButtonColor;
            }
        }
        
        if (_textColor != null)
            foreach (var i in _textColor)
                i.color = skin.TextColor;
        
        if (_bgColor != null)
            foreach (var i in _bgColor)
                i.color = skin.Background;

        if (_titles != null)
            foreach (var i in _titles)
                i.color = skin.TextColor;
    }
}