using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{

	[SerializeField] private Sprite[] _walkSide;
	[SerializeField] private Sprite[] _pushSide;
	[SerializeField] private Sprite[] _walkTop;
	[SerializeField] private Sprite[] _pushTop;

	private int walkSideCur;
	private int pushSideCur;
	private int walkTopCur;
	private int pushTopCur;

	private SpriteRenderer _renderer;
	
	private void Start ()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	public void Advance(MOVE status,Vector2 direction)
	{
		if (status == MOVE.PUSH)
			push(direction);
		else if (status == MOVE.WALK) 
			walk(direction);
	}

	private void walk(Vector2 direction)
	{
		if (direction.y != 0)
		{
			_renderer.flipX = false;
			_renderer.sprite = _walkTop[walkTopCur++ % _walkTop.Length];
			_renderer.flipY = direction.y > 0;
		}
		else
		{
			_renderer.flipY = false;
			_renderer.sprite = _walkSide[ walkSideCur++ % _walkSide.Length];
			_renderer.flipX = direction.x < 0;
		}
		
	}
	
	private void push(Vector2 direction)
	{
		if (direction.y != 0)
		{
			_renderer.flipX = false;
			_renderer.sprite = _pushTop[pushTopCur++ % _pushTop.Length];
			_renderer.flipY = direction.y > 0;
		}
		else
		{
			_renderer.flipY = false;
			_renderer.sprite = _pushSide[ pushSideCur++ % _pushSide.Length];
			_renderer.flipX = direction.x < 0;
		}
	}
	
	
}
