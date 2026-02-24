using UnityEngine;

public class BuildInfo : MonoBehaviour
{
    [field: SerializeField]
    public float CellSizeX { get; private set; }
    [field: SerializeField]
    public float CellSizeY { get; private set; }
    [field: SerializeField]
    public float CellSizeZ { get; private set; }


}
