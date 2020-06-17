using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSlider : MonoBehaviour
{
    [Range(0f,1f)]
    public float distanceValue;

    public Transform startingPos;
    public Transform endingPos; 



    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPos.position; 
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(startingPos.position, .5f);
        Gizmos.DrawSphere(endingPos.position, .5f);
    }

    public void ChangeDistanceValue(float dist)
    {
        distanceValue = dist;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startingPos.position, endingPos.position, distanceValue);

        GetComponentInParent<ifListenCount>().condition.leftVal = distanceValue;

    }
}
