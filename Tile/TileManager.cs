using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileManager : MonoBehaviour
{
	private Tilemap BuildGridTilemap;

	private void Awake()
	{
		this.BuildGridTilemap = this.GetComponent<Tilemap>(); 
	}

	public Vector3Int GetCellPos(Vector3 mousePos)
	{
		Vector3Int cellPos = BuildGridTilemap.WorldToCell(mousePos);
		return cellPos;
	}
	public Vector3 GetCellCenterPos(Vector3Int cellPos)
	{
		Vector3 cellCenterPos = BuildGridTilemap.GetCellCenterWorld(cellPos);
		return cellCenterPos;
	}
	public bool IsCellHasTile(Vector3Int cellPos)
	{
		if(BuildGridTilemap.HasTile(cellPos))
		{
			return true;
		}
		return false;
	}
	
}
