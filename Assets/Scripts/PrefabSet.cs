using UnityEngine;
[CreateAssetMenu(fileName = "PrefabSet", menuName = "ScriptableObjects/PrefabSet", order = 1)]

public class PrefabSet : ScriptableObject
{
  public GameObject[] prefab;
  
}



[System.Serializable]
public struct Vec3AsGridCostil
{
    public int superPositionTreasHold;
    public float chance;
    public Vector3Int line1;
    public Vector3Int line2;
    public Vector3Int line3;

}
