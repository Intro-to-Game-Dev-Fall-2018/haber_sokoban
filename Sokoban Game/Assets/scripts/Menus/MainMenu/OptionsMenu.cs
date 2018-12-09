using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	[SerializeField] private Button _skinButton;
//	[SerializeField] private Button _cameraMove;
	
	private void Start ()
	{
		_skinButton.onClick.AddListener(ChangeSkin);
//		_cameraMove.onClick.AddListener(ToggleCamera);
		
		_skinButton.GetComponentInChildren<Text>().text = GameData.Skins.CurrentSkin().SkinName;
	}

	private void ChangeSkin()
	{
		Skin skin = GameData.Skins.NextSkin();
		_skinButton.GetComponentInChildren<Text>().text = skin.SkinName;
	}

	private void ToggleCamera()
	{
		bool b = !GameData.Settings.CameraMovement;
		GameData.Settings.CameraMovement = b;
//		_cameraMove.GetComponentInChildren<Text>().text = b ? "Dynamic Camera" : "Static Camera";
	}
}
