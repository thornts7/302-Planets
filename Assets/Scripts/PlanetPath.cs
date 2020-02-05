using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlanetPath : MonoBehaviour
{
    public Transform CenterObject;
    public LineRenderer OrbitPath;
    public Material material;
    public float radius = 6;
    public int resolution = 32;

    void Start()
    {
        OrbitPath = GetComponent<LineRenderer>();
        OrbitPath.loop = true;
        OrbitPath.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
    }

    private Vector3 FindOrbitPoint(float angle, float mag)
    {
        Vector3 pos = (CenterObject == null) ? Vector3.zero : CenterObject.position;

        pos.x += Mathf.Cos(angle) * mag;
        pos.z += Mathf.Sin(angle) * mag;
        return pos;
    }

    /// <summary>
    /// Set the points in the LineRenderer
    /// </summary>
    void UpdatePoints()
    {
        Vector3[] points = new Vector3[resolution];

        for (int i = 0; i < points.Length; i++)
        {
            //calc x, y, and z

            float p = i / (float)points.Length;
            float radians = p * Mathf.PI * 2;
            points[i] = FindOrbitPoint(radians, radius);
        }

        OrbitPath.positionCount = resolution;
        OrbitPath.SetPositions(points);
    }
}
