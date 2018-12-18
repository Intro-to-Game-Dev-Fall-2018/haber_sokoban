using System.Collections;
using UnityEngine;

public class Goal : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<SpriteRenderer>().sprite = GameData.i.Skins.CurrentSkin().WorldSprites.Goal;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Box"))
			StartCoroutine(DelayScore());
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Box")) 
			GameManager.Instance.State.boxesOnGoals--;
	}

	private IEnumerator DelayScore()
	{
		yield return new WaitForSeconds(GameData.i.Settings.moveTime+.05f);
		GameManager.Instance.State.boxesOnGoals++;
	}

}
