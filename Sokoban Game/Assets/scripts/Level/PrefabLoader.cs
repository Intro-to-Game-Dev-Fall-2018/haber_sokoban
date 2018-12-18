using UnityEngine;

public class PrefabLoader : MonoBehaviour
{

	public Box Box;
	public Goal Goal;
	public GameObject Wall;
	public PlayerAnimator2 Player;
	
	private void Start () {
		
		GameData.i.Skins2.onChangeSkin.AddListener(SetActivePrefabs);
		SetActivePrefabs(GameData.i.Skins2.CurrentSkin());
	}

	private void SetActivePrefabs(GameSkin skin)
	{
		Goal.GetComponent<SpriteRenderer>().sprite = skin.WorldSprites.Goal;
		Wall.GetComponent<SpriteRenderer>().sprite = skin.WorldSprites.Wall;
		Player.ChangeSkin(skin.PlayerSprites);
	}
}
