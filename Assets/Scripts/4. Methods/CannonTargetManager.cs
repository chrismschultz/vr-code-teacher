using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTargetManager : MonoBehaviour
{
    public List<Transform> targets;

    public int targetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
       foreach(Transform child in transform)
       {
            targets.Add(child);
       }

        SetTargets();
    }

    public void SetTargets()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if(i == targetIndex)
            {
                targets[targetIndex].gameObject.SetActive(true);
            }
            else
            {
                targets[i].gameObject.SetActive(false);
            }
        }
    }

    public void IncreaseIndex()
    {
        targetIndex++;
        targetIndex = targetIndex % targets.Count;
        SetTargets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
