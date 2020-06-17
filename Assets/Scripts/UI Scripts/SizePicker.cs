using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePicker : MonoBehaviour
{
    [Range(.1f, 1.5f)]
    public float shapeScale;
    Transform shapeTransform;

    public bool isCompare;

    private ifListenCount listener; 

    // Start is called before the first frame update
    void Start()
    {
        shapeTransform = gameObject.GetComponent<Transform>();

        ChangeSize(shapeScale);

        if(isCompare)
        {
            listener = GetComponentInParent<ifListenCount>();
        }

    }

    public void ChangeSize(float changeAmount)
    {
        float changeScale = Mathf.Clamp(changeAmount, 0.1f, 2f);
        shapeScale = changeScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(shapeScale, shapeScale, shapeScale);
        if(isCompare)
        {
            listener.condition.leftVal = shapeScale;
        }
    }
}
