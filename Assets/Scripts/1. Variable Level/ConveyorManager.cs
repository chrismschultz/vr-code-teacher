using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    public List<GameObject> beltParts;
    public float maxDistance;
    public float speed;
    public Vector3 startingPos, endingPos;


    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            beltParts.Add(child.gameObject);

        }

        SetStartAndEnd();
        UpdateSpeed(speed);
    }

    public void Update()
    {
        SetStartAndEnd();
    }

    public void SetStartAndEnd()
    {
        for (int i = 0; i < beltParts.Count; i++)
        {
            beltParts[i].GetComponent<ConveyorBelt>().SetStartAndEnd(startingPos, endingPos);
        }
    }

    public void UpdateSpeed(float newSpeed)
    {
        for(int i = 0; i < beltParts.Count; i++)
        {
            beltParts[i].GetComponent<ConveyorBelt>().UpdateSpeed(newSpeed);
        }
    }
}
