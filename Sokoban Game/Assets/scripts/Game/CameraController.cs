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

	private void MoveCamera(LevelData data)
	{
		_anchor = new Vector3(data.width / 2 -.5f, -data.height/2 +.75f,-10);
		float size = data.height > data.width ? data.height : data.width;

		transform.position = _anchor;
		float dest = size/2;


		if (GameData.i.Settings.ZoomOnLevelChange)
		{
			_camera.orthographicSize = 100;
			_camera.DOOrthoSize(dest, GameData.i.Settings.transitionDuration)
				.SetDelay(GameData.i.Settings.delayBeforeTransition);
		}
		else
			_camera.orthographicSize = dest;
	}
}