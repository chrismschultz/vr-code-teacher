using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHandler : MonoBehaviour
{
    public GameObject CubeObject;
    public GameObject CircleObject;
    public GameObject CylinderObject;

    public List<int> matchKey;

    private Mesh CubeMesh;
    private Mesh CircleMesh;
    private Mesh CylinderMesh;

    // Start is called before the first frame update
    void Start()
    {
        CubeMesh = CubeObject.GetComponent<MeshFilter>().mesh;
        CircleMesh = CircleObject.GetComponent<MeshFilter>().mesh;
        CylinderMesh = CylinderObject.GetComponent<MeshFilter>().mesh;

        HandleShape();
        HandleColor();
        HandleSize();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetShape()
    {
        HandleShape();
        HandleColor();
        HandleSize();
    }

    public void HandleShape()
    {
        switch (matchKey[0])
        {
            case 0:
                ChangeCube();
                break;
            case 1:
                ChangeCircle();
                break;
            case 2:
                ChangeCylinder();
                break;
        }
    }

    public void HandleColor()
    {
        switch (matchKey[1])
        {
            case 0:
                ChangeRed();
                break;
            case 1:
                ChangeBlue();
                break;
            case 2:
                ChangeGreen();
                break;
        }
    }

    public void HandleSize()
    {
        switch (matchKey[2])
        {
            case 0:
                ChangeSmall();
                break;
            case 1:
                ChangeMedium();
                break;
            case 2:
                ChangeLarge();
                break;
        }
    }

    public void ChangeCube()
    {
        GetComponent<MeshFilter>().mesh = CubeMesh;
    }

    public void ChangeCircle()
    {
        GetComponent<MeshFilter>().mesh = CircleMesh;
    }

    public void ChangeCylinder()
    {
        GetComponent<MeshFilter>().mesh = CylinderMesh;
    }


    public void ChangeRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void ChangeBlue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void ChangeGreen()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }


    public void ChangeSmall()
    {
        transform.localScale = new Vector3(.25f, .25f, .25f);
    }

    public void ChangeMedium()
    {
        transform.localScale = new Vector3(.5f, .5f, .5f);
    }

    public void ChangeLarge()
    {
        transform.localScale = new Vector3(.75f, .75f, .75f);
    }


}
