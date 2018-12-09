using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	private Camera _camera;
	private Vector3 _anchor;
	
	private void Start()
	{
		_camera = GetComponent<Camera>();
		LevelManager.onLevelUpdate.AddListener(MoveCamera);
	}

	private void Update()
	{
		if (!GameData.Settings.CameraMovement) return;
		
		float x = Input.GetAxis("Vertical");
		float y = Input.GetAxis("Horizontal");
		Vector3 dest = new Vector3(y/2, x/2);
		
		transform.position = Vector3.MoveTowards(transform.position,_anchor + dest,1f*Time.deltaTime);
	}

	private void MoveCamera(LevelData data)
	{
		_anchor = new Vector3(data.width / 2 -.5f, -data.height/2 +.75f,-10);
		float size = data.height > data.width ? data.height : data.width;

		transform.position = _anchor;
		float dest = size/2+1;


		if (GameData.Settings.ZoomOnLevelChange)
		{
			_camera.orthographicSize = 100;
			_camera.DOOrthoSize(dest, GameData.Settings.transitionDuration)
				.SetDelay(GameData.Settings.delayBeforeTransition);
		}
		else
			_camera.orthographicSize = dest;
	}
}