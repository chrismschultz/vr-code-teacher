using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckScanObject : MonoBehaviour
{
    ObjectAccesor scanObject;

    public TextMeshProUGUI objectSize;
    public TextMeshProUGUI objectColor;
    public TextMeshProUGUI objectShape;
    public TextMeshProUGUI objectWeight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        scanObject = other.GetComponent<ObjectAccesor>();
        setText();
    }

    public void setText()
    {
        objectSize.text = scanObject.scanAttributes.size.ToString();
        objectColor.text = scanObject.scanAttributes.color.ToString();
        objectShape.text = scanObject.scanAttributes.shape.ToString();
        objectWeight.text = scanObject.scanAttributes.weight.ToString();
        
    }

    public void setText(ScannableScriptableObject scannable)
    {
        objectSize.text = scannable.size.ToString();
        objectColor.text = scannable.color.ToString();
        objectShape.text = scannable.shape.ToString();
        objectWeight.text = scannable.weight.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
