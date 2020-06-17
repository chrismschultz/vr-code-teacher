using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using TMPro;

public class SoundParent : MonoBehaviour
{
    public AudioSource audioData;

    public string soundName;

    public VRTK_BaseControllable controllable;

    public TextMeshProUGUI boolVariable;
    public TextMeshProUGUI boolText;

    private string outputOnMax = "Maximum Reached";
    private string outputOnMin = "Minimum Reached";

    private void OnEnable()
    {
        if (soundName.CompareTo("boomBox") == 0)
        {
            boolVariable.text = "boolean playMusic = ";
            audioData.Stop();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }


    public virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMax != "")
        {
            boolText.text = "true";
            audioData.Play(0);
        }
    }

    public virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMin != "")
        {
            boolText.text = "false";
            audioData.Stop();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
