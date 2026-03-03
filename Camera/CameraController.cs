using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public interface ICamera
{
	public void Move_KeyBoard(Vector2 moveVector);

	public void Move_MouseWheel_Delta(Vector2 moveDelta);

	public void Zoom_MouseWheel_Scroll(float axisValue);
	
}

public class CameraController : MonoBehaviour
{
	private ICamera strategy;
	private CameraInfo cameraInfo;

	private GameInput gameInput;
	// Camera Move
	// Keyboard
	private InputAction moveAction_Type_Keyboard;

	// mouse
	private InputAction moveAction_Type_WheelDown;
	private InputAction moveAction_Type_MouseDelta;


	// Camera Zoom
	private InputAction zoomAction_Type_Mouse;

	private void Awake()
	{
		gameInput = new GameInput();
		moveAction_Type_Keyboard = gameInput.Camera.Move_Keyboard;

		moveAction_Type_WheelDown = gameInput.Camera.Mouse_WheelDown;
		moveAction_Type_MouseDelta = gameInput.Camera.Mouse_Delta;

		zoomAction_Type_Mouse = gameInput.Camera.Zoom_MouseWheel;

	}

	void Start()
	{
		
		cameraInfo = this.GetComponent<CameraInfo>();

		if (Camera.main.orthographic)
		{
			cameraInfo.SetOrthoGraphic();
			strategy = new Projection_OrthoGraphic(cameraInfo);
		}
		else
		{
			cameraInfo.SetPerspective();
			strategy = new Projection_Perspective(cameraInfo);
		}
	}
	private void OnEnable()
	{
		moveAction_Type_Keyboard.Enable();
		moveAction_Type_WheelDown.Enable();
		moveAction_Type_MouseDelta.Enable();
		zoomAction_Type_Mouse.Enable();
	}
	private void OnDisable()
	{
		moveAction_Type_Keyboard.Disable();
		moveAction_Type_WheelDown.Disable();
		moveAction_Type_MouseDelta.Disable();
		zoomAction_Type_Mouse.Disable();
	}

	private void Update()
	{
		Vector2 moveVector = moveAction_Type_Keyboard.ReadValue<Vector2>();
		strategy.Move_KeyBoard(moveVector);


		if(moveAction_Type_WheelDown.IsPressed())
		{
			Vector2 moveDelta = moveAction_Type_MouseDelta.ReadValue<Vector2>();
			strategy.Move_MouseWheel_Delta(moveDelta);
		}

		float Yaxis = zoomAction_Type_Mouse.ReadValue<float>();
		strategy.Zoom_MouseWheel_Scroll(Yaxis);

	}


}


public class Projection_OrthoGraphic : ICamera
{
	public CameraInfo cameraInfo { get; private set; }

	Projection_OrthoGraphic() { }
	public Projection_OrthoGraphic(CameraInfo info) => cameraInfo = info;


	public void Move_KeyBoard(Vector2 moveVector)
	{
		Camera.main.transform.position += new Vector3(moveVector.x , moveVector.y , 0 ) * cameraInfo.cameraMoveSpeed * Time.deltaTime;
	}
	public void Move_MouseWheel_Delta(Vector2 moveDelta)
	{

		Camera.main.transform.position += new Vector3(-moveDelta.x , -moveDelta.y , 0 ) * cameraInfo.cameraMoveSpeed * Time.deltaTime;


	}
	public void Zoom_MouseWheel_Scroll(float axisValue)
	{
		Camera.main.orthographicSize += axisValue * cameraInfo.cameraZoomSpeed;
		if (Camera.main.orthographicSize >= cameraInfo.cameraZoomMax)
			Camera.main.orthographicSize = cameraInfo.cameraZoomMax;
		if (Camera.main.orthographicSize <= cameraInfo.cameraZoomMin)
			Camera.main.orthographicSize = cameraInfo.cameraZoomMin;
	}

}




public class Projection_Perspective : ICamera
{
	public CameraInfo cameraInfo { get; private set; }

	Projection_Perspective() { }
	public Projection_Perspective(CameraInfo info) => cameraInfo = info;

	public void Move_KeyBoard(Vector2 moveVector)
	{
		Camera.main.transform.position += new Vector3(moveVector.x, moveVector.y, 0) * cameraInfo.cameraMoveSpeed * Time.deltaTime;
	}
	public void Move_MouseWheel_Delta(Vector2 moveDelta)
	{
		Camera.main.transform.position += new Vector3(-moveDelta.x, -moveDelta.y, 0) * cameraInfo.cameraMoveSpeed * Time.deltaTime;
		
	}
	public void Zoom_MouseWheel_Scroll(float axisValue)
	{
		Camera.main.fieldOfView += axisValue * cameraInfo.cameraZoomSpeed;
		if (Camera.main.fieldOfView >= cameraInfo.cameraZoomMax)
			Camera.main.fieldOfView = cameraInfo.cameraZoomMax;
		if (Camera.main.fieldOfView <= cameraInfo.cameraZoomMin)
			Camera.main.fieldOfView = cameraInfo.cameraZoomMin;
	}
}

