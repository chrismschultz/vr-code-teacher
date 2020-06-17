using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletTarget : MonoBehaviour
{
    //NEED TO FINISH THE BULLET TARGET, HAVE ____ CHANGE TO WHATEVER BULLET ID GOT PASSED IN.

    public int targetID;
    public string variable;

    public TextMeshPro typeText;
    public TextMeshPro variableText;

    Renderer backgroundRenderer;
    Color startingColor;
    


    // Start is called before the first frame update
    void Start()
    {
        backgroundRenderer = transform.GetComponent<Renderer>();
        startingColor = backgroundRenderer.material.color;

        typeText = transform.parent.GetChild(1).GetComponent<TextMeshPro>();
        

        variableText = transform.parent.GetChild(2).GetComponent<TextMeshPro>();


    }

    public void SetTargetInfo(int ID, string var)
    {
        Debug.Log("SETTING INFO: " + ID + "  " + var);
        targetID = ID;

        variable = var;

        if (variableText == null)
        {
            Debug.Log("NULL TEXT FIELD");
            variableText = transform.parent.GetChild(2).GetComponent<TextMeshPro>();
            variableText.text = var;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        variableText.text = variable;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        Bullet bullet = other.GetComponent<Bullet>();
        if(bullet != null && bullet.bulletID == targetID)
        {
            bulletHit(bullet);
            backgroundRenderer.material.color = Color.green;
            Destroy(other.gameObject);
            
            Invoke("ColorBackCorrect", .5f);

        }
        else
        {
            bulletHit(bullet);
            backgroundRenderer.material.color = Color.red;
            Destroy(other.gameObject);
            Invoke("ColorBack", .5f);
        }

        
    }

    public void HitTarget()
    {
        targetManager manager = GameObject.Find("Target Manager").GetComponent<targetManager>();
        manager.SpawnTargets();
        manager.targetCounter++;
        Destroy(transform.parent.gameObject);
    }

    public void bulletHit(Bullet bullet)
    {

        switch (bullet.bulletID) {
            case 0:
                typeText.text = "int";
                break;
            case 1:
                typeText.text = "float";
                break;
            case 2:
                typeText.text = "string";
                break;
        }

    }

    void ColorBack()
    {
        backgroundRenderer.material.color = startingColor;
        typeText.text = "____";
    }

    void ColorBackCorrect()
    {
        backgroundRenderer.material.color = startingColor;
        HitTarget();
    }

}
