using ECSCore;
using UnityEngine;

public class Resource_Gold : MonoBehaviour
{
	public Entity ECS_Entity { get; private set; }
	[field: SerializeField]
	public float Gold { get; private set; } = 5f;
	[field: SerializeField]
	public float Resources_Value_MAX { get; private set; } = 1000f;
	[field: SerializeField]
	public float DelayTime { get; private set; } = 1f;

	private void Start()
	{
		createGoldData();
		Init();
	}

	private Entity createGoldData()
	{
		return ECSWorld.ECSMG.CreateEntity(typeof(MetalComponent),
											typeof(MaxResourcesCompoent),
											typeof(DelayTimeComponent));
	}
	private void Init()
	{
		ECSWorld.ECSMG.Init(ECS_Entity);
		ECSWorld.ECSMG.Get<GoldComponent>(ECS_Entity).value = Gold;
		ECSWorld.ECSMG.Get<MaxResourcesCompoent>(ECS_Entity).value = Resources_Value_MAX;
		ECSWorld.ECSMG.Get<DelayTimeComponent>(ECS_Entity).value = DelayTime;
	}
}

