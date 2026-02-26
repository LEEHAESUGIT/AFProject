using System;
using UnityEngine;

public interface ICamera
{
	public void Move(CameraInfo info);
	public void Zoom(CameraInfo info);
}

public class CameraController : MonoBehaviour
{
	private ICamera strategy;

	CameraController() { }

	void Start()
	{
		if (Camera.main.orthographic)
		{
			GetComponent<CameraInfo>().SetOrthoGraphic();
			strategy = new Projection_OrthoGraphic();
		}
		else
		{
			GetComponent<CameraInfo>().SetPerspective();
			strategy = new Projection_Perspective();
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		strategy.Move(this.GetComponent<CameraInfo>());
		strategy.Zoom(this.GetComponent<CameraInfo>());
	}

}


public class Projection_OrthoGraphic : ICamera
{
	public  void Move(CameraInfo info)
	{
		//Keyboard
		if (Input.GetKey(KeyCode.W)) { Camera.main.transform.position += new Vector3(0, 1f, 0) * info.cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.S)) { Camera.main.transform.position += new Vector3(0, -1f, 0) * info.cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.A)) { Camera.main.transform.position += new Vector3(-1f, 0, 0) * info.cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.D)) { Camera.main.transform.position += new Vector3(1f, 0, 0) * info.cameraMoveSpeed * Time.deltaTime; }
		//mouse ScrollWheel Click
		if (Input.GetKey(KeyCode.Mouse2))
		{
			float mousePosX = -Input.GetAxis("Mouse X");
			float mousePosY = -Input.GetAxis("Mouse Y");

			Camera.main.transform.position += new Vector3(mousePosX, mousePosY, 0) * info.cameraMoveSpeed * Time.deltaTime;
		}
	}
	public void Zoom(CameraInfo info)
	{
		float zoomDirection = Input.GetAxis("Mouse ScrollWheel");
		Camera.main.orthographicSize += zoomDirection * info.cameraZoomSpeed;
		if (Camera.main.orthographicSize >= info.cameraZoomMax)
			Camera.main.orthographicSize = info.cameraZoomMax;
		if (Camera.main.orthographicSize <= info.cameraZoomMin)
			Camera.main.orthographicSize = info.cameraZoomMin;
	}
}
public class Projection_Perspective : ICamera
{
	public void Move(CameraInfo info)
	{
		//Keyboard
		if (Input.GetKey(KeyCode.W)) { Camera.main.transform.position += new Vector3(0, 1f, 0) * info.cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.S)) { Camera.main.transform.position += new Vector3(0, -1f, 0) * info.cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.A)) { Camera.main.transform.position += new Vector3(-1f, 0, 0) * info.cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.D)) { Camera.main.transform.position += new Vector3(1f, 0, 0) * info.cameraMoveSpeed * Time.deltaTime; }
		//mouse ScrollWheel Click
		if (Input.GetKey(KeyCode.Mouse2))
		{
			float mousePosX = -Input.GetAxis("Mouse X");
			float mousePosY = -Input.GetAxis("Mouse Y");

			Camera.main.transform.position += new Vector3(mousePosX, mousePosY, 0) * info.cameraMoveSpeed * Time.deltaTime;
		}
	}
	public void Zoom(CameraInfo info)
	{
		float zoomDirection = Input.GetAxis("Mouse ScrollWheel");
		Camera.main.fieldOfView += zoomDirection * info.cameraZoomSpeed;
		if (Camera.main.fieldOfView >= info.cameraZoomMax)
			Camera.main.fieldOfView = info.cameraZoomMax;
		if (Camera.main.fieldOfView <= info.cameraZoomMin)
			Camera.main.fieldOfView = info.cameraZoomMin;
	}
}
