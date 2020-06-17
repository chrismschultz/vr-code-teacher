using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VRTK.Controllables;
using VRTK.Examples;
using UnityEngine.UI;

public class FastOperatorPanel : MonoBehaviour
{
    public TextMeshProUGUI var1Value;
    public TextMeshProUGUI var2Value;
    public TextMeshProUGUI operatorText;
    public TextMeshProUGUI booleanValue;

    public TextMeshProUGUI answer;

    public operatorInfo[] operatorInfos;

    private int index;

    //What can detect if a max or min value has been reached
    public VRTK_BaseControllable controllable;

    private bool leverSelect;

    private string outputOnMax = "Maximum Reached";
    private string outputOnMin = "Minimum Reached";

    private Image backGround;
    private Color startingColor;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        leverSelect = false;

        answer.text = "";

        backGround = GetComponent<Image>();
        startingColor = backGround.color;

        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;

    }


    public virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMax != "")
        {
            Debug.Log("MAX REACHED IN OPERATOR PANEL");
            leverSelect = true;
            CheckLever();
        }
    }

    public virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMin != "")
        {
            Debug.Log("MIN REACHED IN OPERATOR PANEL");
            leverSelect = false;
            CheckLever();
        }
    }


    public void CheckLever()
    {
        if(operatorInfos[index].isTrue == leverSelect)
        {
            Debug.Log("Correct");
            answer.text = "Correct";
            //backGround.color = Color.green;
            

            if(leverSelect)
            {
                booleanValue.text = "true";
            }
            else
            {
                booleanValue.text = "false";
            }

            Invoke("ColorCorrect", 1f);
        }
        else
        {
            Debug.Log("Incorrect");
            answer.text = "Incorrect";
            //backGround.color = Color.red;

            if (leverSelect)
            {
                booleanValue.text = "true";
            }
            else
            {
                booleanValue.text = "false";
            }

            Invoke("ColorWrong", 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var1Value.text = operatorInfos[index].var1.ToString();
        var2Value.text = operatorInfos[index].var2.ToString();
        operatorText.text = operatorInfos[index].operatorValue.ToString();
    }

    void ColorWrong()
    {
        backGround.color = startingColor;
        booleanValue.text = "___";
        answer.text = "";
    }

    void ColorCorrect()
    {
        backGround.color = startingColor;
        index++;

        if (index > operatorInfos.Length - 1)
        {
            index = 0;
        }

        booleanValue.text = "___";
        answer.text = "";

    }

    [System.Serializable]
    public class operatorInfo
    {
        public float var1;
        public float var2;
        public string operatorValue;
        public bool isTrue;
    }


}
