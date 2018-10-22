﻿using System.Collections;
using UnityEngine;

public class Goal : MonoBehaviour
{

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
		yield return new WaitForSeconds(GameManager.Instance.Settings.moveTime+.05f);
		GameManager.Instance.State.boxesOnGoals++;
	}

}
