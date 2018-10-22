using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{

	[SerializeField] private Skins _skins;
	private Camera _camera;
	
	private void Awake ()
	{
		_camera = GetComponent<Camera>();
		LevelManager.onLevelUpdate.AddListener(MoveCamera);
		_camera.backgroundColor = _skins.CurrentSkin().background;
	}
	
	private void MoveCamera(LevelData data)
	{
		var pos = new Vector3(data.width / 2 -.5f, -data.height/2 +.5f,-10);
		var size = data.height > data.width ? data.height : data.width;

		_camera.orthographicSize = size/2;
		transform.position = pos;

	}
}