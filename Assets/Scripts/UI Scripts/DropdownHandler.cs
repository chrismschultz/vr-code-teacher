using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownHandler : MonoBehaviour
{
    public TMP_Dropdown dropDown;

    public GameObject ReferenceShape;
    ShapePicker shapePick;

    // Start is called before the first frame update
    void Start()
    {
        dropDown = GetComponent<TMP_Dropdown>();
        shapePick = ReferenceShape.GetComponent<ShapePicker>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeShape()
    {
        Debug.Log("Changing Shape");
        int shapeIndex = dropDown.value;
        switch (shapeIndex)
        {
            case 0:
                shapePick.ChangeCircle();
                break;
            case 1:
                shapePick.ChangeCylinder();
                break;
            case 2:
                shapePick.ChangeCapsule();
                break;
            case 3:
                shapePick.ChangeCube();
                break;
        }


    }

}
