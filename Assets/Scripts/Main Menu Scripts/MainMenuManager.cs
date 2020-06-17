using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenuParent;
    public GameObject OptionsParent;
    public GameObject LevelsParent;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    public void DisableMainMenu()
    {
        MainMenuParent.SetActive(false);
    }

    public void EnableMenu()
    {
        MainMenuParent.SetActive(true);
    }

    public void EnableOptions()
    {
        DisableMainMenu();
        OptionsParent.SetActive(true);
    }

    public void DisableOptions()
    {
        OptionsParent.SetActive(false);
        EnableMenu();    
    }

    public void EnableLevels()
    {
        DisableMainMenu();
        LevelsParent.SetActive(true);
    }

    public void DisableLevels()
    {
        EnableMenu();
        LevelsParent.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
