﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinLoader : MonoBehaviour
{
	[Header("Skins")]
	[SerializeField] private Skins _skins;

	[Header("GameObjects")] 
	[SerializeField] private GameObject _menu;
	[SerializeField] private Camera _camera;
	[SerializeField] private Image _background;
	[SerializeField] private TextMeshProUGUI[] _titles;
	[SerializeField] private Image[] _buttons;
	
	private void Start () {
		_skins.onChangeSkin.AddListener(onChangeSkin);
		onChangeSkin(_skins.CurrentSkin());
	}

	private void onChangeSkin(Skin skin)
	{
		if (_camera!=null) 
			_camera.backgroundColor = skin.Background;
		if (_background != null) 
			_background.color = skin.Background;
		if (_menu!=null) 
			foreach (var text in _menu.GetComponentsInChildren<Text>())
				text.color = skin.TextColor;
		if (_titles != null)
			foreach (var title in _titles)
				title.color = skin.TextColor;
		if (_buttons != null)
			foreach (var button in _buttons)
				button.color = skin.ButtonColor;
	}
}