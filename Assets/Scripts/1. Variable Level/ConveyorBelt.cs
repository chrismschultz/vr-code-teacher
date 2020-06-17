using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 1f;

    public Vector3 startingPos, endingPos;

    public float distanceTracker;


    // Start is called before the first frame update
    void Start()
    {
        //startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if(transform.position.x > endingPos.x)
        {
            transform.position = startingPos;
        }
    }

    public void SetStartAndEnd(Vector3 newStartPos, Vector3 newEndPos)
    {
        startingPos = newStartPos;
        endingPos = newEndPos;
        transform.position = new Vector3(transform.position.x, startingPos.y, startingPos.z);
    }

    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
