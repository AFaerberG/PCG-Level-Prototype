using UnityEngine;

[CreateAssetMenu(fileName = "Biome", menuName = "Scriptable Objects/Biome")]
public class Biome : ScriptableObject
{
    public Material texture;
    public float scaleX = 1.0f;
    public float scaleY = 1.0f;
    public float scaleZ = 1.0f;
    public int chunkHeight = 64;
    public float heightModifier = 0f;
}
