using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ShapeHandler : MonoBehaviour
{

    public GameObject CubeObject;
    public GameObject CircleObject;
    public GameObject CylinderObject;

    public VRTK_SnapDropZone shapeZone;
    public VRTK_SnapDropZone colorZone;
    public VRTK_SnapDropZone sizeZone;

    public List<int> key;

    private Mesh CubeMesh;
    private Mesh CircleMesh;
    private Mesh CylinderMesh;


    // Start is called before the first frame update
    void Start()
    {
        key.Add(0);
        key.Add(0);
        key.Add(0);

        CubeMesh = CubeObject.GetComponent<MeshFilter>().mesh;
        CircleMesh = CircleObject.GetComponent<MeshFilter>().mesh;
        CylinderMesh = CylinderObject.GetComponent<MeshFilter>().mesh;

        shapeZone.ObjectSnappedToDropZone += ShapeZone_ObjectSnappedToDropZone;
        colorZone.ObjectSnappedToDropZone += ColorZone_ObjectSnappedToDropZone;
        sizeZone.ObjectSnappedToDropZone += SizeZone_ObjectSnappedToDropZone;
    }


    private void ShapeZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        TextBlock snappedBlock = e.snappedObject.GetComponent<TextBlock>();

        switch (snappedBlock.id)
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

        key[0] = snappedBlock.id;

    }

    private void ColorZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        TextBlock snappedBlock = e.snappedObject.GetComponent<TextBlock>();

        switch (snappedBlock.id)
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

        key[1] = snappedBlock.id;
    }

    private void SizeZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        TextBlock snappedBlock = e.snappedObject.GetComponent<TextBlock>();

        switch (snappedBlock.id)
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

        key[2] = snappedBlock.id;

    }





    // Update is called once per frame
    void Update()
    {
        
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
