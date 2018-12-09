using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MovingObject))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private PlayerAnimator _animator;
	
	private MovingObject _motor;
	private bool _canMove;
	private bool _canUndo;
	private bool _paused;

	private void Start()
	{
		_motor = GetComponent<MovingObject>();
		PauseMenu.OnPause.AddListener(() => { _paused = true;});
		PauseMenu.OnUnPause.AddListener(() => { _paused = false;});
		StartCoroutine(WaitBeforeEnable());
	}

	private void Update()
	{
		if (_paused) return;
		if (!_canMove) return;

		int x = (int) Input.GetAxis("Horizontal");
		int y = (int) Input.GetAxis("Vertical");

		if (y != 0)
			x = 0;

		if (x != 0 || y != 0)
			Move(x,y);
		else if (Input.GetButton("Undo"))
			Undo();
	}
	
	private void Move(int x,int y)
	{
		if (!_canMove) return;
		
		Vector2 direction = new Vector2(x,y);
		MOVE result = _motor.move(direction);

		if (result == MOVE.FAIL )
			return;
		
		_animator.Advance(result,direction);

		GameManager.Instance.State.Move();
		StartCoroutine(MoveTimer());
	}

	private void Undo()
	{
		if (!_canUndo) return;
		
		GameManager.Instance.Undo();
		StartCoroutine(MoveTimer());
	}
	
	private IEnumerator MoveTimer()
	{
		_canMove = false;
		_canUndo = false;
		yield return new WaitForSeconds(GameData.Settings.moveTime);
		_canMove = true;
		yield return  new WaitForEndOfFrame();
		_canUndo = true;
	}

	private IEnumerator WaitBeforeEnable()
	{
		float delay = GameData.Settings.delayBeforeTransition + GameData.Settings.transitionDuration;
		yield return new WaitForSecondsRealtime(delay);
		_canUndo = true;
		_canMove = true;
	}
	
}
