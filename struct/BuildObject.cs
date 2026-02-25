using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;


// 건축물. 플레이어가 직접 설치하는 모든 건축물에 포함된다.
public class BuildObject : MonoBehaviour
{
	BoxCollider boxCollider;

	private readonly List<Collider> contactCollider = new List<Collider>();

	public Material red;
	public Material green;

	Renderer buildRender;
	//Color defaultRenderColor;

	private void Awake()
	{
		boxCollider = this.GetComponent<BoxCollider>();
		buildRender = this.GetComponent<Renderer>();
		//defaultRenderColor = buildRender.material.color;
	}


	private void Update()
	{
		// true; 초록색으로 변경
		if(isNotContact())
		{
			buildRender.material.color = Color.green;
		}
		//false; 붉은색으로 변경
		else
		{
			buildRender.material.color = Color.red;
		}


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



	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("touch");
		contactCollider.Add(other);		
	}
	private void OnTriggerExit(Collider other)
	{
		contactCollider.Remove(other);
	}
}
