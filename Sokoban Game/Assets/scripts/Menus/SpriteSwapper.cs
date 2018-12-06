using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SpriteSwapper : MonoBehaviour
{

	private Button _button;
	
	private void Start ()
	{
		_button = GetComponent<Button>();
		_button.transition = Selectable.Transition.SpriteSwap;
	}

	private void Update()
	{
	}

	private void HideGraphic()
	{
		_button.targetGraphic.color = Color.clear;
	}

	private void ShowGraphic()
	{
		_button.targetGraphic.color = Color.white;
	}
	
}
