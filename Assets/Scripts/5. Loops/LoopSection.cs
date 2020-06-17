using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopSection : MonoBehaviour
{
    public TextMeshProUGUI printAreaBody;

    // Start is called before the first frame update
    void Awake()
    {
        printAreaBody = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
