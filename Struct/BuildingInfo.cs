using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    [field: SerializeField]
    public float CellSizeX { get; private set; }
    [field: SerializeField]
    public float CellSizeY { get; private set; }
    [field: SerializeField]
    public float CellSizeZ { get; private set; }


    [field: SerializeField]
    public bool IsMove { get; private set; } = false;

	private void Start()
	{
		IsMove = true;
	}
	

	

}
