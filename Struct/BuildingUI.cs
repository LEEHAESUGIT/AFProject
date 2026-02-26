using UnityEngine;


// 건물 UI
//  이미지 ,색
public class BuildingUI : MonoBehaviour
{
	private Renderer buildingRenderer;
	private BuildingInfo buildingInfo;


	public Material red;
	public Material green;



	private void Start()
	{
		this.buildingInfo = GetComponent<BuildingInfo>();
		this.buildingRenderer = GetComponent<Renderer>();
	}
	

	// Size
	public void BuildingObjectScaleSize(Grid timeGrid)
	{
		this.transform.localScale = new Vector3(XCellGapSizeCaculator(timeGrid), YCellGapSizeCaculator(timeGrid), -1f);
	}
	private float XCellGapSizeCaculator(Grid tileGrid)
	{
		float resultX = buildingInfo.CellSizeX;
		return resultX + (tileGrid.cellGap.x * (resultX - 1));
	}
	private float YCellGapSizeCaculator(Grid tileGrid)
	{
		float resultY = buildingInfo.CellSizeY;
		return resultY + (tileGrid.cellGap.y * (resultY - 1));
	}

	// Color
	public void ChangeGreen()
	{
		this.buildingRenderer.material = green;
	}
	public void ChangeRed()
	{
		this.buildingRenderer.material = red;
	}


}