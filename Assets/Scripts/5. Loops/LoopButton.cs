using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class LoopButton : MonoBehaviour
{
    public int buttonIndex; 

    public enum ButtonType { forButton, whileButton }

    public ButtonType type;

    public LoopManager manager;
    public WhileLoopManager whileManager;

    public VRTK_BaseControllable controllable;

    public bool firstPress = false;

    // Start is called before the first frame update
    void Start()
    {
        if(type == ButtonType.forButton)
        {
            manager = GameObject.Find("For Loops").GetComponent<LoopManager>();
        }
        else{
            whileManager = GameObject.Find("While Loops").GetComponent<WhileLoopManager>();
        }
        

        controllable = transform.GetChild(1).GetComponent<VRTK_BaseControllable>();
        controllable.MaxLimitReached += Controllable_MaxLimitReached;
    }

    private void Controllable_MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if(firstPress == true)
        {
            if (type == ButtonType.forButton)
            {
                manager.StartLoop(buttonIndex);
            }
            else
            {
                whileManager.StartLoop(buttonIndex);
            }

        }
        

        firstPress = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
