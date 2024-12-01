using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "CubeModel", menuName = "Scriptable Objects/CubeModel")]
public class CubeModelSO : ScriptableObject
{
    public Vector3 position;
    public Vector3 rotation;

    public float moveSpeed;
}
