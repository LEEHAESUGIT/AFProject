using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BuildInfo : MonoBehaviour
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
	private void FixedUpdate()
	{
        buildMouseTracking();
	}


	private void buildMouseTracking()
    {
        if (this.IsMove == false)
            return;

        Vector3 mousePos = Input.mousePosition;
		mousePos.z = 100f; 

        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos); 

        //this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

}
