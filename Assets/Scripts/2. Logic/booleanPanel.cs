using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class booleanPanel : MonoBehaviour
{
    public LeverManager lever;
    public TextMeshProUGUI boolText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.leverValue == 1)
        {
            boolText.text = "true";
        }
        else if (lever.leverValue == -1)
        {
            boolText.text = "false";
        }
        else
        {
            boolText.text = "___";
        }
    }
}
