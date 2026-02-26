using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingManager : MonoBehaviour
{
    // is possible NULL
    [field: SerializeField]
    public GameObject NowSelectBuildingObject { get; private set; } = null;

    public Tilemap tilemap;


	public void Update()
	{
        CellPosInTileMap();
	}
	public void CellPosInTileMap()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 100f;
            Camera.main.ScreenToWorldPoint(mousePos);
            Vector3Int pos = tilemap.WorldToCell(mousePos);

            Debug.Log( $" {pos.x} , {pos.y}");
        }


    }




}
