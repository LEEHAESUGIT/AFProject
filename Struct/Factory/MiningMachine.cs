using ECSCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningMachine : MonoBehaviour
{
	// 지연시간
	public Entity ECS_EntityID { get; private set; }

	
	
	
	
	private readonly List<Collider> ResourceCollider = new List<Collider>();





	private void Start()
	{
		ECS_EntityID = createEntity();
		ECSWorld.ECSMG.Init(ECS_EntityID);

	}



	private Entity createEntity()
	{
		return ECSWorld.ECSMG.CreateEntity(	typeof(DelayTimeComponent),
											typeof(BuildActiveComponent));
	}


	//private IEnumerator mingingResource()
	//{

	//}

	private void OnTriggerEnter(Collider other)
	{
		
	}


}
