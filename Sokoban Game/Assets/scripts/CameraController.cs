using UnityEngine;

public class CameraController : MonoBehaviour
{

	private Camera _camera;
	private string _sceneName;
	
	private void Start ()
	{
		_camera = GetComponent<Camera>();
	}
	
	private void Update ()
	{
		if (_sceneName == GameManager.Instance.State.levelName) return;

		_sceneName = GameManager.Instance.State.levelName;
		var pos = new Vector3(GameManager.Instance.State.levelWidth / 2 -1, -GameManager.Instance.State.levelHeight/2 +.5f,-10);
		_camera.orthographicSize = GameManager.Instance.State.levelHeight/2;
		transform.position = pos;

	}
}
