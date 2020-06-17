using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSizeChanger : MonoBehaviour
{
    public float objectID;
    public float objectSize;
    public EnvironmentCompare parentCompare;
    private Vector3 originalScale;

    private int compareIndex; 

    // Start is called before the first frame update
    void OnEnable()
    {
        parentCompare = GetComponentInParent<EnvironmentCompare>();

        originalScale = transform.localScale;
    }

    public void ChangeSize()
    {
        compareIndex++;

        objectSize = Random.Range(.25f, 1.5f);


        transform.localScale = objectSize * originalScale;

        if (objectID == 0)
        {
            parentCompare.val1 = objectSize;
        }
        else if (objectID == 1)
        {
            parentCompare.val2 = objectSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSize();
        }
    }
}
