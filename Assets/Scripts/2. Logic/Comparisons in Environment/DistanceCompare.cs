using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCompare : EnvironmentCompare
{
    public GameObject redSphere;
    public GameObject blueSphere;

    public Transform playerPos; 

    public float distRed;
    public float distBlue;

    public float redTravel;
    public float blueTravel;

    private Vector3 redOriginalPos;
    private Vector3 blueOriginalPos;

    // Start is called before the first frame update
    void OnEnable()
    {
        redOriginalPos = redSphere.transform.position;
        blueOriginalPos = blueSphere.transform.position;

        SetupCompare();

    }

    public void SetupCompare()
    {
        distRed = Random.Range(-5f, 0f);

        distBlue = Random.Range(-5f, 0f);

        Vector3 redPos = redOriginalPos;
        redPos.x += distRed;

        Vector3 bluePos = blueOriginalPos;
        bluePos.x += distBlue;

        redTravel = Vector3.Distance(playerPos.position, redPos);
        blueTravel = Vector3.Distance(playerPos.position, bluePos);

        Debug.Log("Dist between the two" + Mathf.Abs(redTravel - blueTravel));

        if (Mathf.Abs(redTravel - blueTravel) < .5f)
        {
            float chance = Random.Range(0f, 1f);
            if (chance < .5f)
            {
                redPos.x -= 2f;
            }
            else
            {
                bluePos.x -= 2f;
            }

        }

        redSphere.transform.position = redPos;
        blueSphere.transform.position = bluePos;

        val1 = redTravel;
        val2 = blueTravel;

        compareValues();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetupCompare();
        }
    }
}
