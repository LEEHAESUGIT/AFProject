using ECSCore;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public Entity ECS_EntityID { get; private set; }

	public void Start()
	{
		ECS_EntityID = createData();
		ECSWorld.ECSMG.Init(ECS_EntityID);
		initData();

		StartCoroutine(increaseResources());
	}


	private Entity createData()
	{
		return ECSWorld.ECSMG.CreateEntity(typeof(MetalComponent),
													typeof(CopperComponent),
													typeof(OilComponent),
													typeof(GoldComponent),
													typeof(GasComponent)
													);

	}
	private void initData()
	{
		ECSWorld.ECSMG.Get<MetalComponent>(ECS_EntityID).value = 0f;
		ECSWorld.ECSMG.Get<CopperComponent>(ECS_EntityID).value = 0f;
		ECSWorld.ECSMG.Get<OilComponent>(ECS_EntityID).value = 0f;
		ECSWorld.ECSMG.Get<GoldComponent>(ECS_EntityID).value = 0f;
		ECSWorld.ECSMG.Get<GasComponent>(ECS_EntityID).value = 0f;
	}


	private IEnumerator increaseResources()
	{
		while (true)
		{
			ECSWorld.ECSMG.Get<MetalComponent>(ECS_EntityID).value += 8f;
			ECSWorld.ECSMG.Get<CopperComponent>(ECS_EntityID).value += 10f;
			ECSWorld.ECSMG.Get<OilComponent>(ECS_EntityID).value += 4f;
			ECSWorld.ECSMG.Get<GoldComponent>(ECS_EntityID).value += 2f;
			ECSWorld.ECSMG.Get<GasComponent>(ECS_EntityID).value += 15f;
			yield return new WaitForSeconds(1f);

		}
	}



}
