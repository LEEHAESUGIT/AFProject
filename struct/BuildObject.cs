using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// buildinfo의 셀사이즈에 따라 오브젝트의 scale사이즈 변경이된다.
//1-> 1 + 0.2 + 0.2 = 1.4
//2-> 2 + 0.2 + 0.2 + 0.2 = 2.6
//3-> 3 + 0.2 + 0.2 + 0.2 + 0.2 = 3.8
//4-> 4 + 0.2 + 0.2 + 0.2 + 0.2 + 0.2 = 5
// Cell사이의 간격이 0.2 1mm 즉 1칸당 양옆으로 0.2씩이 추가된다.
// 칸안에서 맞게 간격은 침범하지 않게 하려면 양옆의 간격 chd 0.4사를 제외한 값을 적용해야한다.


// 건축물. 플레이어가 직접 설치하는 모든 건축물에 포함된다.
// 건물의 메인 로직
public class BuildObject : MonoBehaviour
{
	private readonly List<Collider> contactCollider = new List<Collider>();

	// Object Inside Component
	private BuildingInfo buildingInfo;
	private BuildingUI buildingUI;
	
	// Outside Component
	public Grid MainTileGrid;



	private void Start()
	{
		this.buildingUI = GetComponent<BuildingUI>();
		this.buildingInfo = GetComponent<BuildingInfo>();

	}
	
	private void Update()
	{
		// true; 초록색으로 변경
		if(isNotContact())
		{
			buildingUI.ChangeGreen();
		}
		//false; 붉은색으로 변경
		else
		{
			buildingUI.ChangeRed();
		}
	}
	private void FixedUpdate()
	{
		buildMouseTracking();
	}



	// 충돌중인 콜라이더 갯수로 확인.
	// 1. 존재해서는 안된다.
	private bool isNotContact()
	{
		if(contactCollider.Count == 0)
		{
			return true;	
		}
		return false;
	}
	private void buildMouseTracking()
	{
		if (buildingInfo.IsMove == false)
			return;

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 100f;

		this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
	}


	private void OnTriggerEnter(Collider other)
	{
		contactCollider.Add(other);		
	}
	private void OnTriggerExit(Collider other)
	{
		contactCollider.Remove(other);
	}
}
