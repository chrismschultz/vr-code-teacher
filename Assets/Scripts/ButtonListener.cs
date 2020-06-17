using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class ButtonListener : MonoBehaviour
{
    public enum ButtonType {other,gridMovement }

    public ButtonType type;
    public bool firstPress = false;

    public VRTK_BaseControllable controllable;
    public Text displayText;
    public string outputOnMax = "Maximum Reached";
    public string outputOnMin = "Minimum Reached";

    protected virtual void OnEnable()
    {
        //controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);

        controllable = transform.GetChild(1).GetComponent<VRTK_BaseControllable>();

        controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }

    public virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
        if (displayText != null)
        {
            displayText.text = e.value.ToString("F1");
        }
    }

    public virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMax != "")
        {
            Debug.Log(outputOnMax);
        }

        if(type == ButtonType.gridMovement && firstPress == true)
        {
            Debug.Log(transform.name);
            if(transform.name == "Up")
            {
                GameObject.Find("GridMoveCube").GetComponent<GridBasedMovement>().MoveUp();
            }
            else if(transform.name == "Right")
            {
                GameObject.Find("GridMoveCube").GetComponent<GridBasedMovement>().MoveRight();
            }
            else if(transform.name == "Left")
            {
                GameObject.Find("GridMoveCube").GetComponent<GridBasedMovement>().MoveLeft();
            }
            else if (transform.name == "Down")
            {
                GameObject.Find("GridMoveCube").GetComponent<GridBasedMovement>().MoveDown();
            }
        }

        firstPress = true;
    }

    public virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMin != "")
        {
            //Debug.Log(outputOnMin);
        }
    }
}
