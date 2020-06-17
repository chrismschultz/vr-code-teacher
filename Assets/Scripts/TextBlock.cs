using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlock : Block
{
    TextMeshPro textHolder;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        textHolder = GetComponentInChildren<TextMeshPro>();
        textHolder.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
