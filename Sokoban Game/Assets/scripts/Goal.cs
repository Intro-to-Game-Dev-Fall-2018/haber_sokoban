using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

	[SerializeField] private LayerMask _boxLayer;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == _boxLayer)
			GameManager.Instance.State.boxesOnGoals++;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == _boxLayer)
			GameManager.Instance.State.boxesOnGoals--;	}
}
