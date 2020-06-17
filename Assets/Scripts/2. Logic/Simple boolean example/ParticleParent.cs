using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using TMPro;


public class ParticleParent : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public ParticleSystem fountain;

    private string outputOnMax = "Maximum Reached";
    private string outputOnMin = "Minimum Reached";

    public TextMeshProUGUI boolVariable;
    public TextMeshProUGUI boolText;

    private void OnEnable()
    {
        boolVariable.text = "boolean waterOn = ";
    }

    // Start is called before the first frame update
    void Start()
    {
        
        fountain.Stop();
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }


    public virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMax != "")
        {
            boolText.text = "true";
            fountain.Play();
        }
    }

    public virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMin != "")
        {
            boolText.text = "false";
            fountain.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
