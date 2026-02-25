using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	Camera mainCamera;

	[field: SerializeField]
	public float cameraMoveSpeed { get; private set; }
	[field: SerializeField]
	public float cameraZoomSpeed { get; private set; }
	[field: SerializeField]
	public float cameraZoomMax { get; private set; }
	[field: SerializeField]
	public float cameraZoomMin { get; private set; }
	[field: SerializeField]
	public float zoomDirection { get; private set; }




	void Start()
	{
		mainCamera = this.GetComponent<Camera>();
		cameraMoveSpeed = 100f;
		cameraZoomSpeed = 50f;
		cameraZoomMax = 150f;
		cameraZoomMin = 10f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		zoom();
		move();

	}

	private void move()
	{
		//Keyboard
		if (Input.GetKey(KeyCode.W)) { transform.position += new Vector3(0, 1f, 0) * cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.S)) { transform.position += new Vector3(0, -1f, 0) * cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.A)) { transform.position += new Vector3(-1f, 0, 0) * cameraMoveSpeed * Time.deltaTime; }
		if (Input.GetKey(KeyCode.D)) { transform.position += new Vector3(1f, 0, 0) * cameraMoveSpeed * Time.deltaTime; }
		//mouse ScrollWheel Click
		if (Input.GetKey(KeyCode.Mouse2))
		{
			float mousePosX = -Input.GetAxis("Mouse X");
			float mousePosY = -Input.GetAxis("Mouse Y");

			transform.position += new Vector3(mousePosX, mousePosY, 0) * cameraMoveSpeed * Time.deltaTime;	
		}
	}
	private void zoom()
	{
		zoomDirection = Input.GetAxis("Mouse ScrollWheel");
		mainCamera.fieldOfView += zoomDirection * cameraZoomSpeed;
		if (mainCamera.fieldOfView >= cameraZoomMax)
			mainCamera.fieldOfView = cameraZoomMax;
		if (mainCamera.fieldOfView <= cameraZoomMin)
			mainCamera.fieldOfView = cameraZoomMin;
	}

}
