using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSimulation : MonoBehaviour
{
    public GameObject colliderObject;
    [SerializeField] private float previousTime = 0.0f;
    [SerializeField] private float simulatedTime = 0.0f;
    [SerializeField] private float waveSpeedX = 5f;
    [SerializeField] private float waveSpeedY = 5f;
    [SerializeField] private float waveHeight = 0.1f;
    [SerializeField] private float cellDensity = 1f;

    private Mesh colliderMesh;  // Separate mesh for the collider
    private MeshCollider meshCollider;
    private Vector3[] colliderVertices;

    void Start()
    {
        // Get the MeshCollider component
        meshCollider = colliderObject.GetComponent<MeshCollider>();

        // Create a new mesh for the collider based on the original
        Mesh originalMesh = GetComponent<MeshFilter>().mesh;
        colliderMesh = Instantiate(originalMesh);

        // Assign the new mesh to the collider
        meshCollider.sharedMesh = colliderMesh;

        // Cache the collider's vertices for modification
        colliderVertices = colliderMesh.vertices;
    }

    void Update()
    {
        // Simulate time
        simulatedTime = Time.time;

        // Update the collider's position independently of the visible mesh
        UpdateColliderPosition();
    }

    private void UpdateColliderPosition()
    {
        if (colliderMesh == null || colliderVertices == null) return;
         
        // Loop through each vertex and apply wave-like displacement
        for (int i = 0; i < colliderVertices.Length; i++)
        {
            Vector3 vertex = colliderVertices[i];

            float perlinNoise = Mathf.PerlinNoise(vertex.x * cellDensity, vertex.z * cellDensity + simulatedTime);
            float perlinDisplacement = perlinNoise * waveHeight;

            // Apply wave displacement
            float waveDisplacement = Mathf.Sin(simulatedTime + vertex.x * waveSpeedX + vertex.z * waveSpeedY) * waveHeight;

            // Adjust only the y-position of each vertex to simulate wave motion
            vertex.y = waveDisplacement + perlinDisplacement;

            // Update the collider's vertex
            colliderVertices[i] = vertex;
        }

        // Apply the updated vertices to the collider's mesh
        colliderMesh.vertices = colliderVertices;

        // Recalculate bounds and normals for the collider mesh
        colliderMesh.RecalculateBounds();
        colliderMesh.RecalculateNormals();

        // Manually reassign the Mesh to the MeshCollider
        meshCollider.sharedMesh = null;  // Temporarily reset the collider mesh
        meshCollider.sharedMesh = colliderMesh;  // Reassign the updated mesh
    }
}