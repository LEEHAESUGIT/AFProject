using ECSCore;
using NUnit.Framework;
using UnityEngine;

public class Resource_Gas : MonoBehaviour
{
	public Entity ECS_Entity { get; private set; }
	[field: SerializeField]
	public float Gas { get; private set; } = 15f;
	[field: SerializeField]
	public float Resources_Value_MAX { get; private set; } = 1000f;
	[field: SerializeField]
	public float DelayTime { get; private set; } = 1f;

	private void Start()
	{
		createGasData();
		Init();
	}	

	private Entity createGasData()
	{
		return ECSWorld.ECSMG.CreateEntity(typeof(MetalComponent),
											typeof(MaxResourcesCompoent),
											typeof(DelayTimeComponent));
	}
	private void Init()
	{
		ECSWorld.ECSMG.Init(ECS_Entity);
		ECSWorld.ECSMG.Get<GasComponent>(ECS_Entity).value = Gas;
		ECSWorld.ECSMG.Get<MaxResourcesCompoent>(ECS_Entity).value = Resources_Value_MAX;
		ECSWorld.ECSMG.Get<DelayTimeComponent>(ECS_Entity).value = DelayTime;
	}
}

