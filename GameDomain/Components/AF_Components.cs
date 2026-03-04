using ECSCore;
using System.ComponentModel;
using UnityEngine;


// Resources
public struct MetalComponent : IComponentData
{ 
	public float value {  get;  set; }
}
public struct CopperComponent : IComponentData
{
	public float value { get;  set; }
}
public struct OilComponent : IComponentData
{
	public float value { get;  set; }
}
public struct GoldComponent : IComponentData
{
	public float value { get;  set; }
}
public struct GasComponent : IComponentData
{
	public float value { get;  set; }
}



// Interaction Resources
public struct DelayTimeComponent : IComponentData
{
	public float value { get; set; }
}


