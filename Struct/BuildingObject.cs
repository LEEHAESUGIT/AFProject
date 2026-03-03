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
public class BuildingObject : MonoBehaviour
{
	private readonly List<Collider> contactCollider = new List<Collider>();

	[field: SerializeField]
	public bool IsMove { get; set; } = false;
	[field: SerializeField]
	public bool IsPosibleBuild { get; set; } = false;


	// 충돌중인 콜라이더 갯수로 확인.
	// 1. 존재해서는 안된다.
	public bool IsNotContact()
	{
		if(contactCollider.Count == 0)
		{
			IsPosibleBuild = true;
			return true;	
		}
		IsPosibleBuild = false;
		return false;
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
