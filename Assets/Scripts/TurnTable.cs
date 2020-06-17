using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTable : MonoBehaviour
{
    [SerializeField] bool isTurning = true;
    [SerializeField] float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        if (isTurning)
        {
            Turn();
        }
    }

    private void Turn()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
