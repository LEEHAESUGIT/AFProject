using ECSCore;
using UnityEngine;

public static class MiningMachineSystem
{
   
	public static void Mining(Entity entity)
	{
		ECSWorld.ECSMG.Get<DelayTimeComponent>(entity);
	}


}
