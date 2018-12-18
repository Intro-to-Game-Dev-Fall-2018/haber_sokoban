using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinLoader : MonoBehaviour
{
    [Header("GameObjects")] 
    
    [SerializeField] private GameObject _menu;
    [SerializeField] private Image[] _bgColor;
    [SerializeField] private Image[] _textColor;

    private void Start()
    {
        GameData.i.Skins.onChangeSkin.AddListener(ChangeSkin);
        ChangeSkin(GameData.i.Skins.CurrentSkin());
    }

    // ReSharper disable once InvertIf
    private void ChangeSkin(GameSkin skin)
    {
        if (Camera.main != null) 
            Camera.main.backgroundColor = skin.Background;

        if (_menu != null)
        {
            foreach (Text text in _menu.GetComponentsInChildren<Text>())
                text.color = skin.TextColor;

            foreach (TextMeshProUGUI tmp in _menu.GetComponentsInChildren<TextMeshProUGUI>())
                tmp.color = skin.TextColor;
        }
        
        if (_bgColor != null)
            foreach (Image i in _bgColor)
                i.color = skin.Background;
        
        if (_textColor != null)
            foreach (Image i in _textColor)
                i.color = skin.TextColor;
        
 
    }

    // ReSharper disable once InvertIf
//    private void ChangeSkin(Skin skin)
//    {
//        if (Camera.main != null) 
//            Camera.main.backgroundColor = skin.Background;
//
//        if (_menu != null)
//        {
//            foreach (Text text in _menu.GetComponentsInChildren<Text>())
//                text.color = skin.TextColor;
//                
//            foreach (Button button in _menu.GetComponentsInChildren<Button>())
//            {
//                
//                ColorBlock block = button.colors;
//                Graphic graphic = button.gameObject.GetComponent<Graphic>();
//                Image image = button.gameObject.GetComponent<Image>();
//
//                image.sprite = null;
//
//                block.highlightedColor = Color.gray;
//                block.disabledColor = Color.white;
//                block.normalColor = Color.white;
//                block.pressedColor = Color.gray;
//                block.colorMultiplier = 1;
//                
//                button.colors = block;
//                graphic.color = skin.ButtonColor;
//            }
//        }
//        
//        if (_textColor != null)
//            foreach (Image i in _textColor)
//                i.color = skin.TextColor;
//        
//        if (_bgColor != null)
//            foreach (Image i in _bgColor)
//                i.color = skin.Background;
//
//        if (_titles != null)
//            foreach (TextMeshProUGUI i in _titles)
//                i.color = skin.TextColor;
//    }
}