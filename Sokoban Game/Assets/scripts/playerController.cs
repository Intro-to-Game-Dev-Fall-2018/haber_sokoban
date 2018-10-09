using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingObject))]
public class playerController : MonoBehaviour
{

	private MovingObject _motor;
	
	private void Start()
	{
		_motor = GetComponent<MovingObject>();
	}

	private void move(int x,int y)
	{
		_motor.move(x, y);
	}

	private void Update()
	{
		var x = (int) Input.GetAxis("Horizontal");
		var y = (int) Input.GetAxis("Vertical");

		if (y != 0)
			y = 0;

		if (x != 0 || y != 0)
			move(x,y);
		
	}
	
}
