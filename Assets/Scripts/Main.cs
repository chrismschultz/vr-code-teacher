using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Panel[] panels;
    public List<int> keys;

    public string mainKey;
    public string panelKeys;

    // Start is called before the first frame update
    void Start()
    {
        panels = GetComponentsInChildren<Panel>();
    }

    public void GenerateKey()
    {
        
        foreach(Panel panel in panels)
        {
            panelKeys+= panel.keyString;
            if(!panel.CheckKey())
            {
                Debug.Log("Error in Syntax, ID: " + panel.panelID);
            }
        }
        Debug.Log(panelKeys);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Panel")
        {
            Debug.Log(other.transform.name);
            if(!panels.Contains(other.GetComponent<Panel>()))
            {
                panels.Add(other.GetComponent<Panel>());
            }
        }
    }
    */


    // Update is called once per frame
    void Update()
    {
        
    }
}
