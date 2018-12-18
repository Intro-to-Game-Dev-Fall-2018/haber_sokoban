﻿using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator2 : MonoBehaviour
{
	private int walkSideCur;
	private int pushSideCur;
	private int walkTopCur;
	private int pushTopCur;

	private SpriteRenderer _renderer;
	private PlayerSprites _sprites;
	
	private void Start ()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_sprites = GameData.i.Skins2.CurrentSkin().PlayerSprites;
	}

	public void Advance(MOVE status,Vector2 direction)
	{
		if (status == MOVE.PUSH)
			push(direction);
		else if (status == MOVE.WALK) 
			walk(direction);
	}

	public void ChangeSkin(PlayerSprites newSprites)
	{
		_sprites = newSprites;
		walkSideCur = pushSideCur = walkTopCur = pushTopCur = 0;
	}

	private void walk(Vector2 direction)
	{
		if (direction.y != 0)
		{
			_renderer.flipX = false;
			_renderer.sprite = _sprites.WalkTop[walkTopCur++ % _sprites.WalkTop.Length];
			_renderer.flipY = direction.y > 0;
		}
		else
		{
			_renderer.flipY = false;
			_renderer.sprite = _sprites.WalkSide[ walkSideCur++ % _sprites.WalkSide.Length];
			_renderer.flipX = direction.x < 0;
		}
		
	}
	
	private void push(Vector2 direction)
	{
		if (direction.y != 0)
		{
			_renderer.flipX = false;
			_renderer.sprite = _sprites.PushTop[pushTopCur++ % _sprites.PushTop.Length];
			_renderer.flipY = direction.y > 0;
		}
		else
		{
			_renderer.flipY = false;
			_renderer.sprite = _sprites.PushSide[ pushSideCur++ % _sprites.PushSide.Length];
			_renderer.flipX = direction.x < 0;
		}
	}
	
	
}
