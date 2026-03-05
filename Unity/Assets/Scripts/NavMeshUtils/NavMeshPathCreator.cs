using System.Collections.Generic;
using UnityEngine;

public class NavMeshPathCreator : MonoBehaviour
{
    [SerializeField] private List<Vector3> points;
    

    public Vector3 GetPoint(int index) => points[index];

    public int GetPointsCount() => points.Count;

    [ContextMenu("Add Point")]
    void AddPoint() => points.Add(gameObject.transform.position);
}
