using ECSCore;
using UnityEngine;

public class Resource_Oil : MonoBehaviour
{
	public Entity ECS_Entity { get; private set; }
	[field: SerializeField]
	public float Oil { get; private set; } = 10f;
	[field: SerializeField]
	public float Resources_Value_MAX { get; private set; } = 1000f;
	[field: SerializeField]
	public float DelayTime { get; private set; } = 1f;

	private void Start()
	{
		createOilData();
		Init();
	}

	private Entity createOilData()
	{
		return ECSWorld.ECSMG.CreateEntity(typeof(MetalComponent),
											typeof(MaxResourcesCompoent),
											typeof(DelayTimeComponent));
	}
	private void Init()
	{
		ECSWorld.ECSMG.Init(ECS_Entity);
		ECSWorld.ECSMG.Get<OilComponent>(ECS_Entity).value = Oil;
		ECSWorld.ECSMG.Get<MaxResourcesCompoent>(ECS_Entity).value = Resources_Value_MAX;
		ECSWorld.ECSMG.Get<DelayTimeComponent>(ECS_Entity).value = DelayTime;
	}
}

