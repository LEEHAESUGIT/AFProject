using ECSCore;
using UnityEngine;

public class Resource_Copper : MonoBehaviour
{
	public Entity ECS_Entity { get; private set; }
	[field: SerializeField]
	public float Copper { get; private set; } = 12f;
	[field: SerializeField]
	public float Resources_Value_MAX { get; private set; } = 1000f;
	[field: SerializeField]
	public float DelayTime { get; private set; } = 1f;

	private void Start()
	{
		createCopperData();
		Init();
	}

	private Entity createCopperData()
	{
		return ECSWorld.ECSMG.CreateEntity(typeof(MetalComponent),
											typeof(MaxResourcesCompoent),
											typeof(DelayTimeComponent));
	}
	private void Init()
	{
		ECSWorld.ECSMG.Init(ECS_Entity);
		ECSWorld.ECSMG.Get<CopperComponent>(ECS_Entity).value = Copper;
		ECSWorld.ECSMG.Get<MaxResourcesCompoent>(ECS_Entity).value = Resources_Value_MAX;
		ECSWorld.ECSMG.Get<DelayTimeComponent>(ECS_Entity).value = DelayTime;
	}
}

