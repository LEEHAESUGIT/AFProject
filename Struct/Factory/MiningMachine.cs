using ECSCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningMachine : MonoBehaviour
{
	// 지연시간
	public Entity ECS_Entity { get; private set; }

	[field:SerializeField]
	public float DelayTime { get; private set; }
	[field:SerializeField]
	public bool IsBuildActive { get; private set; }
	
	
	
	private readonly List<Collider> ResourceCollider = new List<Collider>();





	private void Start()
	{
		ECS_Entity = createMiningMachineData();
		Init();

	}



	private Entity createMiningMachineData()
	{
		return ECSWorld.ECSMG.CreateEntity(	typeof(DelayTimeComponent),
											typeof(BuildActiveComponent));
	}
	private void Init()
	{
		ECSWorld.ECSMG.Init(ECS_Entity);
		ECSWorld.ECSMG.Get<DelayTimeComponent>(ECS_Entity).value = DelayTime;
		ECSWorld.ECSMG.Get<BuildActiveComponent>(ECS_Entity).Is = IsBuildActive;
	}


	private void OnTriggerEnter(Collider other)
	{
		
	}


}
