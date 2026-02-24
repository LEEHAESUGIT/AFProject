using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpawner : MonoBehaviour
{
    [field: SerializeField]
    public List<GameObject> BuildPrefab = new List<GameObject>();


    public void CenterBuildSpwan()
    {
        var build = Instantiate(BuildPrefab[0]);
    }
    public void SideBuildSpwan()
    {
        var build = Instantiate(BuildPrefab[1]);

    }

}
