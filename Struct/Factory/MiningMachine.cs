using ECSCore;
using UnityEngine;

public class MiningMachine : MonoBehaviour
{
	// 지연시간
	public Entity ECS_EntityID { get; private set; }

	private void Start()
	{
		ECS_EntityID = createEntity();
		ECSWorld.ECSMG.Init(ECS_EntityID);

	}

	private Entity createEntity()
	{
		return ECSWorld.ECSMG.CreateEntity(typeof(DelayTimeComponent));
	}


}
