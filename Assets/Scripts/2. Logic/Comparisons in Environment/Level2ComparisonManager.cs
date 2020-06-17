using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VRTK;
public class Level2ComparisonManager : MonoBehaviour
{
    public List<EnvironmentCompare> compareList;
    public List<Transform> compareParents;
    public int compareIndex;
    public int correctAmount;
    public int totalCorrect;

    public TextMeshProUGUI var1;
    public TextMeshProUGUI var2;

    private int compareID;

    public VRTK_SnapDropZone dropZone;
    private int zoneID;

    public GameObject snappedObject;

   


    // Start is called before the first frame update
    void Start()
    {
        SetLists();
        dropZone.ObjectSnappedToDropZone += DropZone_ObjectSnappedToDropZone;
    }

    private void DropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        zoneID = e.snappedObject.GetComponent<TextBlock>().id;

        snappedObject = e.snappedObject;

        CheckInsert(e.snappedObject);
    }

    // Update is called once per frame
    void Update()
    {
        SetUI();
        SelectSection();
    }

    public void NextSection()
    {
        compareIndex++;
        
        if(compareIndex == compareList.Count - 1)
        {
            compareIndex = compareList.Count - 1;
        }
    }

    public void CheckInsert(GameObject snapped)
    {
        if(compareID == zoneID)
        {
            Debug.Log("CORRECT");

            snappedObject.GetComponent<Renderer>().material.color = Color.green;

            Invoke("CheckCorrect", 1.5f);

        }
        else
        {
            Debug.Log("Incorrect");

            snappedObject.GetComponent<Renderer>().material.color = Color.red;

            Invoke("CheckIncorrect", 1.5f);

        }
    }

    public void CheckCorrect()
    {
        correctAmount++;

        if(correctAmount == totalCorrect)
        {
            correctAmount = 0;
            NextSection();
        }


        CheckIndex();
        Destroy(snappedObject);
    }

    public void CheckIncorrect()
    {
        //Destroy(snappedObject);
    }

    public void CheckIndex()
    {
        if (compareIndex == 0)
        {
            CubeSpawner[] spawners = compareList[compareIndex].GetComponentsInChildren<CubeSpawner>();
            foreach (CubeSpawner spawner in spawners)
            {
                spawner.startComparison();
            }
        }
        else if (compareIndex == 1)
        {
            ObjectSizeChanger[] spawners = compareList[compareIndex].GetComponentsInChildren<ObjectSizeChanger>();
            foreach (ObjectSizeChanger spawner in spawners)
            {
                spawner.ChangeSize();
            }
        }
        else if (compareIndex == 2)
        {
            DistanceCompare compare = compareList[compareIndex].GetComponent<DistanceCompare>();
            compare.SetupCompare();
        }
    }


    public void SetUI()
    {
        switch (compareIndex)
        {
            case 0:
                var1.text = "redCount";
                var2.text = "blueCount";
                break;
            case 1:
                var1.text = "redSize";
                var2.text = "blueSize";
                break;
            case 2:
                var1.text = "redDistance";
                var2.text = "blueDistance";
                break;
        }
    }

    public void SelectSection()
    {
        for (int i = 0; i < compareParents.Count; i++)
        {
            if (i == compareIndex)
            {
                compareParents[i].gameObject.SetActive(true);
                compareID = compareParents[i].gameObject.GetComponent<EnvironmentCompare>().compareID;
            }
            else
            {
                compareParents[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetLists()
    {
        foreach (Transform child in transform)
        {
            EnvironmentCompare compare = child.GetComponent<EnvironmentCompare>();
            if (compare != null)
            {
                compareList.Add(compare);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            compareParents.Add(transform.GetChild(i).GetComponent<Transform>());
        }
    }



}
