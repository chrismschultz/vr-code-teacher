using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using TMPro;

public class LightParent : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public List<GameObject> lights;

    public TextMeshProUGUI boolVariable;
    public TextMeshProUGUI boolText;

    private string outputOnMax = "Maximum Reached";
    private string outputOnMin = "Minimum Reached";

    private void OnEnable()
    {
        boolVariable.text = "boolean lightsActive = ";
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            lights.Add(child.gameObject);
        }

        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }

    public virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMax != "")
        {
            boolText.text = "true";
            EnableLights();
        }
    }

    public virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMin != "")
        {
            boolText.text = "false";
            DisableLights();
        }
    }


    public void EnableLights()
    {
        boolText.text = "true";
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].SetActive(true);
        }

    }

    public void DisableLights()
    {
        boolText.text = "false";
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].SetActive(false);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
