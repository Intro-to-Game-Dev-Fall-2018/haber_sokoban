﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingObject))]
public class PlayerController : MonoBehaviour
{

	private MovingObject _motor;
	private bool _canMove;
	
	private void Awake()
	{
		_motor = GetComponent<MovingObject>();
		_canMove = true;
	}

	private void move(int x,int y)
	{
		if (!_canMove) return;
		
		var direction = new Vector2(x,y);
		var success = _motor.move(direction);

		if (!success) return;
		
		GameManager.Instance.State.moves++;
		StartCoroutine(moveTimer());
	}

	private void Update()
	{
		var x = (int) Input.GetAxis("Horizontal");
		var y = (int) Input.GetAxis("Vertical");

		if (y != 0)
			x = 0;

		if (x != 0 || y != 0)
			move(x,y);
		
	}
	
	private IEnumerator moveTimer()
	{
		_canMove = false;
		yield return new WaitForSeconds(GameManager.Instance.Settings.timeBetweenMoves);
		_canMove = true;
	}
	
}
