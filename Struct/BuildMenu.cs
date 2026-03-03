using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    [field: SerializeField]
    public List<GameObject> BuildPrefab = new List<GameObject>();

    public BuildingManager BuildMG;

	private void Start()
	{
		//BuildMG = this.GetComponent<BuildingManager>();
	}

	public void CenterBuildSpwan()
    {
        GameObject build = Instantiate(BuildPrefab[0]);
		BuildMG.SetBuildObejct(build);
    }
    public void SideBuildSpwan()
    {
        GameObject build = Instantiate(BuildPrefab[1]);
		BuildMG.SetBuildObejct(build);

	}
    public void DeleteBuilding()
    {
        BuildMG.IsDelete = true;
        //BuildMG.SetBuildObejct();
        BuildMG.DeleteBuilding();
    }


}
