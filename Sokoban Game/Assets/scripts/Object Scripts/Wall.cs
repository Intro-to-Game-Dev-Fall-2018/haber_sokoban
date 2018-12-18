using UnityEngine;

public class Wall : MonoBehaviour {
	
	private void Awake()
	{
		GetComponent<SpriteRenderer>().sprite = GameData.i.Skins.CurrentSkin().WorldSprites.Wall;
	}
}
