using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	private Camera _camera;
	
	private void Start()
	{
		_camera = GetComponent<Camera>();
		LevelManager.onLevelUpdate.AddListener(MoveCamera);
	}

	private void Update()
	{
		float vert = Input.GetAxis("Vertical");
		float hor = Input.GetAxis("Horizontal");

//		_camera.transform.position = _camera.transform.position + new Vector3(hor, vert);
	}

	private void MoveCamera(LevelData data)
	{
		Vector3 pos = new Vector3(data.width / 2 -.5f, -data.height/2 +.75f,-10);
		float size = data.height > data.width ? data.height : data.width;

//		_camera.orthographicSize = size/2+1;
		transform.position = pos;
		
		float dest = size/2+1;
		_camera.orthographicSize = 100;

		_camera.DOOrthoSize(dest, GameData.Settings.transitionDuration)
			.SetDelay(GameData.Settings.delayBeforeTransition);
	}
}