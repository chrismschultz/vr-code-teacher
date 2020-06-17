using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] float hoverRange = 0.1f;

    void Update()
    {
        AnimateHover();
    }

    private void AnimateHover()
    {
        float deltaY = Mathf.Sin(Time.time + Time.deltaTime) - Mathf.Sin(Time.time);
        transform.position += new Vector3(0f, deltaY * hoverRange, 0f); ;
    }
}
