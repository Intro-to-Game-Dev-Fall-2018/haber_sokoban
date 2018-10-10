using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingObject))]
public class PlayerController : MonoBehaviour
{

	private MovingObject _motor;
	
	private void Awake()
	{
		_motor = GetComponent<MovingObject>();
	}

	private void move(int x,int y)
	{
		if (_motor.move(new Vector2(x,y)))
			GameManager.Instance.State.moves++;
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
	
}
