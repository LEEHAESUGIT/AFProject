using ECSCore;
using System.ComponentModel;
using UnityEngine;

internal static class ConponentSetting
{
	internal static void SetComponent()
	{
		// flag
		ComponentTypeRegister.Set(typeof(NeedInit)); // 무조건 항상 0번째
													 // Status
		ComponentTypeRegister.Set(typeof(MetalComponent));
		ComponentTypeRegister.Set(typeof(CopperComponent));
		ComponentTypeRegister.Set(typeof(OilComponent));
		ComponentTypeRegister.Set(typeof(GoldComponent));
		ComponentTypeRegister.Set(typeof(GasComponent));
		ComponentTypeRegister.Set(typeof(DelayTimeComponent));
		ComponentTypeRegister.Set(typeof(BuildActiveComponent));

	}
}
	public struct NeedInit : IComponentData
	{
	}
	// Resources
	public struct MetalComponent : IComponentData
	{
		public float value { get; set; }
	}
	public struct CopperComponent : IComponentData
	{
		public float value { get; set; }
	}
	public struct OilComponent : IComponentData
	{
		public float value { get; set; }
	}
	public struct GoldComponent : IComponentData
	{
		public float value { get; set; }
	}
	public struct GasComponent : IComponentData
	{
		public float value { get; set; }
	}



	// Interaction Resources
	public struct DelayTimeComponent : IComponentData
	{
		public float value { get; set; }
	}
	public struct BuildActiveComponent : IComponentData
	{
		public bool Is { get; set; }

	}

