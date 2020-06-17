using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePicker : MonoBehaviour
{
    public GameObject CubeObject;
    public GameObject CircleObject;
    public GameObject CylinderObject;
    public GameObject CapsuleObject;

    public Mesh CubeMesh;
    public Mesh CircleMesh;
    public Mesh CylinderMesh;
    public Mesh CapsuleMesh;

    // Start is called before the first frame update
    void Start()
    {
        CubeMesh = CubeObject.GetComponent<MeshFilter>().mesh;
        CircleMesh = CircleObject.GetComponent<MeshFilter>().mesh;
        CylinderMesh = CylinderObject.GetComponent<MeshFilter>().mesh;
        CapsuleMesh = CapsuleObject.GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCircle()
    {
        GetComponent<MeshFilter>().mesh = CircleMesh;
    }

    public void ChangeCylinder()
    {
        GetComponent<MeshFilter>().mesh = CylinderMesh;
    }

    public void ChangeCapsule()
    {
        GetComponent<MeshFilter>().mesh = CapsuleMesh;
    }

    public void ChangeCube()
    {
        GetComponent<MeshFilter>().mesh = CubeMesh;
    }

}
