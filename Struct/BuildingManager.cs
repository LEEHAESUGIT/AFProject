using NUnit.Framework.Constraints;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildingManager : MonoBehaviour
{
	// is possible NULL
	[field: SerializeField]
	public GameObject NowSelectBuildingObject { get; private set; } = null;
	// Instance BuildObject
	private BuildingObject OBJ = null;
	private BuildingUI UI = null;



	// Tile
	public TileManager TileMG;

	// Input System
	private GameInput gameInput;
	private InputAction buildAction_LeftClick;
	private InputAction mousePosition;


	public bool IsDelete = false;


	private void Awake()
	{
		gameInput = new GameInput();
		buildAction_LeftClick = gameInput.Building.Build_LeftClick;
		mousePosition = gameInput.Building.Build_MousePosition;
	}

	private void Start()
	{
	}
	private void OnEnable()
	{
		buildAction_LeftClick.Enable();
		mousePosition.Enable();
	}

	private void OnDisable()
	{
		buildAction_LeftClick.Disable();
		mousePosition.Disable();
	}
	public void Update()
	{
		if (this.NowSelectBuildingObject != null)
		{
			if (OBJ.IsMove)
				TrackingMouseAtTile(InputMousePosToCellPos());

			if (OBJ.IsNotContact())
				UI.ChangeGreenColor();
			else
				UI.ChangeRedColor();

			if (buildAction_LeftClick.IsPressed() && NowSelectBuildingObject != null)
				BuildObject();
		}
	}

	public Vector3 InputMousePosToCellPos()
	{
		Vector2 tempMousePos = mousePosition.ReadValue<Vector2>();
		Vector3 screenToWorldPos = Camera.main.ScreenToWorldPoint(
			new Vector3(tempMousePos.x, tempMousePos.y, Camera.main.transform.position.z));
		Vector3Int cellPos = TileMG.GetCellPos(screenToWorldPos);
		if (!TileMG.IsCellHasTile(cellPos))
			throw new InvalidOperationException();



		return TileMG.GetCellCenterPos(cellPos);
	}


	public void TrackingMouseAtTile(Vector3 cellCenterPos)
	{
		float PosX;
		float PosY;

		PosX = UI.SizeXEvenOrOdd() ? cellCenterPos.x - 0.5f : cellCenterPos.x;
		PosY = UI.SizeYEvenOrOdd() ? cellCenterPos.y + 0.5f : cellCenterPos.y;


		if (NowSelectBuildingObject != null)
			NowSelectBuildingObject.transform.position = new Vector3(PosX, PosY, cellCenterPos.z - 0.1f);
	}



	public void BuildObject()
	{
		if (OBJ.IsPosibleBuild)
		{
			NowSelectBuildingObject.transform.position = new Vector3(	this.NowSelectBuildingObject.transform.position.x,
																		this.NowSelectBuildingObject.transform.position.y,
																		this.NowSelectBuildingObject.transform.position.z + 0.1f);
			UI.ChangeDefaultColor();
			OBJ.IsMove = false;
			this.UI = null;
			this.OBJ = null;
			this.NowSelectBuildingObject = null;

		}
	}

	public void SetBuildObejct(GameObject building)
	{
		this.NowSelectBuildingObject = building;
		this.OBJ = building.GetComponent<BuildingObject>();
		this.UI = building.GetComponent<BuildingUI>();
		OBJ.IsMove = true;
	}


	public void DeleteBuilding()
	{
		IsDelete = true;
		Destroy(NowSelectBuildingObject);
		NowSelectBuildingObject = null;
	}




}
