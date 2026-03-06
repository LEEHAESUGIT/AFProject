
namespace ECSCore
{
	internal static class ConponentSetting
	{
		internal static void SetComponent()
		{
			// flag
			ComponentTypeRegister.Set(typeof(NeedInit)); // 무조건 항상 0번째

			ComponentTypeRegister.Set(typeof(MetalComponent));
			ComponentTypeRegister.Set(typeof(CopperComponent));
			ComponentTypeRegister.Set(typeof(OilComponent));
			ComponentTypeRegister.Set(typeof(GoldComponent));
			ComponentTypeRegister.Set(typeof(GasComponent));
			ComponentTypeRegister.Set(typeof(DelayTimeComponent));
			







														 // Status
			//ComponentTypeRegister.Set(typeof(HPComponent));
			//ComponentTypeRegister.Set(typeof(ATKComponent));
			//ComponentTypeRegister.Set(typeof(DEFComponent));

			//// 
			//ComponentTypeRegister.Set(typeof(EXPComponent));
			//ComponentTypeRegister.Set(typeof(GOLDComponent));
			//ComponentTypeRegister.Set(typeof(SPEEDComponent));

		}
	}





	// Status Components
	internal struct HPComponent : IComponentData
	{
		internal float point;
	}
	internal struct DEFComponent : IComponentData
	{
		internal float point;

	}
	internal struct ATKComponent : IComponentData
	{
		internal float point;
	}

	internal struct EXPComponent : IComponentData
	{
		internal float point;
	}

	internal struct GOLDComponent : IComponentData
	{
		internal float point;
	}

	internal struct SPEEDComponent : IComponentData
	{
		internal float point;
	}

	// Component Flags
	internal struct NeedInit : IComponentData { }
}