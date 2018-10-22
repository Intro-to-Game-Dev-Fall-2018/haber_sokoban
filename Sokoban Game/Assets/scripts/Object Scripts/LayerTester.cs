using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTester : MonoBehaviour {

	[Header("Layer Masks")]
	[SerializeField] private LayerMask _wallLayer;
	[SerializeField] private LayerMask _boxLayer;
	
	public bool BoxCheck(Vector2 newPosition)
	{
		return Physics2D.OverlapPoint(newPosition,_boxLayer) != null;
	} 
	
	public bool WallCheck(Vector2 newPosition)
	{
		return Physics2D.OverlapPoint(newPosition, _wallLayer) != null;
	}

}
