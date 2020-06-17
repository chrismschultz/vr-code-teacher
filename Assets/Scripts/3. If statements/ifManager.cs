using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class ifManager : MonoBehaviour
{
    public int ifIndex;
    public ifType type;

    public GameObject ifPanel;
    public GameObject ifElsePanel;

    public GameObject countManager;
    public GameObject sizeManager;
    public GameObject distanceManager;

    public VRTK_BaseControllable nextButton;

    public enum ifType { ifType, ifElseType, ifElseIfType}

    private bool firstPress;

    // Start is called before the first frame update
    void Start()
    {
        firstPress = true;
        checkManager();
        checkIfType();

        nextButton.MaxLimitReached += NextButton_MaxLimitReached;
    }

    private void NextButton_MaxLimitReached(object sender, ControllableEventArgs e)
    {
        
        if(ifIndex < 2 && !firstPress)
        {
            ifIndex++;
        }

        firstPress = false;

        checkManager();
        checkIfType();
    }

    // Update is called once per frame
    void Update()
    {
        //checkManager();
        //checkIfType();
    }

    public void checkIfType()
    {
        switch (type)
        {
            case ifType.ifType:
                ifPanel.SetActive(true);
                ifPanel.GetComponent<IfPanel>().conditionIndex = ifIndex;
                ifElsePanel.SetActive(false);
                break;
            case ifType.ifElseType:
                ifPanel.SetActive(false);
                ifElsePanel.SetActive(true);
                ifElsePanel.GetComponent<IfElsePanel>().conditionIndex = ifIndex;
                break;
        }

    }

    public void checkManager()
    {
        switch (ifIndex)
        {
            case 0:
                countManager.SetActive(true);
                sizeManager.SetActive(false);
                distanceManager.SetActive(false);
                break;
            case 1:
                countManager.SetActive(false);
                sizeManager.SetActive(true);
                distanceManager.SetActive(false);
                break;
            case 2:
                countManager.SetActive(false);
                sizeManager.SetActive(false);
                distanceManager.SetActive(true);
                break;
        }
    }


}
