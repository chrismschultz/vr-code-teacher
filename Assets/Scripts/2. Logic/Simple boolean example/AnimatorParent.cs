using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using TMPro;

public class AnimatorParent : MonoBehaviour
{
    public Animator anim;
    public string animName;

    public VRTK_BaseControllable controllable;

    public TextMeshProUGUI boolVariable;
    public TextMeshProUGUI boolText;

    private string outputOnMax = "Maximum Reached";
    private string outputOnMin = "Minimum Reached";

    private void OnEnable()
    {
        if (animName.CompareTo("Grow") == 0)
        {
            boolVariable.text = "boolean plantAlive = ";
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
            PlayAnimation();
        }
    }

    public virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMin != "")
        {
            boolText.text = "false";
            StopAnimation();
        }
    }

    public void PlayAnimation()
    {
        if(animName.CompareTo("Grow") == 0)
        {
            anim.SetBool("Grow", true);
        }
    }

    public void StopAnimation()
    {
        if (animName.CompareTo("Grow") == 0)
        {
            anim.SetBool("Grow", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
