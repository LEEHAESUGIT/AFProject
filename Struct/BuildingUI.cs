using UnityEngine;


// 건물 UI
//  이미지 ,색
public class BuildingUI : MonoBehaviour
{
	[field: SerializeField]
	public float SizeX { get; private set; }
	[field: SerializeField]
	public float SizeY { get; private set; }
	[field: SerializeField]
	public float SizeZ { get; private set; }


	
	public Material DefaultMaterial;
	public Material Red;
	public Material Green;
	


	private Renderer buildingRenderer;

	private void Awake()
	{
		this.buildingRenderer = GetComponent<Renderer>();
		DefaultMaterial = buildingRenderer.material;
	
		BuildingObjectScaleSize();
	}
	

	// Size
	public void BuildingObjectScaleSize()
	{
		//this.transform.localScale = new Vector3(XCellGapSizeCaculator(), YCellGapSizeCaculator(), 1f);
		this.transform.localScale = new Vector3(SizeX, SizeY, 1f);
	}
	private float XCellGapSizeCaculator()
	{
		float resultX = SizeX;
		return resultX - 0.2f;
	}
	private float YCellGapSizeCaculator()
	{
		float resultY = SizeY;
		return resultY - 0.2f;	
	}

	// Color
	public void ChangeDefaultColor()
	{
		this.buildingRenderer.material = DefaultMaterial;
	}
	public void ChangeGreenColor()
	{
		this.buildingRenderer.material = Green;
	}
	public void ChangeRedColor()
	{
		this.buildingRenderer.material = Red;
	}


}