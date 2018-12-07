using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{

	[SerializeField] private Button _skinButton;

	private Text _text;
	
	private void Start ()
	{
		_text = _skinButton.GetComponentInChildren<Text>();
		_skinButton.onClick.AddListener(ChangeSkin);
		_text.text = GameData.Skins.CurrentSkin().SkinName;
	}

	private void ChangeSkin()
	{
		Skin skin = GameData.Skins.NextSkin();
		_text.text = skin.SkinName;
	}
}
