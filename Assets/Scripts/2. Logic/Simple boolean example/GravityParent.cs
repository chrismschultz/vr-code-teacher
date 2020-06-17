using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using TMPro;

public class GravityParent : MonoBehaviour
{
    public List<GameObject> children;
    public float thrust;

    public VRTK_BaseControllable controllable;

    public TextMeshProUGUI boolText; 
    public TextMeshProUGUI boolValue;

    private string outputOnMax = "Maximum Reached";
    private string outputOnMin = "Minimum Reached";

    private void OnEnable()
    {
        boolText.text = "boolean useGravity = ";
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            children.Add(child.gameObject);
        }

        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }


    public virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMax != "")
        {
            EnableGravity();
        }
    }

    public virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMin != "")
        {
            DisableGravity();
        }
    }



    public void EnableGravity()
    {
        boolValue.text = "true";
        for (int i = 0; i < children.Count; i++)
        {
            children[i].GetComponent<Rigidbody>().useGravity = true;
        }

    }

    public void DisableGravity()
    {
        boolValue.text = "false";

        for (int i = 0; i < children.Count; i++)
        {
            children[i].GetComponent<Rigidbody>().useGravity = false;
            children[i].GetComponent<Rigidbody>().AddForce(transform.up * thrust * Random.Range(.5f,1f));
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
