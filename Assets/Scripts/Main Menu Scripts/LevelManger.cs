using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManger : MonoBehaviour
{
    public GameObject levelInformation;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableLevelInfo()
    {
        levelInformation.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void EnableLevelSelect()
    {
        levelInformation.SetActive(false);
        this.gameObject.SetActive(true);
    }

}
