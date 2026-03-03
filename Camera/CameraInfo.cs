using UnityEngine;

public class CameraInfo : MonoBehaviour
{
	[field: SerializeField]
	public float cameraMoveSpeed { get; private set; }
	[field: SerializeField]
	public float cameraZoomSpeed { get; private set; }
	[field: SerializeField]
	public float cameraZoomMax { get; private set; }
	[field: SerializeField]
	public float cameraZoomMin { get; private set; }

	//private void Start()
	//{
	//	// default : perspective
	//	this.cameraMoveSpeed = 10f;
	//	this.cameraZoomSpeed = 50f;
	//	this.cameraZoomMax = 150f;
	//	this.cameraZoomMin = 10f;
	//}

	public void SetOrthoGraphic()
	{
		this.cameraMoveSpeed = 10f;
		this.cameraZoomSpeed = 5f;
		this.cameraZoomMax = 25f;
		this.cameraZoomMin = 1f;
	}
	public void SetPerspective()
	{
		this.cameraMoveSpeed = 10f;
		this.cameraZoomSpeed = 50f;
		this.cameraZoomMax = 150f;
		this.cameraZoomMin = 10f;
	}

}
