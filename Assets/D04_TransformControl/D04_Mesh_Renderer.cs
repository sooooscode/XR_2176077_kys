using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D04_Mesh_Renderer : MonoBehaviour
{
    MeshFilter ThisMeshFilter;
    public GameObject Sphere, Capsule;

    public Material Red, Green;
    Renderer ThisRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ThisMeshFilter = GetComponent<MeshFilter>();
        ThisRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThisMeshFilter.mesh = Sphere.GetComponent<MeshFilter>().mesh;
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            ThisMeshFilter.mesh = Capsule.GetComponent<MeshFilter>().mesh;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ThisRenderer.material = Red;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ThisRenderer.material = Green;
        }
       
    }
}
